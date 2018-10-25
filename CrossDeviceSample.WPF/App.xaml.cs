using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace CrossDeviceSample.WPF
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            ((MainWindowViewModel)MainWindow.DataContext).ReceivedMessage = ParseArgs(e.Args);
            MainWindow.Show();
        }

        private string ParseArgs(string[] args)
        {
            var first = args.FirstOrDefault();
            if (string.IsNullOrEmpty(first))
            {
                return null;
            }

            var q = HttpUtility.ParseQueryString(new Uri(first).Query);
            return q["message"];
        }
    }
}
