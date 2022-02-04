using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 
/// </summary>
namespace Example.Runtime
{
    public partial class Form2 : Form
    {
        //ADD_START :2019/11/13 kitayama 理由：log4netのインスタンス取得
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //ADD_END :2019/11/13 kitayama 理由：log4netのインスタンス取得

        MainWindow f1;
        public Form2(MainWindow mainWindow)
        {
            InitializeComponent();
            f1 = mainWindow;
        }

        /// <summary>
        /// 画像取得、保存先フォルダや取得、保存周期を画面に表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            GetImagePathtextBox.Text = MainWindow.sGetImagePath;                   //画像取得先パス　を画面に表示
            SetImagePasthtextBox.Text = MainWindow.sSetImagePath;                  //画像保存先パス　を画面に表示
            //ADD_START :2020/2/20 kitayama 理由：破損エラー画像保存先パスを追加
            IsoImagePathtextBox.Text = MainWindow.sIsoImagePath;
            //ADD_END :2020/2/20 kitayama 理由：破損エラー画像保存先パスを追加

            //ADD_START :2020/1/14 kitayama 理由：待機時間を読み込む
            holdUpDown1.Value = MainWindow.iHoldTime;
            //ADD_END :2020/1/14 kitayama 理由：待機時間を読み込む
            //ADD_START :2020/2/21 kitayama 理由：画像保存しきい値を追加
            BlankUpDown1.Value = MainWindow.fBlankrate;
            //ADD_END :2020/2/21 kitayama 理由：画像保存しきい値を追加
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form2 ロード");
            //ADD_END :2019/11/14 kitayama 理由：ログ

            //ADD_START :2019/11/1 kawabata 理由：グローバル変数チェック
            if (MainWindow.iGetImageInterval > 0)
            {
                //正常
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("MainWindow 取得インターバル > 0");
                //ADD_END :2019/11/14 kitayama 理由：ログ
            }
            else
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("MainWindow 取得インターバル <= 0");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //CHANGE_START :2019/11/8 kitayama 理由：初期値を10に設定するため変更。
                //MainWindow.iGetImageInterval = 1;   //強制的に１にする。
                MainWindow.iGetImageInterval = 10;   //強制的に10にする。
                //CHANGE_END :2019/11/8 kitayama 理由：初期値を10に設定するため変更。
            }
            GetImageIntervalNumericUpDown.Value = MainWindow.iGetImageInterval;    //画像取得周期（単位msec) を画面に表示
            
            if (MainWindow.iMoveImageInterval > 0)
            {
                //正常
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("MainWindow 移動インターバル > 0");
                //ADD_END :2019/11/14 kitayama 理由：ログ
            }
            else
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("MainWindow 移動インターバル <= 0");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //CHANGE_START :2019/11/8 kitayama 理由：初期値を10に設定するため変更。
                //MainWindow.iMoveImageInterval = 1;   //強制的に１にする。
                MainWindow.iMoveImageInterval = 10;   //強制的に10にする。
                //CHANGE_END :2019/11/8 kitayama 理由：初期値を10に設定するため変更。
            }
            MoveImageIntervalNumericUpDown.Value = MainWindow.iMoveImageInterval;  //画像移動周期（単位msec) を画面に表示
                                                                                   
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug($" 取得インターバル={MainWindow.iGetImageInterval}  移動インターバル={MainWindow.iMoveImageInterval}");
            //ADD_END :2019/11/14 kitayama 理由：ログ
        }

        /// <summary>
        /// キャンセルボタンを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form2　キャンセルボタン");
            //ADD_END :2019/11/14 kitayama 理由：ログ
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("設定せずに検査画像取得設定画面を閉じますか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form2　キャンセル＞はい");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //「はい」が選択された時
                Console.WriteLine("「はい」が選択されました");
                Close();    //フォームを閉じる。
            }
            else if (result == DialogResult.No)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form2　キャンセル＞いいえ");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //「いいえ」が選択された時
                Console.WriteLine("「いいえ」が選択されました");
            }
        }

        /// <summary>
        /// 設定ボタンを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_button_Click(object sender, EventArgs e)
        {
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form2　設定ボタン");
            //ADD_END :2019/11/14 kitayama 理由：ログ
            //CHANGE_START :2020/2/20 kitayama 理由：破損エラー画像を考慮した条件に変更
            if(GetImagePathtextBox.Text == "" || SetImagePasthtextBox.Text == "" || IsoImagePathtextBox.Text=="")
            //if (GetImagePathtextBox.Text == "" || SetImagePasthtextBox.Text == "")
            //CHANGE_START :2020/2/20 kitayama 理由：破損エラー画像を考慮した条件に変更
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form2　設定ボタン＞取得先、保存先、エラー保存先が空白");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //メッセージボックスを表示する
                MessageBox.Show("「ファイル取得先フォルダ」 又は　「保存先フォルダ」、「破損エラー画像保存先」を入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form2　設定ボタン＞取得先と保存先が入力されている");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //メッセージボックスを表示する
                //DialogResult result = MessageBox.Show("設定を完了して宜しいでしょうか？",
                //    "質問",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Exclamation,
                //    MessageBoxDefaultButton.Button2);
                //ADD_START :2019/11/5 kitayama　理由設定の変更を反映するため、ソフトの終了後に再起動するようにメッセージを出す
                DialogResult result = MessageBox.Show("設定を反映させるためソフトを終了します。\r\n終了後にソフトを再起動してください。",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);
                //ADD_END :2019/11/5 kitayama　理由設定の変更を反映するため、ソフトの終了後に再起動するようにメッセージを出す

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form2　設定ボタン＞ソフト終了＞はい");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");

                    ///////////////////////////////////////////////////////////////////
                    ///     メイン画面のグローバル変数を更新する。
                    ///////////////////////////////////////////////////////////////////
                    MainWindow.sGetImagePath = GetImagePathtextBox.Text;                         //画像取得先パス　をグローバル変数に格納
                    MainWindow.sSetImagePath = SetImagePasthtextBox.Text;                        //画像保存先パス　を画面に表示
                    //ADD_START :2020/2/20 kitayama 理由：破損エラー画像保存先を追加
                    MainWindow.sIsoImagePath = IsoImagePathtextBox.Text;
                    //ADD_END :2020/2/20 kitayama 理由：破損エラー画像保存先を追加

                    MainWindow.iGetImageInterval = (int)GetImageIntervalNumericUpDown.Value;     //画画像取得周期（単位msec) を画面に表示
                    MainWindow.iMoveImageInterval = (int)MoveImageIntervalNumericUpDown.Value;   //画像移動周期（単位msec) を画面に表示

                    f1.GetImagePathlabel.Content = GetImagePathtextBox.Text;
                    f1.SetImagePathlabel.Content = SetImagePasthtextBox.Text;
                    //ADD_START :2020/2/20 kitayama 理由：破損エラー画像保存先を追加
                    f1.IsoImagePathlabel.Content = IsoImagePathtextBox.Text;
                    //ADD_END :2020/2/20 kitayama 理由：破損エラー画像保存先を追加

                    f1.GetImageIntervallabel.Content = GetImageIntervalNumericUpDown.Value.ToString();
                    f1.MoveImageIntervallabel.Content = MoveImageIntervalNumericUpDown.Value.ToString();

                    //ADD_START 2020/1/14 kitayama 理由：検査予定枚数0でも画像を表示するための待機時間を設定
                    MainWindow.iHoldTime = (int)holdUpDown1.Value;
                    //ADD_END 2020/1/14 kitayama 理由：検査予定枚数0でも画像を表示するための待機時間を設定
                    //ADD_START :2020/2/21 kitayama 理由：画像保存しきい値を追加
                    MainWindow.fBlankrate = (int)BlankUpDown1.Value;
                    //ADD_END :2020/2/21 kitayama 理由：画像保存しきい値を追加

                    //ADD_START 2020/1/16 kitayama 理由：設定した時間を画面に表示する
                    f1.HoldTimeLabel.Content = holdUpDown1.Value.ToString();
                    //ADD_END 2020/1/16 kitayama 理由：設定した時間を画面に表示する
                    

                    ///////////////////////////////////////////////////////////////////
                    ///     XMLを更新する。
                    ///////////////////////////////////////////////////////////////////
                    Change_XML change_XML;      //XML編集クラス
                    change_XML = new Change_XML();
                    change_XML.WriteXML();

                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form2　閉じる");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    Close();    //フォームを閉じる。
                    //ADD_START :2019/11/5 kitayama 理由：設定変更を反映するためにソフトを終了するようにする
                    f1.Close();
                    //ADD_END :2019/11/5 kitayama 理由：設定変更を反映するためにソフトを終了するようにする
                }
                else if (result == DialogResult.No)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form2　設定ボタン＞ソフト終了＞いいえ");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    //「いいえ」が選択された時
                    Console.WriteLine("「いいえ」が選択されました");

                }
                

            }
        }
    }
}
