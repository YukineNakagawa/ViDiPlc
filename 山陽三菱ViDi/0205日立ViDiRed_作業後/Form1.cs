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
    /// <summary>
    ///ADD_START :2020/4/27 kitayama 理由：しきい値設定画面を追加
    /// </summary>
    public partial class Form1 : Form
    {
        //log4netのインスタンス取得
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //ADD_START :2020/5/14 kitayama 理由：パスワード設定用のフラグを追加
        bool passflag = false;
        //ADD_END :2020/5/14 kitayama 理由：パスワード設定用のフラグを追加

        //CHANGE_START :2021/11/27 kitayama 理由：Form4から開くように変更
        public Form1(Form4 form4)
        {
            InitializeComponent();

        }
        //public Form1(Form5 form5)
        //{
        //    InitializeComponent();

        //}
        //CHANGE_END :2021/11/27 kitayama 理由：Form4から開くように変更

        private void Form1_Load(object sender, EventArgs e)
        {
            //DELETE_START :2021/11/21 kitayama 理由：パスワード設定処理はForm4に移すので削除
            ////ADD_START :2020/5/14 kitayama 理由：パスワード再設定用のテキストボックスを追加
            //textBox1.Enabled = false;
            //textBox1.MaxLength = 4;
            //textBox1.PasswordChar = '*';
            ////ADD_END :2020/5/14 kitayama 理由：パスワード再設定用のテキストボックスを追加
            //DELETE_END :2021/11/21 kitayama 理由：パスワード設定処理はForm4に移すので削除


            //しきい値を読み出す

            int yy = MainWindow.kishuno;
            Titlelabel.Text = ($"品種{MainWindow.kishuno}:{MainWindow.sKishu[MainWindow.kishuno-1]}のしきい値設定");

            //CHANGE_START :2021/11/25 kitayama 理由：しきい値の上限下限を設定できるように配列を変更・追加
            //ADD_START :2021/11/7 kitayama 理由：今回使用する閾値設定を追加
            //Stream1
            numericUpDown_u00.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 0]);
            numericUpDown_u01.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 1]);
            numericUpDown_u02.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 2]);
            numericUpDown_u03.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 3]);
            numericUpDown_u04.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 4]);
            numericUpDown_u05.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 5]);
            numericUpDown_u06.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 6]);
            numericUpDown_u07.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 7]);
            numericUpDown_u08.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 8]);
            numericUpDown_u09.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 9]);

            numericUpDown_l00.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 0]);
            numericUpDown_l01.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 1]);
            numericUpDown_l02.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 2]);
            numericUpDown_l03.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 3]);
            numericUpDown_l04.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 4]);
            numericUpDown_l05.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 5]);
            numericUpDown_l06.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 6]);
            numericUpDown_l07.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 7]);
            numericUpDown_l08.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 8]);
            numericUpDown_l09.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 9]);

            //Stream2
            numericUpDown_u10.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 0]);
            numericUpDown_u11.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 1]);
            numericUpDown_u12.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 2]);
            numericUpDown_u13.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 3]);
            numericUpDown_u14.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 4]);
            numericUpDown_u15.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 5]);
            numericUpDown_u16.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 6]);
            numericUpDown_u17.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 7]);
            numericUpDown_u18.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 8]);
            numericUpDown_u19.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 9]);

            numericUpDown_l10.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 0]);
            numericUpDown_l11.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 1]);
            numericUpDown_l12.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 2]);
            numericUpDown_l13.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 3]);
            numericUpDown_l14.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 4]);
            numericUpDown_l15.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 5]);
            numericUpDown_l16.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 6]);
            numericUpDown_l17.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 7]);
            numericUpDown_l18.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 8]);
            numericUpDown_l19.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 9]);

            //Stream3
            numericUpDown_u20.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 0]);
            numericUpDown_u21.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 1]);
            numericUpDown_u22.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 2]);
            numericUpDown_u23.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 3]);
            numericUpDown_u24.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 4]);
            numericUpDown_u25.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 5]);
            numericUpDown_u26.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 6]);
            numericUpDown_u27.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 7]);
            numericUpDown_u28.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 8]);
            numericUpDown_u29.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 9]);

            numericUpDown_l20.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 0]);
            numericUpDown_l21.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 1]);
            numericUpDown_l22.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 2]);
            numericUpDown_l23.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 3]);
            numericUpDown_l24.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 4]);
            numericUpDown_l25.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 5]);
            numericUpDown_l26.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 6]);
            numericUpDown_l27.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 7]);
            numericUpDown_l28.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 8]);
            numericUpDown_l29.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 9]);

            //Stream4
            numericUpDown_u30.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 0]);
            numericUpDown_u31.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 1]);
            numericUpDown_u32.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 2]);
            numericUpDown_u33.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 3]);
            numericUpDown_u34.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 4]);
            numericUpDown_u35.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 5]);
            numericUpDown_u36.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 6]);
            numericUpDown_u37.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 7]);
            numericUpDown_u38.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 8]);
            numericUpDown_u39.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 9]);

            numericUpDown_l30.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 0]);
            numericUpDown_l31.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 1]);
            numericUpDown_l32.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 2]);
            numericUpDown_l33.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 3]);
            numericUpDown_l34.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 4]);
            numericUpDown_l35.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 5]);
            numericUpDown_l36.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 6]);
            numericUpDown_l37.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 7]);
            numericUpDown_l38.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 8]);
            numericUpDown_l39.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 9]);

            //Stream5
            numericUpDown_u40.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 0]);
            numericUpDown_u41.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 1]);
            numericUpDown_u42.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 2]);
            numericUpDown_u43.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 3]);
            numericUpDown_u44.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 4]);
            numericUpDown_u45.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 5]);
            numericUpDown_u46.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 6]);
            numericUpDown_u47.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 7]);
            numericUpDown_u48.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 8]);
            numericUpDown_u49.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 9]);

            numericUpDown_l40.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 0]);
            numericUpDown_l41.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 1]);
            numericUpDown_l42.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 2]);
            numericUpDown_l43.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 3]);
            numericUpDown_l44.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 4]);
            numericUpDown_l45.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 5]);
            numericUpDown_l46.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 6]);
            numericUpDown_l47.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 7]);
            numericUpDown_l48.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 8]);
            numericUpDown_l49.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 9]);

            //Stream6
            numericUpDown_u50.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 0]);
            numericUpDown_u51.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 1]);
            numericUpDown_u52.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 2]);
            numericUpDown_u53.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 3]);
            numericUpDown_u54.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 4]);
            numericUpDown_u55.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 5]);
            numericUpDown_u56.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 6]);
            numericUpDown_u57.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 7]);
            numericUpDown_u58.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 8]);
            numericUpDown_u59.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 9]);

            numericUpDown_l50.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 0]);
            numericUpDown_l51.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 1]);
            numericUpDown_l52.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 2]);
            numericUpDown_l53.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 3]);
            numericUpDown_l54.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 4]);
            numericUpDown_l55.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 5]);
            numericUpDown_l56.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 6]);
            numericUpDown_l57.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 7]);
            numericUpDown_l58.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 8]);
            numericUpDown_l59.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 9]);

            //Stream7
            numericUpDown_u60.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 0]);
            numericUpDown_u61.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 1]);
            numericUpDown_u62.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 2]);
            numericUpDown_u63.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 3]);
            numericUpDown_u64.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 4]);
            numericUpDown_u65.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 5]);
            numericUpDown_u66.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 6]);
            numericUpDown_u67.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 7]);
            numericUpDown_u68.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 8]);
            numericUpDown_u69.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 9]);

            numericUpDown_l60.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 0]);
            numericUpDown_l61.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 1]);
            numericUpDown_l62.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 2]);
            numericUpDown_l63.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 3]);
            numericUpDown_l64.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 4]);
            numericUpDown_l65.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 5]);
            numericUpDown_l66.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 6]);
            numericUpDown_l67.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 7]);
            numericUpDown_l68.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 8]);
            numericUpDown_l69.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 9]);

            //Stream8
            numericUpDown_u70.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 0]);
            numericUpDown_u71.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 1]);
            numericUpDown_u72.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 2]);
            numericUpDown_u73.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 3]);
            numericUpDown_u74.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 4]);
            numericUpDown_u75.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 5]);
            numericUpDown_u76.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 6]);
            numericUpDown_u77.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 7]);
            numericUpDown_u78.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 8]);
            numericUpDown_u79.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 9]);

            numericUpDown_l70.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 0]);
            numericUpDown_l71.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 1]);
            numericUpDown_l72.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 2]);
            numericUpDown_l73.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 3]);
            numericUpDown_l74.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 4]);
            numericUpDown_l75.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 5]);
            numericUpDown_l76.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 6]);
            numericUpDown_l77.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 7]);
            numericUpDown_l78.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 8]);
            numericUpDown_l79.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 9]);

            //Stream9
            numericUpDown_u80.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 0]);
            numericUpDown_u81.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 1]);
            numericUpDown_u82.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 2]);
            numericUpDown_u83.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 3]);
            numericUpDown_u84.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 4]);
            numericUpDown_u85.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 5]);
            numericUpDown_u86.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 6]);
            numericUpDown_u87.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 7]);
            numericUpDown_u88.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 8]);
            numericUpDown_u89.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 9]);

            numericUpDown_l80.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 0]);
            numericUpDown_l81.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 1]);
            numericUpDown_l82.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 2]);
            numericUpDown_l83.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 3]);
            numericUpDown_l84.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 4]);
            numericUpDown_l85.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 5]);
            numericUpDown_l86.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 6]);
            numericUpDown_l87.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 7]);
            numericUpDown_l88.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 8]);
            numericUpDown_l89.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 9]);

            //Stream10
            numericUpDown_u90.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 0]);
            numericUpDown_u91.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 1]);
            numericUpDown_u92.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 2]);
            numericUpDown_u93.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 3]);
            numericUpDown_u94.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 4]);
            numericUpDown_u95.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 5]);
            numericUpDown_u96.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 6]);
            numericUpDown_u97.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 7]);
            numericUpDown_u98.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 8]);
            numericUpDown_u99.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 9]);

            numericUpDown_l90.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 0]);
            numericUpDown_l91.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 1]);
            numericUpDown_l92.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 2]);
            numericUpDown_l93.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 3]);
            numericUpDown_l94.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 4]);
            numericUpDown_l95.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 5]);
            numericUpDown_l96.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 6]);
            numericUpDown_l97.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 7]);
            numericUpDown_l98.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 8]);
            numericUpDown_l99.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 9]);

            //Stream11
            numericUpDown_uA0.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 0]);
            numericUpDown_uA1.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 1]);
            numericUpDown_uA2.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 2]);
            numericUpDown_uA3.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 3]);
            numericUpDown_uA4.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 4]);
            numericUpDown_uA5.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 5]);
            numericUpDown_uA6.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 6]);
            numericUpDown_uA7.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 7]);
            numericUpDown_uA8.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 8]);
            numericUpDown_uA9.Value = Convert.ToDecimal(MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 9]);

            numericUpDown_lA0.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 0]);
            numericUpDown_lA1.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 1]);
            numericUpDown_lA2.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 2]);
            numericUpDown_lA3.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 3]);
            numericUpDown_lA4.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 4]);
            numericUpDown_lA5.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 5]);
            numericUpDown_lA6.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 6]);
            numericUpDown_lA7.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 7]);
            numericUpDown_lA8.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 8]);
            numericUpDown_lA9.Value = Convert.ToDecimal(MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 9]);

            //ADD_END :2021/11/7 kitayama 理由：今回使用する閾値設定を追加
            //CHANGE_END :2021/11/25 kitayama 理由：しきい値の上限下限を設定できるように配列を変更・追加

            //DELETE_START :2021/12/19 kitayama 理由：名称は使用しないので削除
            //ADD_START :2021/11/25 kitayama 理由：検査名称を読みだす処理を追加
            ////Stream1
            //textBox01.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 0];
            //textBox02.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 1];
            //textBox03.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 2];
            //textBox04.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 3];
            //textBox05.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 4];
            //textBox06.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 5];
            //textBox07.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 6];
            //textBox08.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 7];
            //textBox09.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 8];
            //textBox0A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 9];

            ////Stream2
            //textBox11.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 0];
            //textBox12.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 1];
            //textBox13.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 2];
            //textBox14.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 3];
            //textBox15.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 4];
            //textBox16.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 5];
            //textBox17.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 6];
            //textBox18.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 7];
            //textBox19.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 8];
            //textBox1A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 9];

            ////Stream3
            //textBox21.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 0];
            //textBox22.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 1];
            //textBox23.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 2];
            //textBox24.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 3];
            //textBox25.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 4];
            //textBox26.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 5];
            //textBox27.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 6];
            //textBox28.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 7];
            //textBox29.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 8];
            //textBox2A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 9];

            ////Stream4
            //textBox31.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 0];
            //textBox32.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 1];
            //textBox33.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 2];
            //textBox34.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 3];
            //textBox35.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 4];
            //textBox36.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 5];
            //textBox37.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 6];
            //textBox38.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 7];
            //textBox39.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 8];
            //textBox3A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 9];

            ////Stream5
            //textBox41.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 0];
            //textBox42.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 1];
            //textBox43.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 2];
            //textBox44.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 3];
            //textBox45.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 4];
            //textBox46.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 5];
            //textBox47.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 6];
            //textBox48.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 7];
            //textBox49.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 8];
            //textBox4A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 9];

            ////Stream6
            //textBox51.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 0];
            //textBox52.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 1];
            //textBox53.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 2];
            //textBox54.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 3];
            //textBox55.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 4];
            //textBox56.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 5];
            //textBox57.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 6];
            //textBox58.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 7];
            //textBox59.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 8];
            //textBox5A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 9];

            ////Stream7
            //textBox61.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 0];
            //textBox62.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 1];
            //textBox63.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 2];
            //textBox64.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 3];
            //textBox65.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 4];
            //textBox66.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 5];
            //textBox67.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 6];
            //textBox68.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 7];
            //textBox69.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 8];
            //textBox6A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 9];

            ////Stream8
            //textBox71.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 0];
            //textBox72.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 1];
            //textBox73.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 2];
            //textBox74.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 3];
            //textBox75.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 4];
            //textBox76.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 5];
            //textBox77.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 6];
            //textBox78.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 7];
            //textBox79.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 8];
            //textBox7A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 9];

            ////Stream9
            //textBox81.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 0];
            //textBox82.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 1];
            //textBox83.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 2];
            //textBox84.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 3];
            //textBox85.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 4];
            //textBox86.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 5];
            //textBox87.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 6];
            //textBox88.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 7];
            //textBox89.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 8];
            //textBox8A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 9];

            ////Stream10
            //textBox91.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 0];
            //textBox92.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 1];
            //textBox93.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 2];
            //textBox94.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 3];
            //textBox95.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 4];
            //textBox96.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 5];
            //textBox97.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 6];
            //textBox98.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 7];
            //textBox99.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 8];
            //textBox9A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 9];

            ////Stream11
            //textBox101.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 0];
            //textBox102.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 1];
            //textBox103.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 2];
            //textBox104.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 3];
            //textBox105.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 4];
            //textBox106.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 5];
            //textBox107.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 6];
            //textBox108.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 7];
            //textBox109.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 8];
            //textBox10A.Text = MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 9];
            ////ADD_END :2021/11/25 kitayama 理由：検査名称を読みだす処理を追加

            ////ADD_START :2021/11/25 kitayama 理由：検査名称を読みだす処理を追加
            //Stream_name1.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 0];
            //Stream_name2.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 1];
            //Stream_name3.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 2];
            //Stream_name4.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 3];
            //Stream_name5.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 4];
            //Stream_name6.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 5];
            //Stream_name7.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 6];
            //Stream_name8.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 7];
            //Stream_name9.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 8];
            //Stream_name10.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 9];
            //Stream_name11.Text = MainWindow.s_meisyou[MainWindow.kishuno - 1, 10];
            ////ADD_END :2021/11/25 kitayama 理由：検査名称を読みだす処理を追加

            //DELETE_END :2021/12/19 kitayama 理由：名称は使用しないので削除

            //今回は1品種に対して1つのAnalyzeだけ使用するので閾値設定はほとんど削除する
            //DELETE_START :2021/11/7 kitayama 理由：使用しない閾値設定処理を削除
            //Stream1
            //numericUpDown00.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 0]);
            //numericUpDown01.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 1]);
            //numericUpDown02.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 2]);
            //numericUpDown03.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 3]);
            //numericUpDown04.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 4]);
            ////Stream2
            //numericUpDown10.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 0]);
            //numericUpDown11.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 1]);
            //numericUpDown12.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 2]);
            //numericUpDown13.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 3]);
            //numericUpDown14.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 4]);
            ////Stream3
            //numericUpDown20.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 0]);
            //numericUpDown21.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 1]);
            //numericUpDown22.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 2]);
            //numericUpDown23.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 3]);
            //numericUpDown24.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 4]);
            ////Stream4
            //numericUpDown30.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 0]);
            //numericUpDown31.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 1]);
            //numericUpDown32.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 2]);
            //numericUpDown33.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 3]);
            //numericUpDown34.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 4]);
            ////Stream5
            //numericUpDown40.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 0]);
            //numericUpDown41.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 1]);
            //numericUpDown42.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 2]);
            //numericUpDown43.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 3]);
            //numericUpDown44.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 4]);
            ////Stream6
            //numericUpDown50.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 0]);
            //numericUpDown51.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 1]);
            //numericUpDown52.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 2]);
            //numericUpDown53.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 3]);
            //numericUpDown54.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 4]);
            ////Stream7
            //numericUpDown60.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 0]);
            //numericUpDown61.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 1]);
            //numericUpDown62.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 2]);
            //numericUpDown63.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 3]);
            //numericUpDown64.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 4]);
            ////Stream8
            //numericUpDown70.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 0]);
            //numericUpDown71.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 1]);
            //numericUpDown72.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 2]);
            //numericUpDown73.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 3]);
            //numericUpDown74.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 4]);
            ////Stream9
            //numericUpDown80.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 0]);
            //numericUpDown81.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 1]);
            //numericUpDown82.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 2]);
            //numericUpDown83.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 3]);
            //numericUpDown84.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 4]);
            ////Stream10
            //numericUpDown90.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 0]);
            //numericUpDown91.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 1]);
            //numericUpDown92.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 2]);
            //numericUpDown93.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 3]);
            //numericUpDown94.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 4]);
            ////Stream11
            //numericUpDown100.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 0]);
            //numericUpDown101.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 1]);
            //numericUpDown102.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 2]);
            //numericUpDown103.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 3]);
            //numericUpDown104.Value = Convert.ToDecimal(MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 4]);
            //DELETE_END :2021/11/7 kitayama 理由：使用しない閾値設定処理を削除
        }

        private void set_button_Click(object sender, EventArgs e)
        {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("しきい値設定を完了して宜しいでしょうか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {

                logger.Debug("Form1　設定ボタン＞はい");


                //「はい」が選択された時
                Console.WriteLine("「はい」が選択されました");

                //CHANGE_START :2021/11/25 kitayama 理由：しきい値の上限下限を設定できるように配列を変更・追加
                //ADD_START :2021/11/7 kitayama 理由：今回使用する閾値設定を追加
                //Stream1
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 0] = (double)numericUpDown_u00.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 1] = (double)numericUpDown_u01.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 2] = (double)numericUpDown_u02.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 3] = (double)numericUpDown_u03.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 4] = (double)numericUpDown_u04.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 5] = (double)numericUpDown_u05.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 6] = (double)numericUpDown_u06.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 7] = (double)numericUpDown_u07.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 8] = (double)numericUpDown_u08.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 0, 9] = (double)numericUpDown_u09.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 0] = (double)numericUpDown_l00.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 1] = (double)numericUpDown_l01.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 2] = (double)numericUpDown_l02.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 3] = (double)numericUpDown_l03.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 4] = (double)numericUpDown_l04.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 5] = (double)numericUpDown_l05.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 6] = (double)numericUpDown_l06.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 7] = (double)numericUpDown_l07.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 8] = (double)numericUpDown_l08.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 0, 9] = (double)numericUpDown_l09.Value;

                //Stream2
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 0] = (double)numericUpDown_u10.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 1] = (double)numericUpDown_u11.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 2] = (double)numericUpDown_u12.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 3] = (double)numericUpDown_u13.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 4] = (double)numericUpDown_u14.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 5] = (double)numericUpDown_u15.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 6] = (double)numericUpDown_u16.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 7] = (double)numericUpDown_u17.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 8] = (double)numericUpDown_u18.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 1, 9] = (double)numericUpDown_u19.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 0] = (double)numericUpDown_l10.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 1] = (double)numericUpDown_l11.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 2] = (double)numericUpDown_l12.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 3] = (double)numericUpDown_l13.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 4] = (double)numericUpDown_l14.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 5] = (double)numericUpDown_l15.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 6] = (double)numericUpDown_l16.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 7] = (double)numericUpDown_l17.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 8] = (double)numericUpDown_l18.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 1, 9] = (double)numericUpDown_l19.Value;

                //Stream3
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 0] = (double)numericUpDown_u20.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 1] = (double)numericUpDown_u21.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 2] = (double)numericUpDown_u22.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 3] = (double)numericUpDown_u23.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 4] = (double)numericUpDown_u24.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 5] = (double)numericUpDown_u25.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 6] = (double)numericUpDown_u26.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 7] = (double)numericUpDown_u27.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 8] = (double)numericUpDown_u28.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 2, 9] = (double)numericUpDown_u29.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 0] = (double)numericUpDown_l20.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 1] = (double)numericUpDown_l21.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 2] = (double)numericUpDown_l22.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 3] = (double)numericUpDown_l23.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 4] = (double)numericUpDown_l24.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 5] = (double)numericUpDown_l25.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 6] = (double)numericUpDown_l26.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 7] = (double)numericUpDown_l27.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 8] = (double)numericUpDown_l28.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 2, 9] = (double)numericUpDown_l29.Value;

                //Stream4
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 0] = (double)numericUpDown_u30.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 1] = (double)numericUpDown_u31.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 2] = (double)numericUpDown_u32.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 3] = (double)numericUpDown_u33.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 4] = (double)numericUpDown_u34.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 5] = (double)numericUpDown_u35.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 6] = (double)numericUpDown_u36.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 7] = (double)numericUpDown_u37.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 8] = (double)numericUpDown_u38.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 3, 9] = (double)numericUpDown_u39.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 0] = (double)numericUpDown_l30.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 1] = (double)numericUpDown_l31.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 2] = (double)numericUpDown_l32.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 3] = (double)numericUpDown_l33.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 4] = (double)numericUpDown_l34.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 5] = (double)numericUpDown_l35.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 6] = (double)numericUpDown_l36.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 7] = (double)numericUpDown_l37.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 8] = (double)numericUpDown_l38.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 3, 9] = (double)numericUpDown_l39.Value;

                //Stream5
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 0] = (double)numericUpDown_u40.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 1] = (double)numericUpDown_u41.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 2] = (double)numericUpDown_u42.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 3] = (double)numericUpDown_u43.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 4] = (double)numericUpDown_u44.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 5] = (double)numericUpDown_u45.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 6] = (double)numericUpDown_u46.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 7] = (double)numericUpDown_u47.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 8] = (double)numericUpDown_u48.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 4, 9] = (double)numericUpDown_u49.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 0] = (double)numericUpDown_l40.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 1] = (double)numericUpDown_l41.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 2] = (double)numericUpDown_l42.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 3] = (double)numericUpDown_l43.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 4] = (double)numericUpDown_l44.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 5] = (double)numericUpDown_l45.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 6] = (double)numericUpDown_l46.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 7] = (double)numericUpDown_l47.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 8] = (double)numericUpDown_l48.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 4, 9] = (double)numericUpDown_l49.Value;

                //Stream6
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 0] = (double)numericUpDown_u50.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 1] = (double)numericUpDown_u51.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 2] = (double)numericUpDown_u52.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 3] = (double)numericUpDown_u53.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 4] = (double)numericUpDown_u54.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 5] = (double)numericUpDown_u55.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 6] = (double)numericUpDown_u56.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 7] = (double)numericUpDown_u57.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 8] = (double)numericUpDown_u58.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 5, 9] = (double)numericUpDown_u59.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 0] = (double)numericUpDown_l50.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 1] = (double)numericUpDown_l51.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 2] = (double)numericUpDown_l52.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 3] = (double)numericUpDown_l53.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 4] = (double)numericUpDown_l54.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 5] = (double)numericUpDown_l55.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 6] = (double)numericUpDown_l56.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 7] = (double)numericUpDown_l57.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 8] = (double)numericUpDown_l58.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 5, 9] = (double)numericUpDown_l59.Value;

                //Stream7
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 0] = (double)numericUpDown_u60.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 1] = (double)numericUpDown_u61.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 2] = (double)numericUpDown_u62.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 3] = (double)numericUpDown_u63.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 4] = (double)numericUpDown_u64.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 5] = (double)numericUpDown_u65.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 6] = (double)numericUpDown_u66.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 7] = (double)numericUpDown_u67.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 8] = (double)numericUpDown_u68.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 6, 9] = (double)numericUpDown_u69.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 0] = (double)numericUpDown_l60.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 1] = (double)numericUpDown_l61.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 2] = (double)numericUpDown_l62.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 3] = (double)numericUpDown_l63.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 4] = (double)numericUpDown_l64.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 5] = (double)numericUpDown_l65.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 6] = (double)numericUpDown_l66.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 7] = (double)numericUpDown_l67.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 8] = (double)numericUpDown_l68.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 6, 9] = (double)numericUpDown_l69.Value;

                //Stream8
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 0] = (double)numericUpDown_u70.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 1] = (double)numericUpDown_u71.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 2] = (double)numericUpDown_u72.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 3] = (double)numericUpDown_u73.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 4] = (double)numericUpDown_u74.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 5] = (double)numericUpDown_u75.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 6] = (double)numericUpDown_u76.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 7] = (double)numericUpDown_u77.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 8] = (double)numericUpDown_u78.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 7, 9] = (double)numericUpDown_u79.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 0] = (double)numericUpDown_l70.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 1] = (double)numericUpDown_l71.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 2] = (double)numericUpDown_l72.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 3] = (double)numericUpDown_l73.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 4] = (double)numericUpDown_l74.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 5] = (double)numericUpDown_l75.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 6] = (double)numericUpDown_l76.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 7] = (double)numericUpDown_l77.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 8] = (double)numericUpDown_l78.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 7, 9] = (double)numericUpDown_l79.Value;

                //Stream9
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 0] = (double)numericUpDown_u80.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 1] = (double)numericUpDown_u81.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 2] = (double)numericUpDown_u82.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 3] = (double)numericUpDown_u83.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 4] = (double)numericUpDown_u84.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 5] = (double)numericUpDown_u85.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 6] = (double)numericUpDown_u86.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 7] = (double)numericUpDown_u87.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 8] = (double)numericUpDown_u88.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 8, 9] = (double)numericUpDown_u89.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 0] = (double)numericUpDown_l80.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 1] = (double)numericUpDown_l81.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 2] = (double)numericUpDown_l82.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 3] = (double)numericUpDown_l83.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 4] = (double)numericUpDown_l84.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 5] = (double)numericUpDown_l85.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 6] = (double)numericUpDown_l86.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 7] = (double)numericUpDown_l87.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 8] = (double)numericUpDown_l88.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 8, 9] = (double)numericUpDown_l89.Value;

                //Stream10
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 0] = (double)numericUpDown_u90.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 1] = (double)numericUpDown_u91.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 2] = (double)numericUpDown_u92.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 3] = (double)numericUpDown_u93.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 4] = (double)numericUpDown_u94.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 5] = (double)numericUpDown_u95.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 6] = (double)numericUpDown_u96.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 7] = (double)numericUpDown_u97.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 8] = (double)numericUpDown_u98.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 9, 9] = (double)numericUpDown_u99.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 0] = (double)numericUpDown_l90.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 1] = (double)numericUpDown_l91.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 2] = (double)numericUpDown_l92.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 3] = (double)numericUpDown_l93.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 4] = (double)numericUpDown_l94.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 5] = (double)numericUpDown_l95.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 6] = (double)numericUpDown_l96.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 7] = (double)numericUpDown_l97.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 8] = (double)numericUpDown_l98.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 9, 9] = (double)numericUpDown_l99.Value;

                //Stream11
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 0] = (double)numericUpDown_uA0.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 1] = (double)numericUpDown_uA1.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 2] = (double)numericUpDown_uA2.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 3] = (double)numericUpDown_uA3.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 4] = (double)numericUpDown_uA4.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 5] = (double)numericUpDown_uA5.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 6] = (double)numericUpDown_uA6.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 7] = (double)numericUpDown_uA7.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 8] = (double)numericUpDown_uA8.Value;
                MainWindow.dThreshold3[0, MainWindow.kishuno - 1, 10, 9] = (double)numericUpDown_uA9.Value;

                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 0] = (double)numericUpDown_lA0.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 1] = (double)numericUpDown_lA1.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 2] = (double)numericUpDown_lA2.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 3] = (double)numericUpDown_lA3.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 4] = (double)numericUpDown_lA4.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 5] = (double)numericUpDown_lA5.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 6] = (double)numericUpDown_lA6.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 7] = (double)numericUpDown_lA7.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 8] = (double)numericUpDown_lA8.Value;
                MainWindow.dThreshold3[1, MainWindow.kishuno - 1, 10, 9] = (double)numericUpDown_lA9.Value;

                //ADD_END :2021/11/7 kitayama 理由：今回使用する閾値設定を追加
                //CHANGE_END :2021/11/25 kitayama 理由：しきい値の上限下限を設定できるように配列を変更・追加

                //DELETE_START :2021/12/19 kitayama 理由：名称は使用しないので削除
                ////ADD_START :2021/11/25 kitayama 理由：検査名称を設定する処理を追加
                ////Stream1
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 0] = textBox01.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 1] = textBox02.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 2] = textBox03.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 3] = textBox04.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 4] = textBox05.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 5] = textBox06.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 6] = textBox07.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 7] = textBox08.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 8] = textBox09.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 0, 9] = textBox0A.Text;

                ////Stream2
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 0] = textBox11.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 1] = textBox12.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 2] = textBox13.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 3] = textBox14.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 4] = textBox15.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 5] = textBox16.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 6] = textBox17.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 7] = textBox18.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 8] = textBox19.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 1, 9] = textBox1A.Text;

                ////Stream3
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 0] = textBox21.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 1] = textBox22.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 2] = textBox23.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 3] = textBox24.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 4] = textBox25.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 5] = textBox26.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 6] = textBox27.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 7] = textBox28.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 8] = textBox29.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 2, 9] = textBox2A.Text;

                ////Stream4
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 0] = textBox31.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 1] = textBox32.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 2] = textBox33.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 3] = textBox34.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 4] = textBox35.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 5] = textBox36.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 6] = textBox37.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 7] = textBox38.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 8] = textBox39.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 3, 9] = textBox3A.Text;

                ////Stream5
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 0] = textBox41.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 1] = textBox42.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 2] = textBox43.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 3] = textBox44.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 4] = textBox45.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 5] = textBox46.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 6] = textBox47.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 7] = textBox48.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 8] = textBox49.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 4, 9] = textBox4A.Text;

                ////Stream6
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 0] = textBox51.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 1] = textBox52.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 2] = textBox53.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 3] = textBox54.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 4] = textBox55.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 5] = textBox56.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 6] = textBox57.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 7] = textBox58.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 8] = textBox59.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 5, 9] = textBox5A.Text;

                ////Stream7
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 0] = textBox61.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 1] = textBox62.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 2] = textBox63.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 3] = textBox64.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 4] = textBox65.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 5] = textBox66.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 6] = textBox67.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 7] = textBox68.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 8] = textBox69.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 6, 9] = textBox6A.Text;

                ////Stream8
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 0] = textBox71.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 1] = textBox72.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 2] = textBox73.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 3] = textBox74.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 4] = textBox75.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 5] = textBox76.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 6] = textBox77.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 7] = textBox78.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 8] = textBox79.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 7, 9] = textBox7A.Text;

                ////Stream9
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 0] = textBox81.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 1] = textBox82.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 2] = textBox83.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 3] = textBox84.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 4] = textBox85.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 5] = textBox86.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 6] = textBox87.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 7] = textBox88.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 8] = textBox89.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 8, 9] = textBox8A.Text;

                ////Stream10
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 0] = textBox91.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 1] = textBox92.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 2] = textBox93.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 3] = textBox94.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 4] = textBox95.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 5] = textBox96.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 6] = textBox97.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 7] = textBox98.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 8] = textBox99.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 9, 9] = textBox9A.Text;

                ////Stream11
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 0] = textBox101.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 1] = textBox102.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 2] = textBox103.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 3] = textBox104.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 4] = textBox105.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 5] = textBox106.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 6] = textBox107.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 7] = textBox108.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 8] = textBox109.Text;
                //MainWindow.a_meisyou[MainWindow.kishuno - 1, 10, 9] = textBox10A.Text;

                ////ADD_END :2021/11/25 kitayama 理由：検査名称を設定する処理を追加

                ////ADD_START :2021/11/25 kitayama 理由：検査名称を設定する処理を追加
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 0] = Stream_name1.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 1] = Stream_name2.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 2] = Stream_name3.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 3] = Stream_name4.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 4] = Stream_name5.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 5] = Stream_name6.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 6] = Stream_name7.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 7] = Stream_name8.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 8] = Stream_name9.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 9] = Stream_name10.Text;
                //MainWindow.s_meisyou[MainWindow.kishuno - 1, 10] = Stream_name11.Text;
                ////ADD_END :2021/11/25 kitayama 理由：検査名称を設定する処理を追加
                //DELETE_END :2021/12/19 kitayama 理由：名称は使用しないので削除

                //DELETE_START :2021/11/7 kitayama 理由：使用しない閾値設定処理を削除
                ////設定したしきい値を格納する
                ////Stream1
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 0] = (double)numericUpDown00.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 1] = (double)numericUpDown01.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 2] = (double)numericUpDown02.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 3] = (double)numericUpDown03.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 0, 4] = (double)numericUpDown04.Value;
                ////Stream2
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 0] = (double)numericUpDown10.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 1] = (double)numericUpDown11.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 2] = (double)numericUpDown12.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 3] = (double)numericUpDown13.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 1, 4] = (double)numericUpDown14.Value;
                ////Stream3
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 0] = (double)numericUpDown20.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 1] = (double)numericUpDown21.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 2] = (double)numericUpDown22.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 3] = (double)numericUpDown23.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 2, 4] = (double)numericUpDown24.Value;
                ////Stream4
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 0] = (double)numericUpDown30.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 1] = (double)numericUpDown31.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 2] = (double)numericUpDown32.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 3] = (double)numericUpDown33.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 3, 4] = (double)numericUpDown34.Value;
                ////Stream5
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 0] = (double)numericUpDown40.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 1] = (double)numericUpDown41.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 2] = (double)numericUpDown42.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 3] = (double)numericUpDown43.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 4, 4] = (double)numericUpDown44.Value;
                ////Stream6
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 0] = (double)numericUpDown50.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 1] = (double)numericUpDown51.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 2] = (double)numericUpDown52.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 3] = (double)numericUpDown53.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 5, 4] = (double)numericUpDown54.Value;
                ////Stream7
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 0] = (double)numericUpDown60.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 1] = (double)numericUpDown61.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 2] = (double)numericUpDown62.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 3] = (double)numericUpDown63.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 6, 4] = (double)numericUpDown64.Value;
                ////Stream8
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 0] = (double)numericUpDown70.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 1] = (double)numericUpDown71.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 2] = (double)numericUpDown72.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 3] = (double)numericUpDown73.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 7, 4] = (double)numericUpDown74.Value;
                ////Stream9
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 0] = (double)numericUpDown80.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 1] = (double)numericUpDown81.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 2] = (double)numericUpDown82.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 3] = (double)numericUpDown83.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 8, 4] = (double)numericUpDown84.Value;
                ////Stream10
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 0] = (double)numericUpDown90.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 1] = (double)numericUpDown91.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 2] = (double)numericUpDown92.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 3] = (double)numericUpDown93.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 9, 4] = (double)numericUpDown94.Value;
                ////Stream11
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 0] = (double)numericUpDown100.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 1] = (double)numericUpDown101.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 2] = (double)numericUpDown102.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 3] = (double)numericUpDown103.Value;
                //MainWindow.dThreshold2[MainWindow.kishuno - 1, 10, 4] = (double)numericUpDown104.Value;
                //DELETE_END :2021/11/7 kitayama 理由：使用しない閾値設定処理を削除

                ///////////////////////////////////////////////////////////////////
                ///     XMLを更新する。
                ///////////////////////////////////////////////////////////////////
                Change_XML change_XML;      //XML編集クラス
                change_XML = new Change_XML();
                change_XML.WriteXML();

            }
            else if (result == DialogResult.No)
            {

                logger.Debug("Form1　設定ボタン＞いいえ");

                //「いいえ」が選択された時
                Console.WriteLine("「いいえ」が選択されました");
            }

            logger.Debug("Form1　閉じる");

            Close();    //フォームを閉じる。
        }


        /// <summary>
        /// DELETE_START :2021/11/21 kitayama 理由：パスワード設定はForm4に移すので削除
        ///ADD :2020/5/14 kitayama 理由：パスワード変更ボタンを追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void pass_button_Click(object sender, EventArgs e)
        //{
        //    if (passflag == false)
        //    {
        //        //"パスワード設定"のボタンを押すと、テキストを入力可能にする
        //        textBox1.Enabled = true;
        //        pass_button.Text = "パスワード変更";
        //        passflag = true;
        //    }
        //    else 
        //    {
        //        if (textBox1.Text.Length == 4)
        //        {
        //            //パスワードとして入力された文字が４文字の場合はパスワード設定処理を行う

        //            DialogResult result = MessageBox.Show("しきい値設定画面のパスワードを変更しますか？",
        //            "確認",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Exclamation,
        //            MessageBoxDefaultButton.Button2);

        //            if (result == DialogResult.Yes)
        //            {
        //                //"パスワード変更"＞はいのボタンを押すと、iniファイルの内容を上書きし、テキストボックスとボタンの表示を元に戻す
        //                //テキストボックスの入力内容をiniファイルに上書きする
        //                System.IO.StreamWriter sw = new System.IO.StreamWriter(
        //                System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Password.ini", false, Encoding.UTF8);


        //                sw.WriteLine(textBox1.Text);

        //                sw.Close();
        //            }
        //            else if (result == DialogResult.No)
        //            {
        //                //いいえの時はiniファイルを変更しない
        //            }
                
        //        }
        //        else 
        //        {
        //            //入力された文字が4文字でない場合はメッセージを表示する
        //            MessageBox.Show("パスワードは4文字で入力してください。",
        //                "確認",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);

        //        }

        //        textBox1.Clear();
        //        textBox1.Enabled = false;
        //        pass_button.Text = "パスワード設定";
        //        passflag = false;

        //    }

        //}
        // DELETE_END :2021/11/21 kitayama 理由：パスワード設定はForm4に移すので削除

    }
}
