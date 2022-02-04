using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CdioCs;

//外部入出力デバイスの信号割り当て画面
//MCプロトコル　信号の割り当てを表示するようにテキストを変更する
namespace　Example.Runtime
{
    public partial class Form3 : Form
    {
        //ADD_START :2019/11/11 kitayama 理由：log4netのインスタンス取得 
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //ADD_END :2019/11/11 kitayama 理由：log4netのインスタンス取得

        //ADD_START :2019/11/1 kawabata 理由：デジタル入出力処理追加
        Cdio Dio;
        //ADD_END :2019/11/1 kawabata 理由：デジタル入出力処理追加

        //ADD_START :2021/12/2 kitayama 理由：mainwindowに設定を反映するため追加
        MainWindow f1;
        //ADD_END :2021/12/2 kitayama 理由：mainwindowに設定を反映するため追加

        public Form3(MainWindow mainWindow, Cdio Dio)
        {
            InitializeComponent();
            //ADD_START :2021/12/2 kitayama 理由：mainwindowに設定を反映するため追加
            f1 = mainWindow;
            //ADD_END :2021/12/2 kitayama 理由：mainwindowに設定を反映するため追加

        }
        /// <summary>
        /// 閉じるボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ADD_START :2019/11/11 kitayama 理由：ログ
            logger.Debug("Form3　閉じる");
            //ADD_END :2019/11/11 kitayama 理由：ログ
            Close();    //フォームを閉じる。
        }
        /// <summary>
        /// リセットボタンを押せるようにするか制御する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_Load(object sender, EventArgs e)
        {
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form3　ロード");
            //ADD_END :2019/11/14 kitayama 理由：ログ
            Device_Name_label.Text = MainWindow.Device;      //デバイス名を表示

            //    //ADD_START :2019/11/1 kawabata 理由：デジタル入出力処理追加
            //    //デジタル入出力デバイスのインスタンスがあるか？
            //    if (Dio == null)
            //    {
            //        RestButton.Enabled = false;     //リセットボタン　押せなくする。。
            //        //ADD_START :2019/11/14 kitayama 理由：ログ
            //        logger.Debug($"Form3　(Dio==null)={Dio == null}(true)  RestButton.Enabled ={RestButton.Enabled}");
            //        //ADD_END :2019/11/14 kitayama 理由：ログ
            //    }
            //    else
            //    {
            //        RestButton.Enabled = true;     //リセットボタン　押せる。                               
            //        //ADD_START :2019/11/14 kitayama 理由：ログ
            //        logger.Debug($"Form3　(Dio==null)={Dio == null}(false)  RestButton.Enabled ={RestButton.Enabled}");
            //        //ADD_END :2019/11/14 kitayama 理由：ログ
            //    }
            //    //ADD_END :2019/11/1 kawabata 理由：デジタル入出力処理追加
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        //ADD_START :2021/12/2 kitayama 理由：画像保存先設定処理を追加
        private void set_button_Click(object sender, EventArgs e)
        {
            if(OK_Imagebox.Text==""|Inter_Imagebox.Text==""| NG_Imagebox.Text=="")
            {
                //保存先が入力されていないとエラーとする
                MessageBox.Show("入力されていない保存先があります。すべての画像保存先を入力してください。",
                   "エラー",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else
            {
                //設定内容をxmlファイルに反映する
                Change_XML change_XML;
                change_XML = new Change_XML();
                change_XML.WriteXML();

                //mainwindowの変数に入力された内容を設定する
                MainWindow.sImagePath[0] = OK_Imagebox.Text;
                MainWindow.sImagePath[1] = Inter_Imagebox.Text;
                MainWindow.sImagePath[2] = NG_Imagebox.Text;

                MessageBox.Show("画像保存先を設定しました。","設定", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        //ADD_END :2021/12/2 kitayama 理由：画像保存先設定処理を追加

        //ADD_START :2019/11/1 kawabata 理由：リセットボタン追加
        /// <summary>
        /// 出力リセットボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void RestButton_Click(object sender, EventArgs e)
        //{
        //    //ADD_START :2019/11/14 kitayama 理由：ログ
        //    logger.Debug("Form3　リセットボタン");
        //    //ADD_END :2019/11/14 kitayama 理由：ログ

        //    int iRet = 0;
        //    //メッセージボックスを表示する
        //    DialogResult result = MessageBox.Show("出力信号を全てOFFにして宜しいでしょうか？",
        //        "質問",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Exclamation,
        //        MessageBoxDefaultButton.Button2);

        //    //何が選択されたか調べる
        //    if (result == DialogResult.Yes)
        //    {
        //        //ADD_START :2019/11/11 kitayama 理由：ログ
        //        logger.Info("Form3 リセットボタン＞はい＞出力リセット");
        //        //ADD_END :2019/11/11 kitayama 理由：ログ

        //        //出力BITをすべてOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 0, 0);            //REDY信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 1, 0);            //検査中信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 2, 0);            //OK信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 3, 0);            //NG信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 4, 0);            //品種信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 5, 0);            //品種信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 6, 0);            //品種信号をOFF
        //        iRet = Dio.OutBit(MainWindow.sIndex, 7, 0);            //品種信号をOFF
        //    }else
        //    {
        //        //リセットしない。
        //        //ADD_START :2019/11/14 kitayama 理由：ログ
        //        logger.Debug($"Form3　リセットボタン＞いいえ＞出力リセットしない");
        //        //ADD_END :2019/11/14 kitayama 理由：ログ
        //    }
        //}
        //ADD_END :2019/11/1 kawabata 理由：リセットボタン追加
    }
}
