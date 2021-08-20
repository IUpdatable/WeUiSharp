using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace WeUiSharp.Windows
{
    /// <summary>
    /// MessageBox.xaml 的交互逻辑 Wrapper
    /// </summary>
    internal partial class MessageBoxWrapper: Windows.Window
    {
        #region [Fields]
        private WeUiSharp.Windows.MessageBoxResult _Result;
        #endregion

        #region [Properties]

        #region Message
        internal string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        internal static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(MessageBoxWrapper), new PropertyMetadata(string.Empty));
        #endregion

        #region Result
        internal MessageBoxResult Result
        {
            get
            {
                return _Result;
            }
        }
        #endregion


        #region MessageBoxButton
        public MessageBoxButton MessageBoxButton
        {
            get { return (MessageBoxButton)GetValue(MessageBoxButtonProperty); }
            set { SetValue(MessageBoxButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageBoxButtonProperty =
            DependencyProperty.Register(nameof(MessageBoxButton), typeof(MessageBoxButton), typeof(MessageBoxWrapper), 
                new PropertyMetadata(MessageBoxButton.OK));
        #endregion

        #endregion




        internal MessageBoxWrapper()
        {
            InitializeComponent();
            this.DataContext = this;
            _Result = WeUiSharp.Windows.MessageBoxResult.Cancel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _Result = WeUiSharp.Windows.MessageBoxResult.Cancel;
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            _Result = WeUiSharp.Windows.MessageBoxResult.OK;
            this.Close();
        }

        private void GotItButton_Click(object sender, RoutedEventArgs e)
        {
            _Result = WeUiSharp.Windows.MessageBoxResult.GotIt;
            this.Close();
        }
    }
}
