using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViDi2.Runtime;
using ViDi2.UI;
using ViDi2.Local;
using CdioCs;
using System.Windows.Threading;
using System.Timers;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Threading;
using log4net;
using System.Windows.Media.Imaging;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;
using MX65ViDiDetecter;
using System.Drawing;
using System.Drawing.Imaging;
//ADD_START :2021/11/3 kitayama 理由：処理結果を表示するリストを使用する際に必要なので追加
using System.Collections.ObjectModel;
//ADD_END :2021/11/3 kitayama 理由：処理結果を表示するリストを使用する際に必要なので追加

////////////////////////////////////////////////////////////////////////////////
///     三菱電機殿向け　ViDi検査　ソフトウェア
/// 開発請け負い：北山　＆　有限会社ユキネカンパニ
/// 著作：2020/11/6 　北山、有限会社ユキネカンパニ　日向
/// 　注意：上記の全ての関連会社に許可なく複製又は改造などを行う事を禁止します。
/// 　　　　許可なく複製、改造した場合は、相応の損害賠償請求を著作側から行う事と本ソフトウェアのサポートは行われません。
////////////////////////////////////////////////////////////////////////////////

/** @file MainWindow.xaml.cs
*  @brief Simple example illustrating the utilisation of the runtime API
*  @example Example.Runtime.cs
*/

namespace Example.Runtime
{
    ///////////////////////////////////////////////////////////////////////////////////////////
    // 中川 追加
    using PlcComm;
    ///////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        IControl control;
        IWorkspace workspace;
        IStream stream;
        IStream[] istream = new IStream[11];

        //MEMO :2021/11/1 kitayama 今削除するとエラーが大量に出るので、後で削除予定
        //DELETE_START :2021/11/1 kitayama 理由：DIOは使用しないので削除
        Cdio dio;

        #region 変数定義
        //DELETE_END :2021/11/1 kitayama 理由：DIOは使用しないので削除

        //DELETE_START :2021/11/6 kitayama 理由：bViDiFlagは使用していないので削除予定
        public static bool bViDiFlag = false;

        public static bool mvFlag = false;
        public static bool bReset = true;
        public static bool bInit = true;
        public static bool detect_on = false;
        public string str2 = null;
        //DELETE_START :2021/11/20 kitayama 理由：使用していないフラグを削除
        //public static bool startflag = false;
        //DELETE_END :2021/11/20 kitayama 理由：使用していないフラグを削除
        public static bool bDetectFlag = false;
        //CHANGE_START :2022/2/5 kitayama 理由：ワンショットモード時の保存先を追加
        //CHANGE_START :2021/11/27 kitayama 理由：保存先をOK画像、NG画像、判定不可画像の配列に変更
        //[0]：OK画像保存パス、[1]：判定不可画像保存パス、[2]：NG画像保存パス
        //[3]：ワンショットOK保存先、[4]：ワンショット判定不可保存先、[5]：ワンショットNG保存先
        public static string[] sImagePath = new string[6];
        //public static string sGetImagePath = "";
        //public static string sSetImagePath = "";
        //CHANGE_END :2021/11/27 kitayama 理由：保存先をOK画像、NG画像、判定不可画像の配列に変更
        //CHANGE_END :2022/2/5 kitayama 理由：ワンショットモード時の保存先を追加
        public static int iGetImageInterval = 0;
        public static int iMoveImageInterval = 0;
        public static int iHoldTime = 1000;

        public static string[] sKishu = new string[10];
        public static string[] sWorkspece = new string[10];
        public static double[,] dThreshold = new double[10, 11];
        public static int selectedItem = -1;

        public static int kishuno = 1;
        //CHANGE_START :2021/11/14 kitayama 理由：閾値の上限下限を格納するための配列を別の場所で宣言するので削除
        //CHANGE_START :2021/11/7 kitayama 理由：閾値を格納する配列を変更
        //public static double[,,] dThreshold2 = new double[10, 11, 5];
        //public static double[,] dThreshold3 = new double[10,5];
        //CHANGE_END :2021/11/7 kitayama 理由：閾値を格納する配列を変更
        //CHANGE_END :2021/11/14 kitayama 理由：閾値の上限下限を格納するための配列を別の場所で宣言するので削除
        public static string form1_pass;

        public static int snum = 0;
        public static int anum = 0;
        public static int szero = 1;
        public static string filename2;
        public static bool aflag = false;
        public static string[] filename3 = new string[22];
        //ADD_START :2021/11/6 kitayama 理由：改造で必要な変数を追加
        //画像取得先フォルダはおそらく1つなので配列ではなく変数とする
        public static string foldername3 = "";
        //画像処理結果を格納する配列
        //v_kekka[1,n,n]にはスコア、v_kekka[2,n,n]には判定、v_kekka[3,n,n]には処理時間を格納する
        //v_kekka[x,y,z] x:格納するデータ種別　y:使用Analyze　z:処理画像の枚数
        public static double[,,] v_kekka = new double[3, 10, 100];
        //ADD_START :2021/11/13 kitatyama 理由：判定不可に対応するため追加
        //総合判定に使用するv_kekka[2,n,n]の合計値を格納する配列
        public static int[] sum_kekka2 = new int[100];
        //ADD_END :2021/11/13 kitatyama 理由：判定不可に対応するため追加

        //v_kekkaのインデックスをカウントする変数
        public static int v_num = 0;
        //合計処理時間を格納する変数
        public static double processingtime = 0;
        //ファイル数確認フラグ
        public static bool f_countflag = true;
        //ViDiに渡すファイルを格納する配列
        public static string[] d_files=null;
        //画像処理部でのエラーフラグ
        public static bool errflag = false;
        //ADD_END :2021/11/6 kitayama 理由：改造で必要な変数を追加
        //ADD_START :2021/11/11 kitayama 理由：画像処理部で使用するフラグを追加
        //検査開始ファイル数
        int d_startnum = 5;
        //検査開始フラグ
        //bool f_startflag = false;
        bool shot_startflag = false;
        //検査終了フラグ
        bool endflag = false;
        //ADD_END :2021/10/31 kitayama 理由：検査開始ファイル数、検査開始フラグなどを仮に設定した
        //ADD_START :2021/11/3 kitayama 理由：画像ファイルを格納する変数の宣言を追加
        string str_f = "";
        bool vidiflag = false;
        bool f_mvflag = false;
        //ADD_END :2021/11/3 kitayama 理由：画像ファイルを格納する変数の宣言を追加
        //画像取り込みで使用するフラグ
        public static bool shotflag = false;
        //ADD_END :2021/11/11 kitayama 理由：画像処理部で使用するフラグを追加
        //ADD_START :21021/11/13 kitayama 理由：画像を保存する配列を追加
        public static int shot_index = 0;
        public Bitmap[] bmpimages = new Bitmap[100];
        //ADD_END :21021/11/13 kitayama 理由：画像を保存する配列を追加
        //ADD_START :2021/11/13 kitayama 理由：検査に使用するAnalyzeの数を格納する変数を追加
        //使用できるStreamは元の仕様に合わせている
        public static int STREAM_NUM = 11;
        //使用するAnalyzeは最大10個なのでANALYZE_NUMの上限は10
        public static int ANALYZE_NUM = 10;
        //結果格納に使用する
        public static int[] V_CONST =new int[4];
        public static int v_initial = -1;
        //ADD_END :2021/11/13 kitayama 理由：検査に使用するAnalyzeの数を格納する変数を追加

        //CHANGE_START :2021/11/23 kitayama 理由：配列の次元を変更
        //dThreshold[上限・下限, 品種, Stream, Analyze]
        public static double[,,,] dThreshold3 = new double[2, 10, STREAM_NUM, ANALYZE_NUM];
        //ADD_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
        //public static double[,,] dThreshold3 = new double[2,10, ANALYZE_NUM];
        //ADD_END :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
        //CHANGE_END :2021/11/23 kitayama 理由：配列の次元を変更

        //ADD_START :2021/11/14 kitayama 理由：各Analyzeの検査名称を格納する配列を追加
        public static string[,,] a_meisyou = new string[10, STREAM_NUM, ANALYZE_NUM];
        //ADD_START :2021/11/14 kitayama 理由：各Analyzeの検査名称を格納する配列を追加
        //ADD_START :2021/11/25 kitayama 理由：Streamの検査名称を格納する配列を追加
        public static string[,] s_meisyou = new string[10, STREAM_NUM];
        //ADD_END :2021/11/25 kitayama 理由：Streamの検査名称を格納する配列を追加

        //ADD_START :2021/11/25 kitayama 理由：検査結果表示用の配列を追加
        public static string[] inter_imagetext = new string[1000];
        public static string[] ng_imagetext = new string[1000];
        //ADD_END :2021/11/25 kitayama 理由：検査結果表示用の配列を追加

        //ADD_START :2021/11/23 kitayama 理由：判定結果を格納するための変数を追加
        //処理フローのaに相当する変数
        public static int hanntei_num=0;
        //ADD_END :2021/11/23 kitayama 理由：判定結果を格納するための変数を追加

        //ADD_START :2021/11/13 kitayama 理由：判定結果格納用の列挙子を追加
        //総合判定結果、総合判定用のフラグを格納する
        enum Hanntei
        {
        OK,
        NOR,
        NG,
        }
        //ADD_END :2021/11/136 kitayama 理由：判定結果格納用の列挙子を追加


        //画像の取得周期はinterval2に格納する
        //カメラのシャッタースピードはshutterspeedに格納する
        //ADD_START :2021/12/2 kitayama 理由：画像処理スレッドの実行周期を設定する変数を追加
        //画像処理周期(ms)
        public static int INTERVAL1 = 5;
        //ADD_END :2021/12/2 kitayama 理由：画像処理スレッドの実行周期を設定する変数を追加
        //ADD_START :2021/12/2 kitayama 理由：画像撮影スレッドの実行周期を設定する変数を追加
        //カメラのフレームレートが160fpsなので1/160=6.25ms以上に設定する
        public static int interval2 = 10;
        //ADD_END :2021/12/2 kitayama 理由：画像撮影スレッドの実行周期を設定する変数を追加

        //ADD_START :2022/1/9 kitayama 理由：設定ファイル名の宣言を追加
        //ChangeXMLでもこの変数を使用する
        public static string fileName = @"memberse3.xml";
        //ADD_END :2022/1/9 kitayama 理由：設定ファイル名の宣言を追加

        public static int STREAMS = 11;
        public static int ANALYZES = 5;
        double[] ascore = new double[5];
        string[] aokng = new string[5];

        public static bool resetflag = false;
        public static bool ngflag = false;
        public static bool scoreflag = true;

        public static int total_images = 0;
        public static int ok_images = 0;
        public static int ng_images = 0;
        public static bool okng_flag = true;
        public static ushort file_ext = 0;

        public static string savefilename = "";
        public static string[] houkou = new string[12] { "-", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
        public static bool shot_trigger = false;
        public static int ihoukou = 0;

        public static bool stop_flag = false;
        public static int iShutterspeed = 0;
        public static int iBrightness = 0;
        public static bool issave1 = true;
        public static bool issave2 = false;

        public static int pix_h = 0;
        public static int pix_w = 0;
        public static string resolution = "";


        public static string DeviceName = "";
        public static string Device = "";
        public static short sIndex = 0;
        byte Data = new byte();
        int iDioRet = -1;
        int iRet = 0;
        public static bool bDetect = false;
        /// <summary>
        /// ViDi 関連
        /// </summary>
        ViDi2.IImage image2;
        ViDi2.FormsImage image3;

        ViDi2.IRedMarking RedMarking;

        public static double dScore = 0;
        public static bool bOkNg = false;
        public static int iTotal_Detect = 0;
        public static int iTotal_OK = 0;
        public static int iTotal_NG = 0;
        //ADD_START :2021/11/14 kitayama 理由：判定不可をカウントする変数を追加
        public static int iTotal_NOR = 0;
        //ADD_START :2021/11/14 kitayama 理由：判定不可をカウントする変数を追加

        public static int[] iOK = new int[11];
        public static int[] iNG = new int[11];

        float lBlankDisk = 0;

        public static int fBlankrate = 20;

        public static int logBlankrate = 60;

        string fext = "bmp";
        public static bool kishuselect = false;

        string stime;
        #endregion

        //ADD_START :2020/10/21 kitayama 処理時間計測のため追加
        System.Diagnostics.Stopwatch Detect_stopwatch = new Stopwatch();
        System.Diagnostics.Stopwatch Detect_stopwatch2 = new Stopwatch();
        System.Diagnostics.Stopwatch Detect_stopwatch3 = new Stopwatch();
        //ADD_END :2020/10/21 kitayama 処理時間計測のため追加

        #region コメントアウト
        //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
        //TEST 2021/11/3 kitayama カメラを接続せずに起動する場合はコメントアウトする？
        //CogDisplay cogDisplay = new CogDisplay();
        //public MX65ViDiDetecter.DispForm dispForm;
        //Bitmap image_s;
        //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除
        #endregion

        /// <summary>
        /// Gets or sets the main control providing access to the library
        /// </summary>
        public IControl Control
        {
            get { return control; }
            set
            {
                control = value;
                RaisePropertyChanged(nameof(Control));
            }
        }

        //ViDi検査で使用するStreamを設定する
        public IWorkspace Workspace
        {
            get { return workspace; }
            set
            {
                workspace = value;
                for (int i = 0; i < 11; i++)
                {
                    istream[i] = workspace.Streams[$"Stream {i + 1}"];
                }

                RaisePropertyChanged(nameof(Workspace));
            }
        }



        /// <summary>
        /// Gets or sets the current stream
        /// </summary>
        public IStream Stream
        {
            get { return stream; }
            set
            {
                stream = value;
                sampleViewer.Sample = null;
                RaisePropertyChanged(nameof(Stream));
            }
        }


        public ISampleViewer SampleViewer { get { return sampleViewer; } }


        /// <summary>
        /// メイン　ウインドウ
        /// </summary>
        public MainWindow()
        {
            logger.Info("MainWindow start");

            /// <summary>
            ///////////////////////////////////////////////////////////////////////////////////////////
            // 中川　PLC通信クラス確認用　後で削除
            PlcCommunication plcComm = new PlcCommunication();
            plcComm.varietyNo = 1;
            ///////////////////////////////////////////////////////////////////////////////////////////
            /// </summary>

            //TEST
            control = new ViDi2.Runtime.Local.Control();
            InitializeComponent();

            DataContext = this;

            sampleViewer.DragEnter += CheckDrop;
            sampleViewer.DragOver += CheckDrop;
            sampleViewer.Drop += DoDrop;
            sampleViewer.ToolSelected += sampleViewer_ToolSelected;

            #region コメントアウト
            //DELETE_START :2021/11/3 kitayama 理由：NGファイル保存チェックは使用しないので削除
            //fMoveFile.IsChecked = true;
            //Move_NG.IsChecked = false;
            //DELETE_END :2021/11/3 kitayama 理由：NGファイル保存チェックは使用しないので削除
            #endregion

            //TEST パスを仮に設定する
            //ADD_START :2022/1/9 kitayama 理由：保存先フォルダ格納変数に適当なパスを設定しておく処理を追加
            //パスが設定されていないと変数がnullでエラーとなるため
            sImagePath[0] = @"C:\1031test";
            sImagePath[1] = @"C:\1031test";
            sImagePath[2] = @"C:\1031test";
            sImagePath[3] = @"C:\1031test";
            sImagePath[4] = @"C:\1031test";
            sImagePath[5] = @"C:\1031test";
            //ADD_END :2022/1/9 kitayama 理由：保存先フォルダ格納変数に適当なパスを設定しておく処理を追加

            ///////////////////////////////////////////////////////////////////////////
            ///             初期値パラメタXMLファイル読み込み処理
            ///////////////////////////////////////////////////////////////////////////
            Change_XML change_XML;      //XML編集クラス
            change_XML = new Change_XML();
            //ADD_START :2022/1/9 kitayama 理由：設定ファイルが存在しない場合にxmlファイルを作成するため追加
            //ソフトの実行ファイルのパスを取得
            string apppath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!File.Exists(apppath + fileName))
            {
                //設定ファイルが存在しない場合のみ書き込み処理を行いファイルを作成する
                change_XML.WriteXML();
            }
            //ADD_END :2022/1/9 kitayama 理由：設定ファイルが存在しない場合にxmlファイルを作成するため追加
            change_XML.ReadXML();

            logger.Info("初期値パラメタXMLファイル読み込み完了");

            #region コメントアウト
            //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
            // 撮像画像取得用のフォーム
            //test1016
            //dispForm = new MX65ViDiDetecter.DispForm();
            //dispForm.Show(); //debug
            //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除
            #endregion

            //////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////////////
            ///                     画面表示 & パラメタ反映　処理
            /////////////////////////////////////////////////////////////////////////////


            Kishu_ComboBox.Items.Add("-");

            for (int i = 0; i < 10; i++)
            {
                logger.Info($"Main品種コンボボックスindex={i}、品種：{sKishu[i]}");
                Kishu_ComboBox.Items.Add(sKishu[i]);
            }


            for (int j = 0; j < 12; j++)
            {
                Houkou_Combo.Items.Add(houkou[j]);
            }
            Houkou_Combo.SelectedIndex = 1;

            #region コメントアウト
            //DELETE_START :2022/1/29 kitayama 理由：拡張子は使用しないので削除
            //拡張子選択リストの項目を追加
            //file_ex_box.Items.Add("bmp");
            //file_ex_box.Items.Add("jpg");
            //DELETE_END :2022/1/29 kitayama 理由：拡張子は使用しないので削除
            #endregion

            ////////////////////////////////////////////////////////////////
            ///                     画面表示 & パラメタ反映　チェック
            ///////////////////////////////////////////////////////////////

            //MEMO 2021/11/3 kitayama 取得先フォルダ（撮影画像保存先）とNG画像保存先フォルダを使用する



            //CHANGE_START :2021/11/27 kitayama 理由：画像保存先フォルダ名チェックをループ処理にするためforを追加し、配列の内容をチェックするように変更

            for (int j=0; j<sImagePath.Length;j++)
            {
                if (sImagePath[j] == "")
                {
                    logger.Error(" 保存先に何も入力されていない");
                    //ADD_START :2022/2/5 kitayama 理由：保存先が入力されていない場合のメッセージを追加
                    string path_err = "";
                    switch(j)
                    {
                        case 0:
                            path_err = "連続動作モード：OK";
                            break;
                        case 1:
                            path_err = "連続動作モード：判定不可";
                            break;
                        case 2:
                            path_err = "連続動作モード：NG";
                            break;
                        case 3:
                            path_err = "ワンショットモード：OK";
                            break;
                        case 4:
                            path_err = "ワンショットモード：判定不可";
                            break;
                        case 5:
                            path_err = "ワンショットモード：NG";
                            break;

                    }
                    //ADD_END :2022/2/5 kitayama 理由：保存先が入力されていない場合のメッセージを追加

                    MessageBoxResult result = MessageBox.Show($"{path_err}画像保存先が入力されていません。",
                    "保存先エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                    bInit = false;
                }
                else
                {
                    //2020.10.22 Y.Oushu Comment Out logger.Debug("保存先に何か入力されている ");

                    // nakagawa 2020/02/04 変更
                    //2022/2/5 kitayamaメイン画面が最新版で無かったのでエラーが発生していた。
                    //最新版にしたので元に戻した
                    //ADD_START :2022/2/1 kitayama 理由：警告表示の処理を追加
                    disk_warn.Visibility = Visibility.Hidden;
                    //ADD_END :2022/2/1 kitayama 理由：警告表示の処理を追加

                    string dSetImageDrive = sImagePath[j];

                    System.IO.DriveInfo drive = new System.IO.DriveInfo(dSetImageDrive);
                    if (drive.IsReady)
                    {
                        //2020.10.22 Y.Oushu Comment Out logger.Debug("drive.IsReady=true");


                        lBlankDisk = ((float)drive.TotalFreeSpace / (float)drive.TotalSize) * 100;

                        BlankDisk.Content = string.Format("{0:F1}", lBlankDisk);
                        logger.Info($"ディスク容量{drive.TotalSize},空き容量{drive.TotalFreeSpace},空き容量率{lBlankDisk}");

                        //ADD_START :2022/2/1 kitayama 理由：空き容量不足警告を表示する処理を追加
                        if (lBlankDisk < fBlankrate)
                        {
                            // nakagawa 2020/02/04 変更
                            //2022/2/5 kitayamaメイン画面が最新版で無かったのでエラーが発生していた。
                            //最新版にしたので元に戻した
                            disk_warn.Visibility = Visibility.Visible;
                        }
                        //ADD_END :2022/2/1 kitayama 理由：空き容量不足警告を表示する処理を追加

                    }

                    char[] invalidPathChars = Path.GetInvalidPathChars();

                    if (invalidPathChars.Any(ch => sImagePath[j].Contains(ch)))
                    {
                        logger.Error($"不正文字が存在する");

                        MessageBoxResult result = MessageBox.Show("画像保存先パスに不正文字が見つかりました。画像保存先パスを確認してください。",
                            "画像保存先 不正文字エラー",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        bInit = false;
                    }
                    else
                    {
                        //2020.10.22 Y.Oushu Comment Out logger.Debug("不正文字が含まれていない場合");

                        string[] stDrives = System.IO.Directory.GetLogicalDrives();
                        string sSetImageDrive = sImagePath[j].Substring(0, 3);
                        bool bFindDrive = false;

                        for (int i = 0; i < stDrives.Length; i++)
                        {
                            if (stDrives[i] == sSetImageDrive)
                            {
                                //2020.10.22 Y.Oushu Comment Out logger.Debug($"指定された論理ドライブが存在する setImage {sSetImageDrive}  stDrive {stDrives[i]}");
                                bFindDrive = true;
                                break;
                            }
                            else
                            {
                                //2020.10.22 Y.Oushu Comment Out logger.Debug($"指定された論理ドライブが存在しない setImage {sSetImageDrive}  stDrive {stDrives[i]}");
                                bFindDrive = false;
                            }
                        }
                        if (bFindDrive == true)
                        {
                            //2020.10.22 Y.Oushu Comment Out logger.Debug("指定されたドライブが存在する場合");
                            if ( Directory.Exists(sImagePath[j]) )
                            {
                                //bInit = bInit & true;
                            }
                            else
                            {
                                //MEMO :2021/11/27 kitayama 指定された保存先が存在しない場合はフォルダを作成する
                                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(sImagePath[j]);
                            }
                        }
                        else
                        {
                            logger.Error($"ドライブが存在しない場合");

                            MessageBoxResult result = MessageBox.Show("画像保存先パスに指定されたドライブが見つかりません。画像保存先パスを確認してください。",
                                "画像保存先 指定ドライブエラー",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                            bInit = false;
                        }
                    }
                    //2020.10.22 Y.Oushu Comment Out logger.Debug($"画像保存先チェック後bInit={bInit}");
                }
            }
            //ADD_END :2021/11/27 kitayama 理由：画像保存先フォルダ名チェック処理をループ処理にするためforを追加
            //保存先チェックここまで

            logger.Info("画面表示 & パラメタ反映　処理完了");

            /////////////////////////////////////////////////////////////////////////////
            ///        USB DIOデバイス初期化
            /////////////////////////////////////////////////////////////////////////////

            //MCプロトコル :2021/11/3 kitayama MCプロトコルの初期化処理はここに入れる
            //MEMO :2021/11/3 kitayama 初期化に問題がない場合はbInit=true、問題がある場合はbInit=falseとする

           

            ////2020.10.22 Y.Oushu Comment Out logger.Debug($"DIOデバイス初期化後 iDioRet={iDioRet}  bInit={bInit}");
            

            //TEST1016 初期設定フラグ
            bInit = true;

            //ADD_START :2021/11/3 kitayama 理由：初期設定に問題が無い場合のみ後のタイマー処理を起動する処理を追加
            if (bInit == true)
            {
                //初期設定に問題がない場合は画像検査部分のタイマー処理を開始する
                SetupTimer();
                //DELETE_START :2022/1/15 kitayama 理由：DIOは使用しないので削除
                //SetupTimer4:DIO入力解析用の処理
                //SetupTimer4();
                //DELETE_END :2022/1/15 kitayama 理由：DIOは使用しないので削除
                SetupTimer5();
                //ADD_START :2021/11/6 kitayama 理由：画像撮影用のタイマー処理を追加
                SetupTimer2();
                //ADD_END :2021/11/6 kitayama 理由：画像撮影用のタイマー処理を追加

                logger.Info("setuptimer起動");
            }
            else
            {
                logger.Info("初期設定に問題あり");
                //MEMO :2021/11/3 kitayama 初期設定に問題がある場合はメッセージを表示する
                //MEMO :2021/11/6 kitayama メッセージ表示後ソフトを終了する？

            }
            //ADD_END :2021/11/3 kitayama 理由：初期設定に問題が無い場合のみ後のタイマー処理を起動する処理を追加


            //閾値設定画面のパスワード保存ファイルが存在しない場合はファイルを作成する
            if (File.Exists(apppath + "Password.ini"))
            {

            }
            else
            {
                //ファイルが存在しない場合は新規ファイル作成＋0525を書き込む
                File.WriteAllText(apppath + "Password.ini", "0525");
                logger.Info("iniファイル作成　パス：0525");
            }

            if (bInit == true)
            {
                //DELETE_START :2022/1/9 kitayama 理由：DIOの処理を削除
                //iRet = dio.OutBit(sIndex, 0, 1);
                ////2020.10.22 Y.Oushu Comment Out logger.Debug("初期設定完了　REDYをON");
                //ellipse_out0.Fill = System.Windows.Media.Brushes.Lime;
                //DELETE_END :2022/1/9 kitayama 理由：DIOの処理を削除
            }
            else
            {
                //DELETE_START :2022/1/9 kitayama 理由：DIOの処理を削除
                //iRet = dio.OutBit(sIndex, 0, 0);
                ////2020.10.22 Y.Oushu Comment Out logger.Debug("初期設定異常　REDYをOFF");
                //ellipse_out0.Fill = System.Windows.Media.Brushes.Red;
                //DELETE_END :2022/1/9 kitayama 理由：DIOの処理を削除
            }

            //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
            //test1016 カメラ名を取得
            //camname_label.Text = dispForm.AcqFifoTool.Operator.FrameGrabber.Name;
            //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除

            //ADD_START :2021/10/31 kitayama 理由：ファイル名を仮に代入する処理を追加
            foldername3 = @"C:\1031test";
            //ADD_END :2021/10/31 kitayama 理由：ファイル名を仮に代入する処理を追加


            //ADD_START :2021/12/22 kitayama 理由：総合判定の初期化を追加
            //総合判定を初期化
            okng_largelabel.Content = "-";
            //ADD_END :2021/12/22 kitayama 理由：総合判定の初期化を追加

            //v_kekkaの判定に使用する定数を決定する
            V_CONST[0] = 0;
            //NORの時に格納
            V_CONST[1] = 1;
            //NGの時に格納
            V_CONST[2] = ANALYZE_NUM * V_CONST[1] + 1;
            //エラーなどの時に格納?
            V_CONST[3] = ANALYZE_NUM * V_CONST[2] + 1;
            
            //判定結果のみ集計時の処理を考慮して初期値を変えている
            for (int j = 0; j < v_kekka.GetLength(1); j++)
            {
                for (int k = 0; k < v_kekka.GetLength(2); k++)
                {
                    v_kekka[0, j, k] = 0;
                    v_kekka[1, j, k] = v_initial;
                    v_kekka[2, j, k] = 0;

                    //v_kekka[x,y,z] x:格納するデータ種別　y:使用Analyze　z:処理画像の枚数
                    //1/12 インデックス見直し v_kekka[3,10,100]
                }
            }
            //ADD_END :2021/11/3 kitayama 理由：結果表示の初期化処理を追加
            //ADD_START :2021/11/3 kitayama 理由：結果表示の初期化処理を追加
            for(int j = 0; j < sum_kekka2.Length; j++)
            {
                sum_kekka2[j] = 0;
            }
            //ADD_END :2021/11/3 kitayama 理由：結果表示の初期化処理を追加

            //ADD_START :2021/11/14 kitayama 理由：bmpimagesを初期化する処理を追加
            for(int j=0;j<bmpimages.Length;j++)
            {
                bmpimages[j] = null;
            }
            //ADD_END :2021/11/14 kitayama 理由：bmpimagesを初期化する処理を追加

            //ADD_START :2021/12/2 kitayama 理由：初期設定時にDetectstart()でソフト起動と同時に検査開始状態にする処理を追加
            //TEST :2022/1/12
            //DetectStart();
            //DetectButton.IsEnabled = false;
            //ADD_END :2021/12/2 kitayama 理由：初期設定時にDetectstart()でソフト起動と同時に検査開始状態にする処理を追加

            //2020.10.22 Y.Oushu Add 画面表示
            this.Visibility = Visibility.Visible;

        }

        //ソフト起動時の初期設定処理ここまで


        /// <summary>
        /// 画像を取得し、画像をViDiに渡す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTimerMethod(object sender, EventArgs e)
        {
            //ADD_START :2021/11/13 kitayama 理由：判定フラグを追加
            Hanntei h_flag = Hanntei.NG;
            //ADD_START :2021/11/13 kitayama 理由：判定フラグを追加


            //ADD_START :2019/11/1 kawabata 理由：Try　Catch処理の追加
            try
            {
                #region コメントアウト
                //DELETE_START :2021/12/20 kitayama 理由：カメラ情報は使用しないので削除
                //TEST1016　解像度などを取得する　カメラ未接続時はコメントアウトする
                //resolution_label.Content = resolution;
                //shutter_label.Content = iShutterspeed;
                //brightness_label.Content = iBrightness;
                //DELETE_END :2021/12/20 kitayama 理由：カメラ情報は使用しないので削除

                //画像処理部で使用するフラグ
                //bInit：初期設定完了フラグ　detect_on：検査開始フラグ
                //scoreflag：スコア、判定表示初期化フラグ　aflag：Stream,Analyze処理終了フラグ
                #endregion

                //ADD_START :2021/11/14 kitayama 理由：検査開始判定処理を追加
                //画像が取り込まれているならば処理を開始する
                if (bmpimages[v_num] != null)
                {
                    vidiflag = true;
                    //MCプロトコル　検査処理開始でREADY信号をOFFにする

                    //ADD_START :2021/11/21 kitayama 理由；Streamの選択設定を追加
                    try
                    {
                        //インデックスに撮影方向を格納
                        if (ihoukou == 0)
                        {
                            //方向信号が0（無入力）の場合はコンボボックスの入力を反映する
                            //ihoukou = 0となるのは無入力かつ初回の処理時のみのはず
                            ihoukou = Houkou_Combo.SelectedIndex;
                        }
                        else
                        {
                            //方向信号が入力された場合は信号を反映する
                            Houkou_Combo.SelectedIndex = ihoukou;

                        }
                    }
                    catch (Exception ex)
                    {
                        //ログ表示と、画面表示。
                        logger.Fatal(ex.StackTrace);
                        logger.Fatal("撮影方向が12以上が選択されました。\n選択可能範囲は1～11までです。");
                        //ERR_LABEL.Content = "撮影方向が12以上が選択されました。\n選択可能範囲は1～11までです。";
                        //return;
                    }
                    ////2020.10.22 Y.Oushu Add Try Catch の追加(撮影方向、品種例外処理) End

                    snum = ihoukou - 1;

                    if (snum < 0 | 11 <snum)
                    {
                        vidiflag = false;
                        //撮影方向が不適切な場合にエラーを表示する
                        MessageBoxResult result = MessageBox.Show("撮影方向エラーです。撮影方向の入力を確認してください。",
                                                                  "撮影方向エラー",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                    //ADD_END :2021/11/21 kitayama 理由；Streamの選択設定を追加

                }
                //ADD_END :2021/11/14 kitayama 理由：検査開始判定処理を追加

                //取得したファイルをViDiに渡して判定結果を受け取る
                //ADD_START :2021/11/6 kitayama 理由：ViDi処理部を追加
                if (vidiflag == true)
                {
                    //ADD_START :2022/1/25 kitayama 理由：判定結果表示用のスタックを追加
                    Stack<string> ng_text = new Stack<string>();
                    Stack<string> inter_text = new Stack<string>();
                    //ADD_END :2022/1/25 kitayama 理由：判定結果表示用のスタックを追加

                    //ADD_START :2021/11/13 kitayama 理由；：判定結果を格納する列挙子を追加
                    //判定結果判別処理で使用するフラグ
                    Hanntei v_hanntei = Hanntei.OK;
                    //個別の画像の判定結果を格納し画面に表示するためのフラグ
                    Hanntei k_hanntei = Hanntei.OK;
                    //ADD_END :2021/11/13 kitayama 理由；：判定結果を格納する列挙子を追加
                    //ADD_START :2021/11/14 kitayama 理由：検査結果を画面表示する際に使用する変数を追加
                    string meisyou_temp = "";
                    //ADD_END :2021/11/14 kitayama 理由：検査結果を画面表示する際に使用する変数を追加

                    vidiflag = false;

                    logger.Info($"取得部　image2! = null　画像処理部開始");

                    //CHANGE_START :2021/11/1 kitayama 理由：通常の処理をリセット処理用のif文から抜き出した

                    //ViDiに画像を渡す処理部分
                    //処理用の画像を取得
                    //TEST 2022/1/16 カメラを使用する場合に使用する処理
                    //カメラなしでデバッグする際はコメントアウトする
                    //image3 = new ViDi2.FormsImage(bmpimages[v_num]);

                    //ADD_START :2021/11/13 kitayama 理由：Analyzeを複数使用するためのループ処理を追加
                    //すべてのAnalyze処理が終了する or 途中でNGが出る or しきい値の下限が-1ならばループを終了する
                    //CHANGE_START :2022/1/18 kitayama 理由：判定条件が間違っていたので変更
                    for (int a_index = 0; a_index < ANALYZE_NUM && v_hanntei != Hanntei.NG && dThreshold3[1, selectedItem - 1, snum, a_index] != -1; a_index++)
                    //for (int a_index = 0; a_index < ANALYZE_NUM | v_hanntei==Hanntei.NG | dThreshold3[1, selectedItem - 1, snum, a_index] != -1 ; a_index++)
                    //CHANGE_END :2022/1/18 kitayama 理由：判定条件が間違っていたので変更
                    {
                        //ADD_END :2021/11/13 kitayama 理由：Analyzeを複数使用するためのループ処理を追加
                        //snumに撮影方向を格納している

                        //a_index：使用するAnalyzeの番号
                        //TEST 0117 カメラなしのデバッグではimage2を使用する。カメラありではimage3を使う。
                        sampleViewer.Sample = istream[snum].Tools[$"Analyze {a_index}"].Process(image2);

                        //sampleViewer.Sample = istream[snum].Tools[$"Analyze {a_index}"].Process(image3);

                        RedMarking = sampleViewer.Sample.Markings[$"Analyze {a_index}"] as ViDi2.IRedMarking;
                        

                        //MEMO :2021/11/23 kitayama 理由：Analyzeに検査名称を設定する場合はTools[ a_meisyou[a_index] ]とする

                        //CHANGE_START :2021/10/31 kitayama 理由：Kekkaに渡す変数を変更
                        //Kekka(dThreshold2[selectedItem - 1, snum, anum], RedMarking,str_f);
                        v_hanntei = (Hanntei)Kekka(dThreshold3[0, selectedItem - 1, snum, a_index], dThreshold3[1, selectedItem - 1, snum, a_index], v_hanntei, RedMarking);
                        //CHANGE_END :2021/10/31 kitayama 理由：Kekkaに渡す変数を変更

                        //ViDiの処理ができていない(RedMarking==null)場合、dScore=999となる
                        //結果保存配列にスコア格納と画面表示を行う　スコアは下2桁まで表示する
                        v_kekka[1, a_index, v_num] = Math.Round(dScore, 2, MidpointRounding.AwayFromZero);
                        //score_label1.Content = Math.Round(dScore, 2, MidpointRounding.AwayFromZero);

                        //画像個別の検査処理時間を格納する
                        //Detect_stopwatch.Stop();
                        //v_kekka[3, a_index, v_num] = (double)Detect_stopwatch.ElapsedMilliseconds;
                        //DELETE_START :2021/11/14 kitayama 理由：処理時間表示は一旦削除
                        //DetectTimeLabel.Content = Detect_stopwatch.ElapsedMilliseconds;
                        //DELETE_END :2021/11/14 kitayama 理由：処理時間表示は一旦削除
                        //総合判定が確定するまでの処理時間を表示する
                        //processingtime += v_kekka[3, a_index, v_num];
                        //合計処理時間は秒を単位にする
                        //合計処理時間を表示する場合はコメントアウトする
                        //sum_DetectTimeLabel.Content = Math.Round(processingtime/1000, MidpointRounding.AwayFromZero);
                        //Detect_stopwatch.Reset();

                        //ADD_START :2019/11/18 kitayama 理由：RedMarking Kekkaで処理が飛んでいるか確認するため
                        logger.Debug("RedMarking Kekka このメッセージだけなら処理が飛ばされている");
                        //ADD_END :2019/11/18 kitayama 理由：RedMarking Kekkaで処理が飛んでいるか確認するため

                        //ADD_START :2021/11/136 kitayama 理由：判定不可に対応した結果処理を追加
                        //判定結果に応じてv_kekka[2,,]に結果を格納する
                        switch (v_hanntei)
                        {
                            case Hanntei.OK:
                                v_kekka[2, a_index, v_num] = V_CONST[0];
                                //1枚目の検査時にOKを表示する。NGやエラーが出なければOK表示のまま検査が終了する。

                                //DELETE_START :2021/11/23 kitayama 理由：判定結果処理を1121処理フローと合わせるため削除
                                //if (v_num == 0)
                                //{
                                //    //検査終了までOKは確定しないので、暫定の意味で表示は白にする
                                //    okng_largelabel.Content = "OK";
                                //    okng_largelabel.Foreground = new SolidColorBrush(Colors.White);
                                //    h_flag = Hanntei.OK;
                                //}
                                //DELETE_END :2021/11/23 kitayama 理由：判定結果処理を1121処理フローと合わせるため削除
                                break;

                            case Hanntei.NOR:
                                v_kekka[2, a_index, v_num] = V_CONST[1];
                                logger.Debug($"取得部判定表示 判定：判定不可");

                                //hanntei_numが0で無い場合は判定不可とする
                                //ADD_START :2021/11/23 kitayama 理由：判定結果を格納する処理を追加
                                hanntei_num++;
                                //ADD_END :2021/11/23 kitayama 理由：判定結果を格納する処理を追加

                                //ADD_START :2022/2/3 kitayama 理由：総合判定を格納する処理を追加
                                if (h_flag != Hanntei.NG)
                                {
                                    //現在の総合判定がNG以外なら、総合判定を判定不可に更新する
                                    h_flag = Hanntei.NOR;
                                }
                                //ADD_END :2022/2/3 kitayama 理由：総合判定を格納する処理を追加

                                //DELETE_START :2022/2/2 kitayama 理由：結果表示はスタックを使用するので削除
                                ////ADD_START :2021/12/4 kitayama 理由：判定結果表示処理を追加
                                ////結果がテキストボックスの上に追加されていくようにする
                                ////配列の内容を1つ後ろにずらす
                                //for (int j = inter_imagetext.Length - 1; 0 < j; j--)
                                //{
                                //    inter_imagetext[j] = inter_imagetext[j - 1];
                                //}
                                ////配列の先頭に結果を追加
                                ////CHANGE_START :2021/12/22 kitayama 理由：a_meisyouは使用しないので変更
                                //inter_imagetext[0] = $"{v_num} Analyze{a_index} 判定不可";
                                ////inter_imagetext[0] = $"{v_num} {a_meisyou[selectedItem - 1, snum, a_index]} 判定不可";
                                ////CHANGE_END :2021/12/22 kitayama 理由：a_meisyouは使用しないので変更
                                //DELETE_END :2022/2/2 kitayama 理由：結果表示はスタックを使用するので削除

                                //ADD_START :2022/1/25 kitayama 理由：判定結果をスタックに入れる処理を追加
                                inter_text.Push($"{v_num} Analyze{a_index} 判定不可");
                                //ADD_END :2022/1/25 kitayama 理由：判定結果をスタックに入れる処理を追加


                                //DELETE_START :2022/1/25 kitayama 理由：テキストボックスへの出力は後でまとめて行うので削除
                                ////テキストボックスに表示する
                                //for (int j = 0; j < inter_imagetext.Length ; j++)
                                //{
                                //    textbox_Inter.Text += inter_imagetext[j] + "\r\n";
                                //}
                                //DELETE_INTER :2022/1/25 kitayama 理由：テキストボックスへの出力は後でまとめて行うので削除
                                
                                //ADD_END :2021/12/4 kitayama 理由：判定結果表示処理を追加
                                //DELETE_START :2021/11/23 kitayama 理由：判定結果処理を1121処理フローと合わせるため削除
                                ////ADD_START :2021/11/14 kitayama 理由：個別の結果表示に使用する処理を追加
                                //k_hanntei = Hanntei.NOR;
                                //if (meisyou_temp == "")
                                //{
                                //    //最初に判定不可を出したanalyzeの名称を保持する
                                //    meisyou_temp = a_meisyou[a_index];
                                //}
                                ////ADD_END :2021/11/14 kitayama 理由：個別の結果表示に使用する処理を追加

                                //if (errflag == true)
                                //{
                                //    //エラーが発生しているときは表示を変えない
                                //}
                                //else
                                //{
                                //    if (h_flag != Hanntei.NG)
                                //    {
                                //        //NG,エラーが発生していない時のみ表示をOKから判定不可に変える
                                //        //個別判定がNGの場合は総合判定もNGで確定なので判定の表示色を黄色にする
                                //        okng_largelabel.Content = "判定不可";
                                //        okng_largelabel.Foreground = new SolidColorBrush(Colors.Yellow);
                                //        h_flag = Hanntei.NOR;
                                //    }
                                //}
                                //DELETE_END :2021/11/23 kitayama 理由：判定結果処理を1121処理フローと合わせるため削除
                                break;

                            case Hanntei.NG:
                                v_kekka[2, a_index, v_num] = V_CONST[2];
                                logger.Debug($"取得部判定表示 判定：NG");

                                //ADD_START :2022/2/3 kitayama 理由：総合判定を格納する処理を追加
                                h_flag = Hanntei.NG;
                                //ADD_END :2022/2/3 kitayama 理由：総合判定を格納する処理を追加

                                //DELETE_START :2022/2/2 kitayama 理由：結果表示はスタックを使用するので削除
                                ////ADD_START :2021/12/4 kitayama 理由：判定結果表示処理を追加
                                ////結果がテキストボックスの上に追加されていくようにする
                                ////配列の内容を1つ後ろにずらす
                                //for (int j = ng_imagetext.Length - 1; 0 < j; j--)
                                //{
                                //    ng_imagetext[j] = ng_imagetext[j - 1];
                                //}
                                ////配列の先頭に結果を追加
                                ////CHANGE_START :2021/12/22 kitayama 理由：a_meisyouは使用しないので変更
                                //ng_imagetext[0] = $"{v_num} Analyze{a_index} NG";
                                ////ng_imagetext[0] = $"{v_num} {a_meisyou[selectedItem - 1, snum, a_index]} NG";
                                ////CHANGE_END :2021/12/22 kitayama 理由：a_meisyouは使用しないので変更
                                //DELETE_END :2022/2/2 kitayama 理由：結果表示はスタックを使用するので削除

                                //ADD_START :2022/1/25 kitayama 理由：判定結果をスタックに入れる処理を追加
                                ng_text.Push($"{v_num} Analyze{a_index} NG");
                                //ADD_END :2022/1/25 kitayama 理由：判定結果をスタックに入れる処理を追加

                                //DELETE_START :2022/1/25 kitayama 理由：テキストボックスへの出力は後でまとめて行うので削除
                                ////テキストボックスに表示する
                                //for (int j = 0; j < ng_imagetext.Length; j++)
                                //{
                                //    textbox_NG.Text += ng_imagetext[j] + "\r\n";
                                //}
                                //DELETE_END :2022/1/25 kitayama 理由：テキストボックスへの出力は後でまとめて行うので削除
                                //ADD_END :2021/12/4 kitayama 理由：判定結果表示処理を追加

                                //CHANGE_START :2021/11/23 kitayama 理由：1121処理フローと合わせるため変更
                                //ADD_START :2021/11/14 kitayama 理由：個別の結果表示に使用する処理を追加
                                //k_hanntei = Hanntei.NG;
                                //meisyou_temp = a_meisyou[a_index];
                                //ADD_END :2021/11/14 kitayama 理由：個別の結果表示に使用する処理を追加
                                //CHANGE_END :2021/11/23 kitayama 理由：1121処理フローと合わせるため変更

                                //DELETE_START :2021/11/23 kitayama 理由：判定結果処理を1121処理フローと合わせるため削除
                                //if (errflag == true)
                                //{
                                //    //エラーが発生しているときは表示を変えない
                                //}
                                //else
                                //{
                                //    //エラーが発生していない時のみ表示をOKからNGに変える
                                //    //個別判定がNGの場合は総合判定もNGで確定なので判定の表示色を赤にする
                                //    okng_largelabel.Content = "NG";
                                //    okng_largelabel.Foreground = new SolidColorBrush(Colors.Red);
                                //}
                                ////NGが出たときにNGフラグを立てる
                                //h_flag = Hanntei.NG;
                                //DELETE_END :2021/11/23 kitayama 理由：判定結果処理を1121処理フローと合わせるため削除

                                break;
                        }
                        //ADD_END :2021/11/136 kitayama 理由：判定不可に対応した結果処理を追加

                        
                        //ADD_START :2021/11/13 kitayama 理由：Analyzeを複数使用するためのループ処理を追加
                    }
                    //ADD_END :2021/11/13 kitayama 理由：Analyzeを複数使用するためのループ処理を追加
                    //Analyze用forループここまで

                    //ADD_START :2021/11/25 kitayama 理由：1121処理フローと合わせた表示処理を追加

                    //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                    string path_save = "";
                    //ADD_END :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加

                    //ViDi処理のループを抜けた後にテキストボックスに結果を表示する処理
                    if (v_hanntei==Hanntei.NG)
                    {
                        //個別画像判定：NG
                        //DELETE_START :2022/1/26 kitayama 理由：結果表示はスタックを利用するので削除
                        //ADD_START :2021/12/4 kitayama 理由：判定結果表示処理を追加
                        //結果がテキストボックスの上に追加されていくようにする
                        //配列の内容を1つ後ろにずらす
                        //for (int j = ng_imagetext.Length - 1; 0 < j; j--)
                        //{
                        //    ng_imagetext[j] = ng_imagetext[j - 1];
                        //}
                        ////配列の先頭に結果を追加
                        //ng_imagetext[0] = $"{v_num} NG";
                        //textbox_NG.Clear();

                        ////テキストボックスに表示する
                        //for (int j = 0; j < ng_imagetext.Length; j++)
                        //{
                        //    textbox_NG.Text += ng_imagetext[j] + "\r\n";
                        //}
                        ////ADD_END :2021/12/4 kitayama 理由：判定結果表示処理を追加
                        //DELETE_END :2022/1/26 kitayama 理由：結果表示はスタックを利用するので削除

                        //ADD_START :2022/1/25 kitayama 理由：スタックから結果を表示する処理を追加
                        ng_text.Push($"画像{v_num} NG");
                        while (ng_text.Count > 0)
                        {
                            textbox_NG.Text += ng_text.Pop()+"\r\n";
                        }
                        //ADD_END :2022/1/25 kitayama 理由：スタックから結果を表示する処理を追加
                        //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                        //ワンショットモードでは5を設定する
                        path_save = sImagePath[2];
                        //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                    }
                    else if(0<hanntei_num & hanntei_num < ANALYZE_NUM)
                    {
                        //個別画像判定：判定不可

                        //DELETE_START :2022/1/26 kitayama 理由：結果表示はスタックを利用するので削除
                        ////ADD_START :2021/12/4 kitayama 理由：判定結果表示処理を追加
                        //for (int j = inter_imagetext.Length - 1; 0 < j; j--)
                        //{
                        //    inter_imagetext[j] = inter_imagetext[j - 1];
                        //}
                        ////配列の先頭に結果を追加
                        //inter_imagetext[0] = $"画像{v_num} 判定不可";
                        //textbox_Inter.Clear();

                        //for (int j = 0; j < inter_imagetext.Length; j++)
                        //{
                        //    textbox_Inter.Text += inter_imagetext[j] + "\r\n";
                        //}
                        //ADD_END :2021/12/4 kitayama 理由：判定結果表示処理を追加
                        //DELETE_END :2022/1/26 kitayama 理由：結果表示はスタックを利用するので削除

                        //ADD_START :2022/1/25 kitayama 理由：スタックから結果を表示する処理を追加
                        inter_text.Push($"画像{v_num} 判定不可");
    
                        while (inter_text.Count > 0)
                        {
                            textbox_Inter.Text += inter_text.Pop() + "\r\n";
                        }
                        //ADD_END :2022/1/25 kitayama 理由：スタックから結果を表示する処理を追加
                        //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                        //ワンショットモードでは4を設定する
                        path_save = sImagePath[1];
                        //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加

                    }
                    else if(hanntei_num==0)
                    {
                        //個別画像判定：OK
                        //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                        //ワンショットモードでは3を設定する
                        path_save = sImagePath[0];
                        //ADD_START :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                    }

                    //一旦ここで保存する。処理速度が遅くなるようならここで保存用配列に格納して、保存処理自体は別スレッドに分ける。
                    //ADD_START :2021/11/27 kitayama 理由：画像の保存処理を追加

                    //ADD_END :2022/2/5 kitayama 理由：画像の保存先を設定する処理を追加
                    //CHANGE_START :2022/2/5 kitayama 理由：ファイル名に年月日を追加した形式に変更
                    //ADD_START :2022/1/26 kitayama 理由：カメラで撮影した画像をbmpで保存する処理を追加
                    //カメラから画像を取り込む場合はこちらの処理を使用する
                    //bmpimages[v_num].Save(path_save + DateTime.Now.ToString("yyyyMMdd-HHmmssfff") + "." + fext, System.Drawing.Imaging.ImageFormat.Bmp);
                    //bmpimages[v_num].Save(sImagePath[(int)v_hanntei] + DateTime.Now.ToString() + "." + fext, System.Drawing.Imaging.ImageFormat.Bmp);
                    //ADD_END :2022/1/26 kitayama 理由：カメラで撮影した画像をbmpで保存する処理を追加

                    //TEST カメラなしでフォルダから画像を取得する場合の保存処理
                    //File.Move(d_files[0], $@"C:\1031test\{DateTime.Now.ToString()}.{fext}");
                    File.Move(d_files[0], $@"{path_save}\NG_image{v_num}_{DateTime.Now.ToString($"yyyyMMdd-HHmmssfff")}.{fext}");
                    //File.Move(d_files[0], $@"C:\1031test\NG_image{v_num}_{DateTime.Now.ToString($"MMdd-HHmmssfff")}.{fext}");
                    //CHANGE_END :2022/2/5 kitayama 理由：ファイル名に年月日を追加した形式に変更
                    //DELETE_START :2021/12/22 kitayama 理由：すべての画像を保存するのでif文を削除
                    //}
                    //DELETE_END :2021/12/22 kitayama 理由：すべての画像を保存するのでif文を削除
                    //bmpimages[v_num].Save(foldername3 + DateTime.Now.ToString($"{ s_meisyou[selectedItem - 1, snum] }NG_MMdd-HHmmssfff"), System.Drawing.Imaging.ImageFormat.Bmp);
                    //ADD_END :2021/11/27 kitayama 理由：画像の保存処理を追加


                    hanntei_num = 0;
                    //ADD_END :2021/11/25 kitayama 理由：1121処理フローと合わせた表示処理を追加

                    //判定処理が終了してから処理画像数をカウントする
                    v_num++;

                    //検査終了でなければ次の画像の検査に移る
                    //ADD_START :2021/11/23 kitayama 理由：検査終了判定を追加
                    if (shot_index <= v_num)
                    {
                        //撮影した画像数 <= 検査画像数　となった場合に終了フラグを立てる
                        endflag = true;
                    }
                    //ADD_END :2021/11/23 kitayama 理由：検査終了判定を追加

                    //ViDiが画像を取得できていない場合のエラー処理
                    if (sampleViewer.Sample == null && str2 != null)
                    {

                        logger.Error($"取得部 　(sampleViewer.Sample=null && str2!=null) = true エラー：ViDi　ToolからNULLで戻ってきました。検査画像を確認してください。");
                    }
                    else
                    {
                        logger.Debug($"取得部　(sampleViewer.Sample=null && str2!=null) = false");
                    }

                    logger.Debug($"ViDi処理終了");

                    //メモリを解放する
                    //CHANGE_START :2021/11/13 kitayama 理由：image2をimage3に変更
                    //image2.Dispose();
                    //imgae3はDisposeできない
                    sampleViewer.Sample.Dispose();
                    //image2 = null;
                    image3 = null;
                    System.GC.Collect();
                    //CHANGE_END :2021/11/13 kitayama 理由：image2をimage3に変更


                }
                //ADD_END :2021/10/31 kitayama 理由：ViDi処理部を追加
                //ViDi処理部ここまで


                //MEMO :2021/11/13 kitayama 画像をメモリに取り込むのでNG、判定不可の保存動作のみを行う
                //MEMO　インデックスの処理などを考えるとViDi処理か検査終了に統合したほうがよさそう。
                //画像保存は終了処理にまとめるか？　ViDi処理では結果の格納のみを行い、終了処理でまとめて保存する
                //ViDi処理に保存処理を追加するとコードが複雑になり、機能面でもわかりにくくなりそうなので


                //検査終了処理
                //ADD_START :2021/11/1 kitayama 理由：検査終了処理を追加
                if (endflag == true)
                {
                    logger.Info("検査終了　総合判定表示と初期化処理");
                    //終了フラグを落とす
                    endflag = false;

                    #region コメントアウト
                    //DELETE_START :2021/11/13 kitayama 理由：ファイル数確認は行わないので削除
                    //f_countflag = true;
                    //DELETE_END :2021/11/13 kitayama 理由：ファイル数確認は行わないので削除


                    //2022/1/26 保存処理は1500あたりで前画像を保存するようにしているのでここの処理は不要のはず。
                    //ADD_START :2021/11/13 kitayama 理由：ファイル保存処理を追加
                    //v_kekka[2,n,n]の各画像の判定結果を合計する
                    //for(int j = 0; j < v_kekka.GetLength(2) ;j++)
                    //{
                    //    for (int k = 0; k < ANALYZE_NUM | v_kekka[2,k,j] != v_initial ; k++)
                    //    {
                    //        sum_kekka2[j] += (int)v_kekka[2, k, j];
                    //    }
                    //}

                    ////sum_kekka2の内容から、判定不可、NGとなった画像を調べて保存する
                    //for(int j =0; j<sum_kekka2.Length;j++)
                    //{
                    //    int an_index = 0;

                    //    if(sum_kekka2[j]==0)
                    //    {
                    //        //OK
                    //    }
                    //    else if(V_CONST[1] <= sum_kekka2[j]  & sum_kekka2[j] <= (V_CONST[2]-1) )
                    //    {
                    //        //NOR
                    //        //判定不可として保存
                    //        //最初に判定不可となったAnalyzeの番号を調べる
                    //        for(int k = 0; k < ANALYZE_NUM; k++)
                    //        {
                    //            if (v_kekka[2, k, j] == V_CONST[1])
                    //            {
                    //                an_index = k;
                    //            }
                    //        }
                    //        bmpimages[j].Save(foldername3 + DateTime.Now.ToString($"Analyze{an_index}判定不可_MMdd-HHmmssfff"), System.Drawing.Imaging.ImageFormat.Bmp);

                    //    }
                    //    else if(V_CONST[2] <= sum_kekka2[j] & sum_kekka2[j] <= (V_CONST[2]-1) )
                    //    {
                    //        //NG
                    //        //NGとして保存
                    //        //最初にNGとなったAnalyzeの番号を調べる
                    //        for (int k = 0; k < ANALYZE_NUM; k++)
                    //        {
                    //            if (v_kekka[2, k, j] == V_CONST[1])
                    //            {
                    //                an_index = k;
                    //            }
                    //        }
                    //        bmpimages[j].Save(foldername3 + DateTime.Now.ToString($"Analyze{an_index}NG_MMdd-HHmmssfff"), System.Drawing.Imaging.ImageFormat.Bmp);
                    //    }
                    //    else if(V_CONST[3] <= sum_kekka2[j])
                    //    {
                    //        //エラーなど
                    //    }

                    //}
                    //画像保存処理ここまで
                    //ADD_END :2021/11/13 kitayama 理由：ファイル保存処理を追加
                    #endregion

                    //ADD_START :2022/2/1 kitayama 理由：保存先の容量を確認する処理を追加
                    for (int j = 0; j < sImagePath.Length; j++)
                    {
                        lBlankDisk = 0;

                        System.IO.DriveInfo drive = new System.IO.DriveInfo(sImagePath[j]);
                        if (drive.IsReady)
                        {

                            lBlankDisk = ((float)drive.TotalFreeSpace / (float)drive.TotalSize) * 100;
                        }

                        if( lBlankDisk < fBlankrate ) 
                        {
                            // nakagawa 2020/02/04 変更
                            //2022/2/5 kitayamaメイン画面が最新版で無かったのでエラーが発生していた。
                            //最新版にしたので元に戻した
                            disk_warn.Visibility = Visibility.Visible;
                        }

                    }
                        //ADD_END :2022/2/1 kitayama 理由：保存先の容量を確認する処理を追加

                        //OK/NG数のカウント処理
                        //CHANGE_START :2021/11/13 kitayama 理由：NGフラグの条件を変更
                        //if (ngflag == true || errflag == true)
                    if (h_flag == Hanntei.NG || errflag == true)
                    //CHANGE_END :2021/11/13 kitayama 理由：NGフラグの条件を変更
                    {
                        //NG・エラーが出ている場合はNGをカウント
                        iTotal_NG++;

                        //ADD_START :2022/2/3 kitayama 理由：総合判定を表示する処理を追加
                        okng_largelabel.Content = "NG";
                        okng_largelabel.Foreground = new SolidColorBrush(Colors.Red);
                        //ADD_END :2022/2/3 kitayama 理由：総合判定を格納する処理を追加

                    }
                    else if(h_flag==Hanntei.NOR && errflag == false)
                    {
                        //判定不可をカウント
                        iTotal_NOR++;

                        //ADD_START :2022/2/3 kitayama 理由：総合判定を表示する処理を追加
                        okng_largelabel.Content = "判定不可";
                        okng_largelabel.Foreground = new SolidColorBrush(Colors.White);
                        //ADD_END :2022/2/3 kitayama 理由：総合判定を表示する処理を追加

                    }
                    //CHANGE_START :2021/11/13 kitayama 理由：NGフラグの条件を変更
                    //else if (ngflag == false && errflag == false)
                    else if (h_flag == Hanntei.OK && errflag == false)
                    //CHANGE_END :2021/11/13 kitayama 理由：NGフラグの条件を変更
                    {
                        //NGもエラーも出てない場合はOKをカウント
                        iTotal_OK++;
                        //ADD_START :2022/2/3 kitayama 理由：総合判定を表示する処理を追加
                        okng_largelabel.Content = "OK";
                        okng_largelabel.Foreground = new SolidColorBrush(Colors.Lime);
                        //ADD_END :2022 / 2 / 3 kitayama 理由：総合判定を表示する処理を追加

                        //DELETE_START :2021/11/23 kitayama 理由：表示はしないので削除
                        //ここで総合判定が確定するので表示色を緑にする
                        //okng_largelabel.Foreground = new SolidColorBrush(Colors.Lime);
                        //DELETE_END :2021/11/23 kitayama 理由：表示はしないので削除
                    }
                    //検査数をカウントして画面表示
                    iTotal_Detect = iTotal_NG +iTotal_NOR+ iTotal_OK;
                    //ADD_START :2021/11/7 kitayama 理由：検査数表示を追加
                    OK_Images_Label.Content = iTotal_OK;
                    NOR_Images_Label.Content = iTotal_NOR;
                    NG_Images_Label.Content = iTotal_NG;
                    Total_Images_Label.Content = iTotal_Detect;
                    //ADD_END :2021/11/7 kitayama 理由：検査数表示を追加

                    //NGフラグとエラーフラグはここで初期化し、検査中はNG判定やエラーが出たとき以外変更しない
                    //CHANGE_START :2021/11/13 kitayama 理由：ngflagをh_flagに変更
                    //ngflag = false;
                    h_flag = Hanntei.NG;
                    //CHANGE_END :2021/11/13 kitayama 理由：ngflagをh_flagに変更
                    errflag = false;
                    //ADD_START :2021/11/14 kitayama 理由：v_numを初期化する処理を追加
                    v_num = 0;
                    //ADD_END :2021/11/14 kitayama 理由：v_numを初期化する処理を追加
                    //ADD_START :2021/11/23 kitayama 理由：撮影用インデックスの初期化処理を追加
                    shot_index = 0;
                    //ADD_END :2021/11/23 kitayama 理由：撮影用インデックスの初期化処理を追加

                    //ADD_START :2021/11/14 kitayama 理由：bmpimagesを初期化する処理を追加
                    for (int j = 0; j < bmpimages.Length; j++)
                    {
                        //検査終了時にメモリを初期化
                        bmpimages[j] = null;
                    }
                    //ADD_END :2021/11/14 kitayama 理由：bmpimagesを初期化する処理を追加

                    //検査画像表示部を初期化
                    sampleViewer.Sample = null;

                    //判定結果を保持している配列を初期化
                    for (int j = 0; j < v_kekka.GetLength(1); j++)
                    {
                        for (int k = 0; k < v_kekka.GetLength(2); k++)
                        {
                            v_kekka[1, j, k] = 0;
                            v_kekka[2, j, k] = V_CONST[0];
                            v_kekka[3, j, k] = 0;
                        }
                    }
                    processingtime = 0;

                    //ADD_START :2022/1/29 kitayama 理由：テキストボックスの初期化処理を追加
                    textbox_Inter.Clear();
                    textbox_NG.Clear();
                    //ADD_END :2022/1/29 kitayama 理由：テキストボックスの初期化処理を追加

                    //MCプロトコル 検査終了でREADY信号をONにする


                }
                //ADD_END :2021/11/1 kitayama 理由：検査終了処理を追加
                //検査終了処理ここまで

                //MEMO :2021/11/7 kitayama 以上が画像処理の改造部分

                #region コメントアウト
                //DELETE_START :2021/11/6 kitayama 理由：ファイル取得処理-画像処理部分で時間計測するので削除
                //Detect_stopwatch2.Reset();
                //Detect_stopwatch2.Start();
                //DELETE_START :2021/11/6 kitayama 理由：ファイル取得処理-画像処理部分で時間計測するので削除



                //DELETE_START :2021/11/6 kitayama 理由：撮影方向は1方向のみなので、方向選択処理は削除
                ////2020.10.22 Y.Oushu Add Try Catch の追加(撮影方向、品種例外処理)
                //try
                //{
                //    //インデックスに撮影方向を格納
                //    if (ihoukou == 0)
                //    {
                //        //方向信号が0（無入力）の場合はコンボボックスの入力を反映する
                //        //ihoukou = Houkou_Combo.SelectedIndex;

                //        ERR_LABEL.Content = "ロボットが検査可能な位置にいません。\n検査を開始するには、ロボットを検査位置まで移動させてください。";
                //    }
                //    else if (ihoukou > 11)
                //    {
                //        //方向信号が0（無入力）の場合はコンボボックスの入力を反映する
                //        //ihoukou = Houkou_Combo.SelectedIndex;

                //        ERR_LABEL.Content = "撮影方向が12以上が選択されました。\n選択可能範囲は1～11までです。";
                //    }
                //    else
                //    {
                //        //方向信号が入力された場合は信号を反映する
                //        Houkou_Combo.SelectedIndex = ihoukou;

                //        //画面エラーのクリア。
                //        ERR_LABEL.Content = "";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    //ログ表示と、画面表示。
                //    logger.Fatal(ex.StackTrace);
                //    logger.Fatal("撮影方向が12以上が選択されました。\n選択可能範囲は1～11までです。");
                //    ERR_LABEL.Content = "撮影方向が12以上が選択されました。\n選択可能範囲は1～11までです。";
                //    return;
                //}
                ////2020.10.22 Y.Oushu Add Try Catch の追加(撮影方向、品種例外処理) End
                ////CHANGE_START :2020/10/21 kitayama 理由：houkouは0にならず、snumとは1ずれているため変更
                ////snum=ihoukou;
                //snum = ihoukou - 1;
                ////CHANGE_END :2020/10/21 kitayama 理由：houkouは0にならず、snumとは1ずれているため変更

                //DELETE_END :2021/11/6 kitayama 理由：撮影方向は1方向のみなので、方向選択処理は削除
                #endregion





            }
            catch (Exception ex)
            {
                //画像処理部分で何かエラーが出た場合の処理
                logger.Fatal($"エラー：MyTimerMethod内部 例外 {ex.Message} ");
                logger.Fatal($"エラー：スタックトレース {ex.StackTrace} ");

                errflag = true;

                //ADD_START :2021/11/8 kitayama 理由：エラー発生時はNGとして画像を削除する
                //移動・削除フラグ以外を落として、削除処理部分でフラグを再設定する

                vidiflag = false;
                endflag = false;
                f_mvflag = true;
                //DELETE_START :2021/11/13 kitayama 理由：エラー時のv_kekkaは初期値のままとするので削除
                //NG判定を格納
                //v_kekka[2, v_num] = -1;
                //DELETE_END :2021/11/13 kitayama 理由：エラー時のv_kekkaは初期値のままとするので削除
                v_num++;

                //ADD_END :2021/11/8 kitayama 理由：エラー発生時はNGとして画像を削除する

                if (image3 != null)
                {
                    //DELETE_START :2022/1/29 kitayama 理由：ERR_LABELは使用しないので削除
                    //CHANGE_START :2021/11/7 kitayama 理由：Streamの切り替えは行わないのでエラーメッセージを変更
                    //ERR_LABEL.Content = "StreamまたはAnalyzeが存在しないため、検査を行うことができませんでした。\r\n(画面にはERと表示されます。)";
                    //ERR_LABEL.Content = "Analyzeが存在しないため、検査を行うことができませんでした。\r\n(画面にはERと表示されます。)";
                    //CHANGE_END :2021/11/7 kitayama 理由：Streamの切り替えは行わないのでエラーメッセージを変更
                    //DELETE_END :2022/1/29 kitayama 理由：ERR_LABELは使用しないので削除

                    //ADD_START :2021/11/7 kitayama 理由：エラー時の処理を追加
                    //ViDiに渡す画像をクリアする
                    image3 = null;
                    //DELETE_START :2021/11/23 kitayama 理由：表示はしないので削除
                    //総合判定にエラーと表示する
                    //okng_largelabel.Content = "ER";
                    //okng_largelabel.Foreground = new SolidColorBrush(Colors.Orange);
                    //DELETE_END :2021/11/23 kitayama 理由：表示はしないので削除

                    //MCプロトコル :2021/11/7 kitayama 検査処理でエラーが発生した場合の出力はここに追加する

                    
                }
                //画像処理部try-catchここまで

                //logger.Fatal($"取得部　trycatch例外{toolStripStatusLabel1.Content}");
            }

            if ((sampleViewer.Sample != null))
            {
                sampleViewer.Sample = null;
                System.GC.Collect();
            }

           

            //ADD_START :2020/10/21 kitayama 理由：エラー時にも処理時間を計測するため追加
            Detect_stopwatch.Stop();
            //ADD_END :2020/10/21 kitayama 理由：エラー時にも処理時間を計測するため追加

        }
        //画像処理部分ここまで


        //画像撮影用処理
        //MCプロトコルのレジスタがONになってから一定間隔で画像の撮影と取り込みを行う
        //ADD_START :2021/11/6 kitayama 理由：画像撮影用処理を追加
        private void MyTimerMethod2(object sender, EventArgs e)
        {
            //トリガ入力時にカメラから画像取得
            //CHANGE_START :2021/11/23 kitayama 理由：画像取り込み処理の開始条件を変更
            if (shotflag == true && shot_index < bmpimages.Length)
            //if (shotflag == true)
            //if (shot_trigger == true & shotflag==true)
            //CHANGE_END :2021/11/23 kitayama 理由：画像取り込み処理の開始条件を変更
            {

                //ADD_START :2021/11/13 kitayama 理由：カメラの画像をメモリに保存する処理を追加
                //一旦shot_trigggerが落ちないと次の画像を取り込まない
                //配列にカメラ画像を格納
                //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
                //bmpimages[shot_index] = dispForm.cogDisplay.Image.ToBitmap();
                //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除
                shot_index++;
                //shotflag = false;
                //ADD_END :2021/11/13 kitayama 理由：カメラの画像をメモリに保存する処理を追加

            }
            //ADD_START :2021/11/11 kitayama 理由：撮影Bitで撮影を制御する処理を追加
            else if (shotflag==false)
            {
                
            }
            //ADD_END :2021/11/11 kitayama 理由：撮影Bitで撮影を制御する処理を追加

            //ADD_START :2022/1/16 kitayama 理由：カメラなしデバッグ用の処理を追加
            //フォルダに画像を追加すると取り込む処理

            //フォルダ内に画像が1枚以上存在する場合に取り込み処理を行う
            if (Directory.GetFiles(@"C:\Users\kitayama\Desktop\detect_test\", $"*.{fext}", SearchOption.AllDirectories).Length >= 1)
            {
                //取得フォルダの最も古い画像ファイルを取得する
                d_files = Directory.GetFiles(@"C:\Users\kitayama\Desktop\detect_test\", $"*.{fext}", SearchOption.AllDirectories)
                    .OrderBy(f => File.GetCreationTime(f))
                    .ToArray();

                //検査画像のファイルがロックされないようにする処理
                //ADD_START :2020/3/11 kitayama 理由：画像破損時のエラー処理でfs,sourceを変更するためここで宣言している
                BitmapImage source = new BitmapImage();
                System.IO.FileStream fs = new System.IO.FileStream(d_files[0], System.IO.FileMode.Open, System.IO.FileAccess.Read);
                //ADD_END 2021/3/11 kitayama 理由：画像破損時のエラー処理でfs,sourceを変更する

                vidiflag = true;
                try
                {
                    //CHANGE_START :2020/9/3 kitayama 理由：imageに画像を表示中でもファイルがロックされないように変更
                    //ADD_START :2020/9/1 kitayama 理由：image1に画像を表示する処理を追加
                    //ここに処理を追加することで既存のtry-catchを利用
                    image1.Source = null;
                    source.BeginInit();
                    //メモリに画像データのキャッシュを作成する
                    source.CacheOption = BitmapCacheOption.OnLoad;
                    source.StreamSource = fs;
                    source.EndInit();
                    fs.Close();
                    //キャッシュデータをimageのソースに指定する
                    this.image1.Source = source;
                    //画像データをメモリに置くので、メモリの使用量に注意する
                    logger.Debug("image1表示部");
                    //CHANGE_END :2020/9/3 kitayama 理由：imageに画像を表示中でもファイルがロックされないように変更

                    //ViDiに渡すため画像の形式を変換する
                    //TEST ViDiなしで動作確認する場合はコメントアウトする
                    image2 = new ViDi2.UI.WpfImage(d_files[0]);

                }
                catch (Exception ex)
                {
                    //検査画像を取得する際にエラーが発生した際の処理
                    vidiflag = false;
                    //画像を取得できない場合は画像を削除する
                    f_mvflag = true;

                    //ADD_START :2019/11/11 kitayama 理由：ログ                                    
                    logger.Fatal($"取得部　ViDi2.UI.WpfImage例外{ex.Message}");
                    //ADD_END :2019/11/11 kitayama 理由：ログ

                    //ADD_START :2019/11/27 kitayama 理由：例外が発生した際に抜けるため
                    image2 = null;
                    //ADD_END :2019/11/27 kitayama 理由：例外が発生した際に抜けるため

                    logger.Info("image2 例外処理終了 image2=nullで画像処理部を飛ばす");
                }

                image2 = new ViDi2.UI.WpfImage(d_files[0]);

            }
            //ADD_END :2022/1/16 kitayama 理由：カメラなしデバッグ用の処理を追加


        }
        //ADD_END :2021/11/6 kitayama 理由：画像撮影用処理を追加
  

        //MCプロトコル 2021/11/3 :kitayama MCプロトコルの入力解析処理はDIO解析を改造するか新規に作成する
        //信号入力時の処理
        //撮影Bit入力時にshotflag=trueとする
        //撮影方向入力信号の数値をsnumに格納する


        /// <summary>
        ///DIO入力解析タイマ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTimerMethod4(object sender, EventArgs e)
        {
            if (iDioRet == 0)
            {
                int Ret;

                Ret = dio.InpBit(sIndex, 0, out Data);

                if (Ret == 0)
                {
                    //DELETE_START :2022/1/29 kitayama 理由：DIOは使用しないので削除
                    //DIO_Analyze();      //入力データ解析
                    //DELETE_END :2022/1/29 kitayama 理由：DIOは使用しないので削除
                }
                else
                {

                    //メッセージボックスを表示する
                    MessageBoxResult result = MessageBox.Show("DIOデバイスエラーです。入力を確認できませんでした。DIOデバイスを確認してください。",
                    "DIO 入力:エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                }

            }
            else
            {

                //ADD_START :2019/11/11 kitayama 理由：ログ
                logger.Error($"DIO入力解析 　iDioRet={iDioRet}　DIO 初期化:エラー");
                //ADD_END :2019/11/11 kitayama 理由：ログ
            }


        }

        #region コメントアウト
        //DELETE_START :2022/1/29 kitayama 理由：DIOは使用しないので削除
        /// <summary>
        /// DIOデバイス　入力データ解析
        /// </summary>
        /// <param name="bData"></param>
        //private void DIO_Analyze()
        //{
        //    byte bData;
        //    int iKishu = 0;
        //    ihoukou = 0;

        //    ////2020.10.22 Y.Oushu Comment Out logger.Debug("入力データ解析");

        //    for (short i = 0; i < 16; i++)
        //    {
        //        switch (i)
        //        {
        //            //検査開始(ON),検査停止(OFF)
        //            case 0:

        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                ////2020.10.22 Y.Oushu Comment Out logger.Debug($"case 0  iRet={iRet}");

        //                if (1 == bData)
        //                {
        //                    ////2020.10.22 Y.Oushu Comment Out logger.Debug("case 0  bData=1");

        //                    ellipse_inp0.Fill = System.Windows.Media.Brushes.Lime;

        //                    if (bDetectFlag == false)
        //                    {
        //                        if (Kishu_ComboBox.SelectedIndex != -1)
        //                        {
        //                            //品種が選択されていない場合は検査開始しない
        //                            bDetectFlag = true;     //検査開始フラグ　開始：TRUE
        //                            DetectStart();          //検査開始or検査停止処理
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp0.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                    if (bDetectFlag == true)
        //                    {
        //                        bDetectFlag = false;     //検査開始フラグ　停止：FALSE
        //                        DetectStart();          //検査開始or検査停止処理
        //                    }
        //                }
        //                break;
        //            //品種（4Bit目）
        //            case 1:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    iKishu = 1;
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp1.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //2020.10.23 Y.Oushu Add 0が入るように。
        //                    iKishu = 0;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp1.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;
        //            //品種（3Bit目）
        //            case 2:
        //                iRet = dio.InpBit(sIndex, i, out bData);
        //                if (bData == 1)
        //                {
        //                    iKishu = iKishu + 2;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp2.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp2.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                break;
        //            //品種（2Bit目）
        //            case 3:
        //                iRet = dio.InpBit(sIndex, i, out bData);


        //                if (bData == 1)
        //                {
        //                    iKishu = iKishu + 4;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp3.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp3.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;
        //            //品種（1Bit目）
        //            case 4:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {

        //                    iKishu = iKishu + 8;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp4.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp4.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;
        //            //撮影方向
        //            case 5:
        //                //ADD_START :2020/10/12 kitayama 理由：品種選択処理を追加
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    ihoukou = 1;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp5.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //2020.10.23 Y.Oushu Add 0が入るように。
        //                    ihoukou = 0;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp5.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;


        //            case 6:
        //                //ADD_START :2020/10/12 kitayama 理由：品種選択処理を追加
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    ihoukou = ihoukou + 2;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp6.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp6.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;
        //            //ADD_END :2020/10/12 kitayama 理由：品種選択処理を追加

        //            case 7:
        //                //ADD_START :2020/10/12 kitayama 理由：品種選択処理を追加
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    ihoukou = ihoukou + 4;


        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp7.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp7.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;
        //            //ADD_END :2020/10/12 kitayama 理由：品種選択処理を追加

        //            //ADD_START :2020/10/7 kitayama 理由：16ビットに対応する処理を追加
        //            case 8:
        //                //ADD_START :2020/10/12 kitayama 理由：品種選択処理を追加
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    ihoukou = ihoukou + 8;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp8.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp8.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;
        //            //ADD_END :2020/10/12 kitayama 理由：品種選択処理を追加


        //            //撮影トリガ
        //            case 9:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    //撮影トリガをONにする
        //                    shot_trigger = true;

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp9.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                    //2020.10.22 Y.Oushu Add Error クリア
        //                    ERR_LABEL.Content = "";
        //                    //2020.10.22 Y.Oushu Add Error クリア
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp9.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //            case 10:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    //カウンタリセット処理
        //                    counter_reset();
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp10.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                    //2020.10.22 Y.Oushu Add エラー表示クリア
        //                    ERR_LABEL.Content = "";
        //                    //2020.10.22 Y.Oushu Add エラー表示クリア End
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp10.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //            //緊急停止（Stream,Analyzeをリセットし、検査停止状態にする）
        //            case 11:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {

        //                    stop_flag = true;
        //                    //DELETE_START :2021/12/2 kitayama 理由：緊急停止は使用しないので削除
        //                    //teisi_label.Content = "緊急停止中";
        //                    //teisi_label.Visibility = Visibility.Visible;
        //                    //DELETE_END :2021/12/2 kitayama 理由：緊急停止は使用しないので削除
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp11.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし
        //                    //DELETE_START :2021/12/2 kitayama 理由：緊急停止は使用しないので削除
        //                    //teisi_label.Visibility = Visibility.Hidden;
        //                    //DELETE_END :2021/12/2 kitayama 理由：緊急停止は使用しないので削除
        //                    image1.Visibility = Visibility.Visible;
        //                    //blueframe.Visibility = Visibility.Visible;
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp11.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //            case 12:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp12.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp12.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //            case 13:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp13.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp13.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //            case 14:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp14.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp14.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //            case 15:
        //                iRet = dio.InpBit(sIndex, i, out bData);

        //                if (bData == 1)
        //                {
        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp15.Fill = System.Windows.Media.Brushes.Lime;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                }
        //                else
        //                {
        //                    //演算なし

        //                    //ADD_START :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加
        //                    ellipse_inp15.Fill = System.Windows.Media.Brushes.Red;
        //                    //ADD_END :2019/12/18 kitayama 理由：入力状態をわかるようにするため追加

        //                }
        //                break;

        //                //ADD_END :2020/10/7 kitayama 理由：16ビットに対応する処理を追加
        //        }
        //    }

        //    //MCプロトコル　品種信号の処理はここに追加する

        //    if (iKishu != Kishu_ComboBox.SelectedIndex)
        //    {
        //        //////////////////////////////////////////////////////////
        //        ///     品種変更
        //        //////////////////////////////////////////////////////////
        //        if (iKishu < 1)
        //        {
        //            //2020,10.23 Y.Oushu Add エラーの画面表示と、右上品種欄を未選択状態に。
        //            ERR_LABEL_Hinshu.Content = "品種選択信号がありません。\nPLCに電源が入っているかまたは、ケーブルの接続を確認してください。";
        //            Kishu_ComboBox.SelectedIndex = -1;
        //            WorkSpece_Label.Content = "";
        //            //2020,10.23 Y.Oushu Add エラーの画面表示と、右上品種欄を未選択状態に。
        //        }
        //        else
        //        {
        //            //ADD_START :2020/7/31 kitayama 理由：品種11以上が入力された場合のtry-catch処理を追加
        //            try
        //            {
        //                //2020,10.23 Y.Oushu Add エラーの画面表示をクリア。
        //                ERR_LABEL_Hinshu.Content = "";
        //                //2020,10.23 Y.Oushu Add エラーの画面表示をクリア。

        //                Kishu_ComboBox.SelectedIndex = iKishu;              //選択された品種
        //                WorkSpece_Label.Content = sWorkspece[iKishu - 1];     //ワークスペースを表示
        //                selectedItem = iKishu;                              //品種No.
        //                                                                    //DIO_Output("品種1", 0);                             //DIOデバイス　出力：REDY　bit = 0 ※品種の出力はbitは見ない。選択された品種名をチェックする。
        //                toolStripStatusLabel1.Content = "DIO入力：品種変更＝" + Kishu_ComboBox.Text;

        //                //DELETE_START :2021/11/8 kitayama 理由：Addlistは使用しないので削除
        //                //Addlist("DIO入力：品種変更＝" + Kishu_ComboBox.Text);
        //                //DELETE_END :2021/11/8 kitayama 理由：Addlistは使用しないので削除
        //                //DELETE_START :2021/12/2 kitayama 理由：緊急停止は使用しないので削除
        //                //teisi_label.Content = "ワークスペース読み込み中";
        //                //teisi_label.Visibility = Visibility.Visible;
        //                //DELETE_END :2021/12/2 kitayama 理由：緊急停止は使用しないので削除

        //            }
        //            catch (Exception ex)
        //            {
        //                //2020.10.23 Y.Oushu Modify エラーの表示方法を変更
        //                ERR_LABEL_Hinshu.Content = "品種に11以上が選択されました。\n選択可能範囲は1～10までです。";
        //                //2020.10.23 Y.Oushu Modify エラーの表示方法を変更 end
        //            }
        //            //ADD_END :2020/7/31 kitayama 理由：品種11以上が入力された場合のtry-catch処理を追加
        //        }
        //    }
        //    else
        //    {
        //        //品種変更なし。
        //    }

        //    //DLELTE_START :2021/11/6 kitayama 理由：撮影方向は固定なので、撮影方向選択処理は削除
        //    ////ADD_START :2020/10/12 kitayama 理由：品種選択処理を追加
        //    //if (ihoukou != Houkou_Combo.SelectedIndex)
        //    //{
        //    //    //撮影方向変更
        //    //    if (ihoukou < 1)
        //    //    {

        //    //    }
        //    //    else
        //    //    {
        //    //        //ADD_START :2020/7/31 kitayama 理由：品種11以上が入力された場合のtry-catch処理を追加
        //    //        try
        //    //        {

        //    //        }
        //    //        catch (Exception ex)
        //    //        {
        //    //            //品種11以上が入力された場合はエラーメッセージと入力番号を表示
        //    //            MessageBox.Show($"撮影方向に12以上が入力されました。（入力された撮影方向：{ihoukou}）\n対応可能な撮影方向は11までです。入力を確認してください。",
        //    //                "撮影方向エラー",
        //    //                MessageBoxButton.OK,
        //    //                MessageBoxImage.Error);
        //    //        }
        //    //        //ADD_END :2020/7/31 kitayama 理由：品種11以上が入力された場合のtry-catch処理を追加
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    //品種変更なし。
        //    //}
        //    //DLELTE_END :2021/11/6 kitayama 理由：撮影方向は固定なので、撮影方向選択処理は削除

        //    //DELETE_START :2021/11/8 kitayama 理由：DIOは使用しないので削除
        //    //if (iRet > 0)
        //    //{
        //    //    toolStripStatusLabel1.Content = "DIO入力エラー番号:" + iRet.ToString();

        //    //    //ADD_START :2019/12/23 kitayama 理由：ステータスを画面に表示させるため
        //    //    Addlist("DIO入力エラー番号:" + iRet.ToString());
        //    //    //ADD_END :2019/12/23 kitayama 理由：ステータスを画面に表示させるため

        //    //    //ADD_START :2019/11/11 kitayama 理由：ログ
        //    //    logger.Error($"入力データ解析 iRet > 0  {toolStripStatusLabel1.Content}");
        //    //}
        //    //DELETE_END :2021/11/8 kitayama 理由：DIOは使用しないので削除

        //    //定義 値 意味
        //    //DIO_ERR_SUCCESS                       0       正常終了
        //    //DIO_ERR_SYS_RECOVERED_FROM_STANDBY    7       スタンバイモードから復帰したため、DioResetDevice関数を実行してください
        //    //DIO_ERR_DLL_INVALID_ID                10001   無効なIDが指定されました。
        //    //DIO_ERR_DLL_CALL_DRIVER               10002   ドライバを呼び出せません(デバイスI / Oコントロールに失敗)。
        //    //DIO_ERR_DLL_BUFF_ADDRESS              10100   データバッファアドレスが不正です。
        //    //DIO_ERR_SYS_NOT_SUPPORTED             20001   このデバイスではこの関数は使用できません。
        //    //DIO_ERR_SYS_BIT_NO                    20102   ビット番号が指定可能範囲を超えています。
        //}
        //DELETE_END :2022/1/29 kitayama 理由：DIOは使用しないので削除
        #endregion

        /// <summary>
        /// 10件以上前のログファイルを削除する
        /// 北山
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //ADD_START :2019/11/13 kitayama 理由：ログファイルを削除するため
        private void MyTimerMethod5(object sender, EventArgs e)
        {
            //ADD_START :2019/11/17 kitayama 理由：パス取得のため
            string appPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            string logdir = $@"{appPath}\log";

            //ADD_START :2019/11/17 kitayama 理由：パス取得のため
            string[] logfiles;

            //ADD_START :2020/9/3 kitayama 理由：logフォルダがあるドライブを取得
            string log_root = System.IO.Path.GetPathRoot(appPath);


            //作成時間順（Creationtime）にファイルを取得
            logfiles = Directory.GetFiles(logdir, "*", SearchOption.AllDirectories)
                .OrderBy(f => File.GetLastWriteTime(f))
                .ToArray();


            //2020.10.22 Y.Oushu Comment Out logger.Debug("ログ削除部");

            //ADD_START :2020/9/29 kitayama 理由：9/28のログよりここでフリーズが発生しているようなのでtry-catchを追加
            try
            {
                System.IO.DriveInfo drive = new System.IO.DriveInfo(appPath.Substring(0, 1));
                if (drive.IsReady)
                {
                    //空き容量率の算出
                    float logBlank = ((float)drive.TotalFreeSpace / (float)drive.TotalSize) * 100;

                    if (logBlank < (float)logBlankrate)
                    {
                        System.IO.File.Delete(logfiles[0]);
                    }
                    logger.Info($"ディスク容量{drive.TotalSize},空き容量{drive.TotalFreeSpace}");
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("ログ削除部例外" + ex.Message);
            }

        }


        // タイマのインスタンス　北山
        private DispatcherTimer _timer;

        /// <summary>
        /// ファイル取得タイマを設定する
        /// 北山
        /// </summary>
        private void SetupTimer()
        {
            // タイマのインスタンスを生成
            _timer = new DispatcherTimer();
                                            
            // インターバルを設定
            _timer.Interval = new TimeSpan(0, 0, 0, 0, INTERVAL1);
            //CHANGE_END :2020/10/6 kitayama 理由：画像取得・移動周期は手動設定しないので削除
            //ADD_START :2019/11/11 kitayama 理由：ログ
            logger.Info($"取得タイマインターバル：{_timer.Interval}");
            //ADD_END :2019/11/11 kitayama 理由：ログ

            // タイマメソッドを設定
            _timer.Tick += new EventHandler(MyTimerMethod);
            // タイマを開始
            _timer.Start();

            // 画面が閉じられるときに、タイマを停止
            this.Closing += new CancelEventHandler(StopTimer);
        }

        //画像撮影用タイマーの設定
        //ADD_START :2021/11/6 kitayama 理由：画像撮影用タイマーの設定を追加
        private void SetupTimer2()
        {
            // タイマのインスタンスを生成
            _timer = new DispatcherTimer();
            //画像撮影のインターバルは設定値を読む
            _timer.Interval = new TimeSpan(0, 0, 0, 0, interval2);

            logger.Info($"画像撮影タイマインターバル：{_timer.Interval}");

            // タイマメソッドを設定
            _timer.Tick += new EventHandler(MyTimerMethod2);
            // タイマを開始
            _timer.Start();
            // 画面が閉じられるときに、タイマを停止
            this.Closing += new CancelEventHandler(StopTimer);
        }
        //ADD_END :2021/11/6 kitayama 理由：画像撮影用タイマーの設定を追加

        /// <summary>
        ///IO取得タイマを設定する
        /// </summary>
        private void SetupTimer4()
        {
            // タイマのインスタンスを生成
            _timer = new DispatcherTimer(); 
                                           
            // インターバルを設定
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            //ADD_START :2019/11/11 kitayama 理由：ログ
            logger.Info($"IO取得タイマインターバル：{_timer.Interval}");
            //ADD_END :2019/11/11 kitayama 理由：ログ

            // タイマメソッドを設定
            _timer.Tick += new EventHandler(MyTimerMethod4);
            // タイマを開始
            _timer.Start();

            // 画面が閉じられるときに、タイマを停止
            this.Closing += new CancelEventHandler(StopTimer);
        }



        /// <summary>
        ///ログファイル削除のタイマーを設定
        /// </summary>
        //ADD_START :2019/11/13 kitayama 理由：ログファイルの削除を行うため
        private void SetupTimer5()
        {
            // タイマのインスタンスを生成
            _timer = new DispatcherTimer();
                                            
            // インターバルを設定              
            //CHANGE_START :2020/9/3 kitayama 理由：ログを削除する間隔を1日から30分間隔に変更
            _timer.Interval = new TimeSpan(0, 0, 30, 0, 0);
            //CHANGE_END :2020/9/3 kitayama 理由：ログを削除する間隔を1日から30分間隔に変更
            //ADD_START :2019/11/11 kitayama 理由：ログ
            logger.Info($"ログファイル削除タイマインターバル：{_timer.Interval}");
            //ADD_END :2019/11/11 kitayama 理由：ログ

            // タイマメソッドを設定
            _timer.Tick += new EventHandler(MyTimerMethod5);
            // タイマを開始
            _timer.Start();

            // 画面が閉じられるときに、タイマを停止
            this.Closing += new CancelEventHandler(StopTimer);
        }

        /// <summary>
        /// タイマを停止する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopTimer(object sender, CancelEventArgs e)
        {
            _timer.Stop();
            logger.Info($"タイマ停止");
        }


        /// <summary>
        /// ツール名を取得する
        /// </summary>
        /// <param name="tool"></param>
        void sampleViewer_ToolSelected(ViDi2.ITool tool)
        {
            RaisePropertyChanged(nameof(SampleViewer));

        }

        /// <summary>
        /// ViDiのサンプルプログラム
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CheckDrop(object sender, DragEventArgs e)
        {
            var lst = (IEnumerable<string>)e.Data.GetData(DataFormats.FileDrop);
            bool isArchive = System.IO.Path.GetExtension(lst.First()) == ".vsa";

            e.Effects = stream != null || isArchive ? DragDropEffects.All : DragDropEffects.None;
            e.Handled = true;

            logger.Fatal("ViDiサンプルプログラム　CheckDrop");
        }

        /// <summary>
        /// ViDiのサンプルプログラム
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoDrop(object sender, DragEventArgs e)
        {
            var lst = (IEnumerable<string>)e.Data.GetData(DataFormats.FileDrop);

            logger.Fatal("ViDiサンプルプログラム　DoDrop");
            try
            {
                if (System.IO.Path.GetExtension(lst.First()) == ".vsa")
                {
                    logger.Fatal("DoDrop　System.IO.Path.GetExtension(lst.First()) = \".vsa\"　");
                    using (var stream = new FileStream(lst.First(), FileMode.Open))
                    {
                        // deserialize the sample from disk
                        var formatter = new BinaryFormatter();
                        sampleViewer.Sample = (ViDi2.ISample)formatter.Deserialize(stream);
                    }
                }
                else
                {
                    logger.Fatal("DoDrop　System.IO.Path.GetExtension(lst.First()) != \".vsa\"　");

                    using (var image = new ViDi2.UI.WpfImage(lst.First()))
                        sampleViewer.Sample = Stream.Process(image);
                }

                RaisePropertyChanged(nameof(ViewIndices));
            }
            catch (Exception ex)
            {
                logger.Fatal("DoDrop　例外処理");
                MessageBox.Show(this, ex.Message, "Failed to Load",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// ViDiのサンプルプログラム
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".vrws",
                Filter = "ViDi Runtime Workspaces (*.vrws)|*.vrws"
            };

            logger.Fatal("ViDiサンプルプログラム　open_Click");

            if ((bool)dialog.ShowDialog() == true)
            {
                logger.Fatal("open_Click  (bool)dialog.ShowDialog() = true");

                using (var fs = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open))
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Workspace = Control.Workspaces.Add(System.IO.Path.GetFileNameWithoutExtension(dialog.FileName), fs);
                    Console.WriteLine("loaded runtime workspace in {0}", stopwatch.Elapsed);
                    Mouse.OverrideCursor = null;

                }
            }
        }

        /// <summary>
        /// ViDiのサンプルプログラム
        /// </summary>
        public Dictionary<int, string> ViewIndices
        {
            get
            {
                var indices = new Dictionary<int, string>();

                if (sampleViewer.Sample != null && sampleViewer.ToolName != "")
                {
                    var views = sampleViewer.Sample.Markings[sampleViewer.ToolName].Views;
                    indices.Add(-1, "all");

                    for (int i = 0; i < views.Count; ++i)
                        indices.Add(i, i.ToString());
                }

                return indices;
            }

        }

        /// <summary>
        /// ViDiのサンプルプログラム
        /// </summary>
        /// <param name="prop"></param>
        private void RaisePropertyChanged(string prop)
        {
            //2020.10.22 Y.Oushu Comment Out logger.Debug("ViDiサンプルプログラム　RaisePropertyChanged");
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 品種設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //2020.10.22 Y.Oushu Comment Out logger.Debug("品種設定ボタン　Form4開く");
            //CHANGE_START :2021/12/19 kitayama 理由：設定画面の前にパスワード入力画面を開くように変更
            //CHANGE_START :2022/1/9 kitayama 理由：Form4にmainwindowの値を渡すためForm5が引数をとるように変更
            //System.Windows.Forms.Form form = new Form5();

            // nakagawa 2020/02/04 変更
            // 2022/2/5 kitayama Form5に更新が反映されていなかったのでエラーが発生していた。
            //　Form5を最新にしたので元に戻した。
            System.Windows.Forms.Form form = new Form5(this);
            //System.Windows.Forms.Form form = new Form5();

            //CHANGE_END :2022/1/9 kitayama 理由：Form4にmainwindowの値を渡すためForm5が引数をとるように変更

            form.Show();
            //System.Windows.Forms.Form form = new Form4(this);
            //form.ShowDialog();
            //CHANGE_END :2021/12/19 kitayama 理由：設定画面の前にパスワード入力画面を開くように変更
        }


        //MCプロトコル　MCプロトコルの信号割り当てを表示する場合はForm3の内容を書き換える
        /// <summary>
        /// DIO確認ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //2020.10.22 Y.Oushu Comment Out logger.Debug("DIO確認ボタン　Form3開く");

            // nakagawa 2020/02/04 変更
            // 2022/2/5 kitayama Form3に更新が反映されていなかったのでエラーが発生していた。
            //　Form3を最新にしたので元に戻した。
            System.Windows.Forms.Form form = new Form3(this);
            //System.Windows.Forms.Form form = new Form3(this,dio);
            form.Show();
        }

        //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
        /// <summary>
        /// カメラ設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    //DELETE_START :2021/11/3 kitayama 理由：ファイル保存チェックは使用しないので削除
        //    //issave1 = (bool)fMoveFile.IsChecked;
        //    //DELETE_END :2021/11/3 kitayama 理由：ファイル保存チェックは使用しないので削除
        //    //2020.10.22 Y.Oushu Comment Out logger.Debug("カメラ設定ボタン　Form10開く");
        //    System.Windows.Forms.Form form = new frmAcqImageProcess();
        //    form.ShowDialog();
        //}
        //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除

        /// <summary>
        /// 検査開始or検査停止　ボタン
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //品種が未選択
            if (Kishu_ComboBox.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("「品種」を選択してください。",
                "品種未選択 エラー",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                logger.Error($"検査ボタン　品種未選択エラー");
            }
            //品種が選択済
            else
            {
                //検査開始or検査停止
                DetectStart();      
                logger.Info($"検査ボタン操作");
            }
        }

        /// <summary>
        /// 検査開始or検査停止　処理
        /// </summary>
        private void DetectStart()
        {
            //検査開始
            if (DetectButton.Content.ToString() == "検査開始")
            {
                image1.Source = null;

                detect_on = true;
                //DLELTE_START :2021/11/21 kitayama 理由：画像処理フローを変更するので古い変数を削除
                //anum = 0;
                //DLELTE_END :2021/11/21 kitayama 理由：画像処理フローを変更するので古い変数を削除
                snum = Houkou_Combo.SelectedIndex;

                DetectButton.Content = "検査停止";

                int selectedItem = Kishu_ComboBox.SelectedIndex;


                //MCプロトコル　検査開始時の出力信号を設定する
                

                Kishu_ComboBox.IsEnabled = false;
                Set_Kishu_button.IsEnabled = false;
                //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
                //Get_Image_button.IsEnabled = false;
                //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除
                Set_DIO_button.IsEnabled = false;

                bViDiFlag = true;

                Houkou_Combo.IsEnabled = false;

            }
            //検査停止
            else
            {
                Mouse.OverrideCursor = Cursors.Wait;

                detect_on = false;

                image1.Source = null;
                snum = 0;
                anum = 0;
                scoreflag = true;

                shot_trigger = false;

                DetectButton.Content = "検査開始";
                bDetectFlag = false;

                Kishu_ComboBox.IsEnabled = true;
                Set_Kishu_button.IsEnabled = true;
                //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
                //Get_Image_button.IsEnabled = true;
                //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除
                Set_DIO_button.IsEnabled = true;

                Houkou_Combo.IsEnabled = true;

                Mouse.OverrideCursor = Cursors.Arrow;
            }

        }

        /// <summary>
        /// 品種選択コンボボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kishu_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = Kishu_ComboBox.SelectedIndex;

            logger.Info($"コンボボックス　選択品種インデックス：{selectedItem}");

            if (selectedItem < 0)
            {
                logger.Info("コンボボックス　selectedItem < 0");
            }
            else if (selectedItem == 0)
            {
                logger.Error("品種選択で-を選択");
                MessageBoxResult result = MessageBox.Show(" - は選択できません。登録された品種名を選択してください",
                "エラー",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            else
            {

                WorkSpece_Label.Content = sWorkspece[selectedItem - 1];

               
                if (Workspace != null)
                {
                    if (Workspace.IsOpen)
                    {
                        //2020.10.22 Y.Oushu Comment Out logger.Debug("Workspace != null ワークスペース閉じる");
                        Workspace.Close();
                        sampleViewer.Sample = null;
                    }
                    else
                    {
                        //2020.10.22 Y.Oushu Comment Out logger.Debug("Workspace.IsOpen=false");
                    }
                }
                else
                {
                    //2020.10.22 Y.Oushu Comment Out logger.Debug("Workspace==null");
                }

                string appPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "RuntimeWorkspace\\";

                if (System.IO.File.Exists($@"{appPath}{sWorkspece[selectedItem - 1]}"))
                {
                    kishuselect = true;

                    //2020.10.22 Y.Oushu Comment Out logger.Debug("ワークスペースが指定フォルダに存在する");

                    Mouse.OverrideCursor = Cursors.Wait;

                    try
                    {

                        //ワークスペースを開く
                        //TEST　ライセンスなしでデバッグする場合はここをコメントアウトする
                        using (var fs = new System.IO.FileStream(appPath + WorkSpece_Label.Content.ToString(), System.IO.FileMode.Open))
                            Workspace = Control.Workspaces.Add(appPath + WorkSpece_Label.Content.ToString(), fs);    

                        //2020.10.22 Y.Oushu Comment Out logger.Debug("try ワークスペースを開いた");

                    }
                    catch (Exception ex)
                    {
                        logger.Fatal($"検査開始　ワークスペースオープンエラー　appPath WorkSpece_Label.Content.ToString(),{ex.Message}");
                    }

                    Mouse.OverrideCursor = Cursors.Arrow;

                }
                else
                {
                    kishuselect = false;
                    logger.Error("選択したワークスペースが存在しない");

                    MessageBoxResult result = MessageBox.Show("選択したワークスペースが存在しません。品種設定よりワークスペース名を確認してください。",
                "エラー",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

                }

            }

        }

        /// <summary>
        /// ViDiの処理結果よりOK/NGを出力する
        /// </summary>
        /// <param name="dThreshold_Kekka"></param>
        /// <param name="RedMarking"></param>
        //CHANGE_START :2022/1/18 kitayama 理由：判定結果を返すためメソッドに返り値を設定 
        private int Kekka(double upper_Threshold, double lower_Threshold, Hanntei k_hanntei, ViDi2.IRedMarking RedMarking)
        //private void Kekka(double upper_Threshold,double lower_Threshold, Hanntei k_hanntei ,ViDi2.IRedMarking RedMarking)
        //CHANGE_END :2022/1/18 kitayama 理由：判定結果を返すためメソッドに返り値を設定
        {

            //0118 k_hannteiを返す必要がある　void kekka > bool kekkaに変更する 
            bDetect = false;

            //2020.10.22 Y.Oushu Add 
            dScore = 999;

            if (RedMarking != null)
            {
                //2020.10.22 Y.Oushu Comment Out logger.Debug("Kekka  RedMarking != null");

                foreach (ViDi2.IRedView redView in RedMarking.Views)
                {

                    dScore = redView.Score;
                    //DELETE_START :2021/11/3 kitayama 理由：ファイル保存チェックは使用しないので削除
                    //fMoveFile.IsChecked = fMoveFile.IsChecked & (lBlankDisk > fBlankrate);
                    //DELETE_END :2021/11/3 kitayama 理由：ファイル保存チェックは使用しないので削除

                    logger.Debug("Kekka判定 : " + dScore + "点");

                    if (dScore <= lower_Threshold)
                    {
                        //判定がOKの場合
                        //CHANGE_START :2021/11/13 kitayama 理由：判定不可に対応するためフラグを変更
                        //2020.10.22 Y.Oushu Comment Out logger.Debug("Kekka判定部  スコアが閾値以下 OK");
                        //bOkNg = true;
                        k_hanntei = Hanntei.OK;
                        //CHANGE_END :2021/11/13 kitayama 理由：判定不可に対応するためフラグを変更

                        //MCプロトコル :2021/11/7 kitayama　OK判定時の結果信号出力はここに追加する

                        bDetect = true;
                    }
                    else if(upper_Threshold <= dScore)
                    {
                        //NGの場合
                        //CHANGE_START :2021/11/13 kitayama 理由：判定不可に対応するためフラグを変更
                        //bOkNg = false;
                        k_hanntei = Hanntei.NG;
                        //CHANGE_START :2021/11/13 kitayama 理由：判定不可に対応するためフラグを変更

                        //MCプロトコル :2021/11/7 kitayama　OK判定時の結果信号出力はここに追加する
                        
                        bDetect = true;
                    }
                    //ADD_START :2021/11/13 kitayama 理由：判定不可の処理を追加
                    else
                    {
                        //判定不可のとき
                        k_hanntei = Hanntei.NOR;
                    
                    }
                    //ADD_END :2021/11/13 kitayama 理由：判定不可の処理を追加

                }

                //ADD_START :2022/1/18 kitayama 理由：判定結果を返す処理を追加
                return (int)k_hanntei;
                //ADD_END :2022/1/18 kitayama 理由：判定結果を返す処理を追加

               
            }
            else
            {
                //ViDiで処理が行われていない場合
                logger.Error($"Kekka  RedMarking=null");
                //ADD_START :2022/1/18 kitayama 理由：判定結果を返す処理を追加
                return -1;
                //ADD_END :2022/1/18 kitayama 理由：判定結果を返す処理を追加
            }
        }


        /// <summary>
        /// ソフト終了時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("ViDi 検査ソフトを終了します。",
                "通知",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            logger.Info("ソフト終了");
            image1.Source = null;

            //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
            //test10/16 カメラ終了処理
            //dispForm.AcqFifoTool.Operator.Flush();
            //dispForm.AcqFifoTool.Dispose();
            //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除

            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
                fg.Disconnect(false);

            //MCプロトコル　検査終了時の処理をここに追加する
            

            logger.Info("初期化終了。アプリケーション終了。");
        }


        /// <summary>
        /// 検査数カウンタ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CounterReset_Click(object sender, RoutedEventArgs e)
        {
            counter_reset();
        }

        public void counter_reset()
        {
            //DELETE_START :2021/11/7 kitayama 理由：カウントするのはOK/NGと検査総数だけなのでそれ以外を削除
            //for (int p = 0; iOK.Length > p; p++)
            //{
            //    iOK[p] = 0;
            //    iNG[p] = 0;
            //}

            //total_images = 0;
            //ok_images = 0;
            //ng_images = 0;
            //OK_Images_Label.Content = ok_images;
            //NG_Images_Label.Content = ng_images;
            //Total_Images_Label.Content = total_images;
            //DELETE_END :2021/11/7 kitayama 理由：カウントするのはOK/NGと検査総数だけなのでそれ以外を削除
            iTotal_OK = 0;
            iTotal_NG = 0;
            iTotal_Detect = 0;
            OK_Images_Label.Content = iTotal_OK;
            NG_Images_Label.Content = iTotal_NG;
            Total_Images_Label.Content = iTotal_Detect;

            logger.Info("検査カウンタリセット");
        }

        //カメラの撮影画像をbmpからViDiに渡せる形式変換する処理
        public static BitmapImage ToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        //DELETE_START :2021/12/19 kitayama 理由：visionproは使用しないので削除
        //private void Capture_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    // 外部トリガ処理用
        //    image1.Source = ToBitmapImage(dispForm.cogDisplay.Image.ToBitmap());
        //}
        //DELETE_END :2021/12/19 kitayama 理由：visionproは使用しないので削除


        //ADD_START :2021/12/20 kitayama 理由：画像保存先フォルダを開く処理を追加
        private void OK_Open_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", sImagePath[0]);
        }

        private void INTER_Open_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", sImagePath[1]);
        }

        private void NG_Open_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", sImagePath[2]);
        }

        //ADD_END :2021/12/20 kitayama 理由：画像保存先フォルダを開く処理を追加
    }

}
