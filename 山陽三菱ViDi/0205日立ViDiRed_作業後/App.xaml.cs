using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ViDi2.Runtime;

namespace Example.Runtime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {

            //CHANGE_START :2021/12/19 kitayama 理由：11/27の変更を元に戻した
            //CHANGE_START :2021/11/27 kitayama 理由：起動時にパスワード入力のForm5が起動するように変更
            var mainWindow = new MainWindow();

            Current.MainWindow = MainWindow;

            var control = new ViDi2.Runtime.Local.Control();
            mainWindow.Control = control;

            //System.Windows.Forms.Form form = new Form5();
            //form.Show();

            mainWindow.Show();
            //CHANGE_END :2021/11/27 kitayama 理由：起動時にパスワード入力のForm5が起動するように変更
            //CHANGE_END :2021/12/19 kitayama 理由：11/27の変更を元に戻した
        }
    }
}
