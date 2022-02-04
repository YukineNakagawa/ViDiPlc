using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Example.Runtime
{
    public partial class Form4 : Form
    {
        //ADD_START :2019/11/8 kitayama 理由：log4netのインスタンス取得
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //ADD_END :2019/11/8 kitayama 理由：log4netのインスタンス取得

        //ADD_START :2021/11/21 kitayama 理由：パスワード設定用のフラグを追加
        bool passflag = false;
        //ADD_END :2021/11/21 kitayama 理由：パスワード設定用のフラグを追加

        MainWindow f1;
        public Form4(MainWindow mainWindow)
        {
            InitializeComponent();
            f1 = mainWindow;
        }

        /// <summary>
        /// MainWindowの配列から品種、ワークスペース、判定閾値を取得する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {

            //ADD_START :2021/11/21 kitayama 理由：パスワード再設定用のテキストボックスを追加
            textBox1.Enabled = false;
            textBox1.MaxLength = 4;
            textBox1.PasswordChar = '*';
            //ADD_END :2021/11/21 kitayama 理由：パスワード再設定用のテキストボックスを追加


            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug($"Form4　ロード");
            //ADD_END :2019/11/14 kitayama 理由：ログ

            //グローバル変数から読み出す
            //品種名表示
            Kishu_textBox1.Text = MainWindow.sKishu[0];
            Kishu_textBox2.Text = MainWindow.sKishu[1];
            Kishu_textBox3.Text = MainWindow.sKishu[2];
            Kishu_textBox4.Text = MainWindow.sKishu[3];
            Kishu_textBox5.Text = MainWindow.sKishu[4];
            Kishu_textBox6.Text = MainWindow.sKishu[5];
            Kishu_textBox7.Text = MainWindow.sKishu[6];
            Kishu_textBox8.Text = MainWindow.sKishu[7];
            Kishu_textBox9.Text = MainWindow.sKishu[8];
            Kishu_textBox10.Text = MainWindow.sKishu[9];

            //ワークスペース　ファイル名表示
            WorkSpece1.Text = MainWindow.sWorkspece[0];
            WorkSpece2.Text = MainWindow.sWorkspece[1];
            WorkSpece3.Text = MainWindow.sWorkspece[2];
            WorkSpece4.Text = MainWindow.sWorkspece[3];
            WorkSpece5.Text = MainWindow.sWorkspece[4];
            WorkSpece6.Text = MainWindow.sWorkspece[5];
            WorkSpece7.Text = MainWindow.sWorkspece[6];
            WorkSpece8.Text = MainWindow.sWorkspece[7];
            WorkSpece9.Text = MainWindow.sWorkspece[8];
            WorkSpece10.Text = MainWindow.sWorkspece[9];

            
        }

        /// <summary>
        /// 設定ボタンを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_button_Click(object sender, EventArgs e)
        {
            //ADD_START :2019/11/11 kitayama 理由：ログ
            logger.Debug("Form4　設定ボタン");
            //ADD_END :2019/11/11 kitayama 理由：ログ

            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("設定を完了して宜しいでしょうか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　設定ボタン＞はい");
                //ADD_END :2019/11/14 kitayama 理由：ログ

                //「はい」が選択された時
                Console.WriteLine("「はい」が選択されました");

                //ワークスペース名に拡張子が入っているか？
                if (check_Workspece() == true)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　設定ボタン＞はい＞ワークスペース拡張子確認(check_Workspace=true)＞グローバル変数に書き込み");
                    //ADD_END :2019/11/14 kitayama 理由：ログ

                    //グローバル変数に格納
                    //品種名表示
                    MainWindow.sKishu[0] = Kishu_textBox1.Text;
                    MainWindow.sKishu[1] = Kishu_textBox2.Text;
                    MainWindow.sKishu[2] = Kishu_textBox3.Text;
                    MainWindow.sKishu[3] = Kishu_textBox4.Text;
                    MainWindow.sKishu[4] = Kishu_textBox5.Text;
                    MainWindow.sKishu[5] = Kishu_textBox6.Text;
                    MainWindow.sKishu[6] = Kishu_textBox7.Text;
                    MainWindow.sKishu[7] = Kishu_textBox8.Text;
                    MainWindow.sKishu[8] = Kishu_textBox9.Text;
                    MainWindow.sKishu[9] = Kishu_textBox10.Text;

                    //ワークスペース　ファイル名表示
                    MainWindow.sWorkspece[0] = WorkSpece1.Text;
                    MainWindow.sWorkspece[1] = WorkSpece2.Text;
                    MainWindow.sWorkspece[2] = WorkSpece3.Text;
                    MainWindow.sWorkspece[3] = WorkSpece4.Text;
                    MainWindow.sWorkspece[4] = WorkSpece5.Text;
                    MainWindow.sWorkspece[5] = WorkSpece6.Text;
                    MainWindow.sWorkspece[6] = WorkSpece7.Text;
                    MainWindow.sWorkspece[7] = WorkSpece8.Text;
                    MainWindow.sWorkspece[8] = WorkSpece9.Text;
                    MainWindow.sWorkspece[9] = WorkSpece10.Text;


                    f1.Kishu_ComboBox.Items.Clear();            //品種コンボボックスのクリア

                    //品種　コンボボックスにデータを反映
                    //ADD_START :2019/12/16 kitayama 理由：コンボボックスの一番上を開ける必要があるので再度追加
                    //DELETE_START :2019/11/6 kitayama 理由：コンボボックスの最上段を開けなくても不都合がなさそうなので削除
                    //ADD_START :2019/11/6 kitayama 理由：コンボボックスの品種とワークスペースが対応していなかったので、ここで-を追加して対応がとれるようにする
                    f1.Kishu_ComboBox.Items.Add("-");
                    //ADD_END :2019/11/6 kitayama 理由：コンボボックスの品種とワークスペースが対応していなかったので、ここで-を追加して対応がとれるようにする
                    //DELETE_END :2019/11/6 kitayama 理由：コンボボックスの最上段を開けなくても不都合がなさそうなので削除
                    //ADD_END :2019/12/16 kitayama 理由：コンボボックスの一番上を開ける必要があるので再度追加
                    for (int i = 0; i < 10; i++)
                    {
                        //ADD_START :2019/11/11 kitayama 理由：ログ
                        logger.Info($"Form4品種設定：index={i}、品種：{MainWindow.sKishu[i]}");
                        //ADD_END :2019/11/11 kitayama 理由：ログ

                        f1.Kishu_ComboBox.Items.Add(MainWindow.sKishu[i]);

                    }

                    ///////////////////////////////////////////////////////////////////
                    ///     XMLを更新する。
                    ///////////////////////////////////////////////////////////////////
                    Change_XML change_XML;      //XML編集クラス
                    change_XML = new Change_XML();
                    change_XML.WriteXML();

                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　閉じる");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    Close();    //フォームを閉じる。
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Error("Form4　設定ボタン＞はい＞ワークスペース拡張子確認(check_Workspace=false)＞エラーメッセージ");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    //メッセージボックスを表示する
                    MessageBox.Show("ワークスペースは拡張子まで入力してください。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else if (result == DialogResult.No)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　設定ボタン＞いいえ");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //「いいえ」が選択された時
                Console.WriteLine("「いいえ」が選択されました");
            }
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form4　閉じる");
            //ADD_END :2019/11/14 kitayama 理由：ログ
            Close();    //フォームを閉じる。
        }

        /// <summary>
        /// キャンセルボタンを押したときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form4　キャンセルボタン");
            //ADD_END :2019/11/14 kitayama 理由：ログ
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("設定せずに品種設定画面を閉じますか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　キャンセルボタン＞はい");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //「はい」が選択された時
                Console.WriteLine("「はい」が選択されました");
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　閉じる");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                Close();    //フォームを閉じる。
            }
            else if (result == DialogResult.No)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　キャンセルボタン＞いいえ");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                //「いいえ」が選択された時
                Console.WriteLine("「いいえ」が選択されました");
            }
        }

        /// <summary>
        /// 品種名、ワークスペースが入力されているか確認する
        /// </summary>
        /// <returns></returns>
        private bool check_Workspece()
        {                    
            //ADD_START :2019/11/14 kitayama 理由：ログ
            logger.Debug("Form4　check_Workspace");
            //ADD_END :2019/11/14 kitayama 理由：ログ
            
            int bCheck = 0;
            if (Kishu_textBox1.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種1に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece1.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }

            if (Kishu_textBox2.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種2に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece2.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {                    
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox3.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種3に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece3.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox4.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種4に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece4.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {                    
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox5.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種5に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece5.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox6.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種6に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece6.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox7.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種7に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece7.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox8.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種8に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece8.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox9.Text.Length > 0)
            {                
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種9に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                
                if (WorkSpece9.Text.IndexOf(".vrws") > 0)
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }
            if (Kishu_textBox10.Text.Length > 0)
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種10に入力がある(Length>0)");
                //ADD_END :2019/11/14 kitayama 理由：ログ

                if (WorkSpece10.Text.IndexOf(".vrws") > 0)
                {

                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれている");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    bCheck = 1;
                }
                else
                {
                    //ADD_START :2019/11/14 kitayama 理由：ログ
                    logger.Debug("Form4　check_Workspace＞ワークスペース名に\".vrws\"が含まれていない");
                    //ADD_END :2019/11/14 kitayama 理由：ログ
                    return false;
                }
            }

            //全ての品種名の入力が無い
            if (bCheck == 0)
            {                    
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞品種名の入力が無い");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                return true;        //書き込みしてもよい
            }
            else if (bCheck == 1)    //".vrws"があった。
            {
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞\".vrws\"があった＞書き込み許可");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                return true;        //書き込みしてもよい

            }
            else
            {                
                //ADD_START :2019/11/14 kitayama 理由：ログ
                logger.Debug("Form4　check_Workspace＞書き込み不可");
                //ADD_END :2019/11/14 kitayama 理由：ログ
                return false;       //書き込みしたらアカン
            }
            //エラーを出す条件のメモ
            //品種名が空白は許すが、ワークスペースが空白は許さない
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //ADD_START :2020/4/27 kitayama 理由：しきい値設定画面を開くボタンを追加
        private void button2_Click(object sender, EventArgs e)
        {

            //設定したい品種番号をkishunoに格納
            MainWindow.kishuno =(int)KishuNo.Value;
            //しきい値設定画面のパスワード入力フォームを開く
            //CHANGE_START :2021/11/27 kitayama 理由：Form1を開くように変更
            System.Windows.Forms.Form form = new Form1(this);
            //System.Windows.Forms.Form form = new Form5();
            //CHANGE_ＥＮＤ :2021/11/27 kitayama 理由：Form1を開くように変更
            form.Show();
        }
        //ADD_END :2020/4/27 kitayama 理由：しきい値設定画面を開くボタンを追加


        //ADD_START :2021/11/21 kitayama 理由：パスワード設定の処理を追加
        private void pass_button_Click(object sender, EventArgs e)
        {
            if (passflag == false)
            {
                //"パスワード設定"のボタンを押すと、テキストを入力可能にする
                textBox1.Enabled = true;
                pass_button.Text = "パスワード変更";
                passflag = true;
            }
            else
            {
                if (textBox1.Text.Length == 4)
                {
                    //パスワードとして入力された文字が４文字の場合はパスワード設定処理を行う

                    DialogResult result = MessageBox.Show("しきい値設定画面のパスワードを変更しますか？",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        //"パスワード変更"＞はいのボタンを押すと、iniファイルの内容を上書きし、テキストボックスとボタンの表示を元に戻す
                        //テキストボックスの入力内容をiniファイルに上書きする
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Password.ini", false, Encoding.UTF8);


                        sw.WriteLine(textBox1.Text);

                        sw.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        //いいえの時はiniファイルを変更しない
                    }

                }
                else
                {
                    //入力された文字が4文字でない場合はメッセージを表示する
                    MessageBox.Show("パスワードは4文字で入力してください。",
                        "確認",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }

                textBox1.Clear();
                textBox1.Enabled = false;
                pass_button.Text = "パスワード設定";
                passflag = false;

            }
        }
        //ADD_END :2021/11/21 kitayama 理由：パスワード設定の処理を追加

        
    }
}
