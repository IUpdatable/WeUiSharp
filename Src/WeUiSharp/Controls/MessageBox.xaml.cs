using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBox : WeUiSharp.Windows.Window
    {
        public string Message { get; set; }
        private MessageBoxResult _Result;

        public MessageBoxResult Result
        {
            get
            {
                return _Result;
            }
        }

        public MessageBox()
        {
            InitializeComponent();
            this.DataContext = this;
            _Result = MessageBoxResult.Cancel;
        }



        public static MessageBoxResult Show(string messageBoxText, string caption = "")
        {
            MessageBoxResult result = MessageBoxResult.Cancel;
            using (MessageBox messageBox = new MessageBox())
            {
                messageBox.Title = caption;
                messageBox.Message = messageBoxText;
                messageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                messageBox.Owner = Application.Current.MainWindow;
                messageBox.ShowDialog();
                result = messageBox.Result;
            }
            return result;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _Result = MessageBoxResult.Cancel;
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            _Result = MessageBoxResult.OK;
            this.Close();
        }
    }
}
