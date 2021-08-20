using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeUiSharp.Controls
{
    /// <summary>
    /// Toast.xaml 的交互逻辑
    /// </summary>
    public partial class Toast : System.Windows.Window, IDisposable
    {
        public string Message { get; set; }
        public double Duration { get; set; }

        public Toast()
        {
            InitializeComponent();
            this.DataContext = this;

            Task.Factory.StartNew(() =>
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                double duration = Duration * 1000;
                timer.Interval = duration <= 0 ? 3500 : duration;
                timer.Elapsed += (sender, args) =>
                {
                    timer.Stop();
                    this.Dispatcher.Invoke(new Action(()=>
                    {
                        this.DialogResult = true;
                    }));
                };
                timer.Start();
            });
        }
        /// <summary>
        /// Toast消息提示
        /// </summary>
        /// <param name="owner">调用者</param>
        /// <param name="message">消息内容</param>
        /// <param name="durationSec">消息展示的时间，单位：秒</param>
        public static void Show(string message, double durationSec = 3.5)
        {
            using (Toast toast = new Toast())
            {
                toast.Message = message;
                toast.Duration = durationSec;
                toast.Topmost = true;
                toast.Owner = Application.Current.MainWindow;
                toast.ShowDialog();
            }
        }

        public static void Show(Window owner, string message, double durationSec = 3.5)
        {
            using (Toast toast = new Toast())
            {
                toast.Message = message;
                toast.Duration = durationSec;
                toast.Topmost = true;
                toast.Owner = owner;
                toast.ShowDialog();
            }
        }

        public void Dispose()
        {
            this.Close();
        }
    }
}
