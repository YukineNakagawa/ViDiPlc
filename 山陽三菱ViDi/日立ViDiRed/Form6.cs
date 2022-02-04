using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows.Forms;

namespace Example.Runtime
{
    /// <summary>
    ///ADD_START :2021/11/7 kitayama 理由：結果表示一覧画面を追加
    /// </summary>
    public partial class Form6 : Form
    {
        //log4netのインスタンス取得
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        MainWindow f6;

        public Form6(MainWindow mainWindow)
        {
            InitializeComponent();
            f6 = mainWindow;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //リストビューの表示をDetailsに設定する
            listView1.View = View.Details;

            listView1.Columns.Add("検査番号", 80, HorizontalAlignment.Center);
            //CHANGE_START :2021/11/7 kitayama 理由：表示を30行＊10列の形式にするのでリストの初期化方法を変更
            //listView1.Columns.Add("スコア", 60, HorizontalAlignment.Center);
            //listView1.Columns.Add("判定", 60, HorizontalAlignment.Center);
            for (int j = 0; j < 10; j++)
            {
                //10列分のヘッダーを設定する
                listView1.Columns.Add("", 60, HorizontalAlignment.Center);
            }
            //CHANGE_END :2021/11/7 kitayama 理由：表示を30行＊10列の形式にするのでリストの初期化方法を変更

        }

        //MainWindowの判定結果を格納しているv_kekkaの内容を30行*10列の形式で表示する
        //v_kekka[1,n]にはスコア、v_kekka[2,n]には判定、v_kekka[3,n]には処理時間を格納している
        //300件表示が可能か？
        private void Disp_TimerMethod(object sender,EventArgs e) 
        {
            //処理の初めにリストをクリアする
            listView1.Items.Clear();

            ListViewItem items = new ListViewItem();


            //DELETE_START :2021/12/2 kitayama 理由：Form6は使用しないので削除
            //listviewの追加項目にv_kekkaの内容を設定する
            //for (int j = 0; j < MainWindow.v_kekka.Length; j++) 
            //{
            //    //ADD_START :2021/11/7 kitayama 理由：n行*10列の形式で表示するため判定処理を追加
            //    if (j % 10 == 0)
            //    {
            //        //10ループごとに検査番号を設定する
            //        items.Text = $"{j}～{j + 9}";
            //    }
            //    //ADD_END :2021/11/7 kitayama 理由：n行*10列の形式で表示するため判定処理を追加


            //    if (MainWindow.v_kekka[2, j] == 0)
            //    {
            //        //v_kekka[2,j]==0の箇所は未処理なので表示処理を終了するためループを抜ける
            //        break;
            //    }
            //    else
            //    {
            //        //DELETE_START :2021/11/7 kitayama 理由：検査番号は別の箇所で表示処理を行うので削除
            //        items.Text= $"{j}";
            //        //DELETE_END :2021/11/7 kitayama 理由：検査番号は別の箇所で表示処理を行うので削除
            //        items.SubItems.Add(MainWindow.v_kekka[1, j].ToString());
            //        //v_kekka[2.j]の内容をOK/NG表示に変換する
            //        if (MainWindow.v_kekka[2, j] == 1)
            //        {
            //            items.SubItems.Add("OK");
            //        }
            //        else if(MainWindow.v_kekka[2, j] == -1)
            //        {
            //            items.SubItems.Add("NG");
            //        }
            //    }

            //}
            //DELETE_END :2021/12/2 kitayama 理由：Form6は使用しないので削除

            //listviweに項目を追加
            listView1.Items.Add(items);
        }


        // タイマのインスタンス　
        private DispatcherTimer _timer;

        /// <summary>
        /// 検査結果タイマを設定する
        /// </summary>
        private void SetupTimer()
        {
            // タイマのインスタンスを生成
            _timer = new DispatcherTimer();

            // インターバルを設定
            //MEMO :2021/11/7 kitayamaとりあえず100msで設定
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            logger.Info($"取得タイマインターバル：{_timer.Interval}");

            // タイマメソッドを設定
            _timer.Tick += new EventHandler(Disp_TimerMethod);
            // タイマを開始
            _timer.Start();

            // 画面が閉じられるときに、タイマを停止
            this.Closing += new CancelEventHandler(StopTimer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            Close();  
        }
        private void StopTimer(object sender, CancelEventArgs e)
        {
            _timer.Stop();
            logger.Info($"Form6:タイマ停止");
        }

    }
}
