using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Form4:品種設定画面を開く場合のパスワード入力画面
namespace Example.Runtime
{
    public partial class Form5 : Form
    {
        //ADD_START :2021/12/19 kitayama 理由：Form4を開くための処理を追加
        MainWindow f1;
        //ADD_END :2021/12/19 kitayama 理由：Form4を開くための処理を追加
        //CHANGE_START :2022/1/9 kitayama 理由：Form4にmainwindowの値を渡すためForm5が引数をとるように変更
        public Form5(MainWindow mainWindow)
        //public Form5()
        //CHANGE_END :2022/1/9 kitayama 理由：Form4にmainwindowの値を渡すためForm5が引数をとるように変更
        {
            InitializeComponent();
            //ADD_START :2022/1/9 kitayama 理由：Form4にmainwindowの値を渡すため追加
            f1 = mainWindow;
            //ADD_END :2022/1/9 kitayama 理由：Form4にmainwindowの値を渡すため追加

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 4;
            textBox1.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ADD_SATART:2022/2/5 kitayama 理由：管理者用パスワードを追加
            string master_pass = "admn";
            //ADD_END:2022/2/5 kitayama 理由：管理者用パスワードを追加

            string passw = textBox1.Text;
            System.IO.StreamReader sr = new System.IO.StreamReader(
               System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Password.ini", Encoding.UTF8);
            //ADD_START :2022/2/5 kitayama 理由：入力されたパスワードが数値か判定する処理を追加
            if (passw.All(char.IsDigit))
            {
                //入力されたパスワードが数値の場合
                //ADD_END :2022/2/5 kitayama 理由：入力されたパスワードが数値か判定する処理を追加
                string s = sr.ReadToEnd();
                s = s.Replace("\r", "").Replace("\n", "");

                //CHANGE_START :2022/2/5 kitayama 理由：管理者用パスワードを判定する処理を追加
                if (passw == s|| passw == master_pass)
                //if(passw == s)
                //CHANGE_END :2022/2/5 kitayama 理由：管理者用パスワードを判定する処理を追加
                {
                    Close();
                    //CHANGE_START :2021/12/19 kitayama 理由：パスワード入力時にForm4（品種設定）を開くように変更
                    //CHANGE_START :2021/11/27 kitayama 理由：パスワード入力時にMainwindowを開くように変更
                    //var mainWindow = new MainWindow();
                    //mainWindow.Show();
                    System.Windows.Forms.Form form = new Form4(f1);
                    form.Show();
                    //CHANGE_END :2021/11/27 kitayama 理由：パスワード入力時にMainwindowを開くように変更
                    //CHANGE_END :2021/12/19 kitayama 理由：パスワード入力時にForm4（品種設定）を開くように変更
                }
                else
                {
                    DialogResult result = MessageBox.Show("パスワードが違います。", "Error");
                }

            }
            //ADD_START :2022/2/5 kitayama 理由：入力されたパスワードが数値か判定する処理を追加
            else
            {
                //入力されたパスワードが数値ではない場合
                DialogResult result = MessageBox.Show("パスワードは数字のみを入力してください。", "Error");
            }
            //ADD_END :2022/2/5 kitayama 理由：入力されたパスワードが数値か判定する処理を追加
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
