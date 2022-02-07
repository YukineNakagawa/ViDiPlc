using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//DELETE_START :2022/1/30 kitayama 理由：DIOは使用しないので削除
//using CdioCs;
//DELETE_END :2022/1/30 kitayama 理由：DIOは使用しないので削除


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
        //Cdio Dio;
        //ADD_END :2019/11/1 kawabata 理由：デジタル入出力処理追加

        //ADD_START :2021/12/2 kitayama 理由：mainwindowに設定を反映するため追加
        MainWindow f1;
        //ADD_END :2021/12/2 kitayama 理由：mainwindowに設定を反映するため追加

        public Form3(MainWindow mainWindow)
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

        private void set_button2_Click(object sender, EventArgs e)
        {
            if (OK_Imagebox2.Text == "" | Inter_Imagebox2.Text == "" | NG_Imagebox2.Text == "")
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
                MainWindow.sImagePath[3] = OK_Imagebox2.Text;
                MainWindow.sImagePath[4] = Inter_Imagebox2.Text;
                MainWindow.sImagePath[5] = NG_Imagebox2.Text;

                MessageBox.Show("画像保存先を設定しました。", "設定", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        //ADD_END :2021/12/2 kitayama 理由：画像保存先設定処理を追加


        //DELETE_START :2022/2/5 kitayama 理由：今回は実装しない方針なので削除
        ////ADD_START :2022/1/30 kitayama 理由：画像削除機能を追加
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    DateTime dt = new DateTime();
        //    dt = DateTime.Now;

        //    //OK画像保存フォルダ内の画像を古い順に取得
        //    string[] okfiles = Directory.GetFiles(MainWindow.sImagePath[0],$"*.{MainWindow.file_ext}")
        //        .OrderBy(f => File.GetCreationTime(f)).ToArray();

        //    //ファイル削除用ループ
        //    foreach (string str in okfiles)
        //    {
        //        if (File.GetCreationTime(str) <= dt.AddDays(-(int)numericUpDown1.Value))
        //        {
        //            //ファイルが指定日付より古い場合は削除する
        //            File.Delete(str);
        //        }
        //        else 
        //        {
        //            //古い順に見ているため、指定日付より新しいファイルが出てきた時点で削除用ループを抜ける
        //            break;
        //        }
        //    }
        //}
        ////ADD_END :2022/1/30 kitayama 理由：画像削除機能を追加
        //DELETE_END :2022/2/5 kitayama 理由：今回は実装しない方針なので削除

    }
}
