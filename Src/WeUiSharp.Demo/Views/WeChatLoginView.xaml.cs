using System.Windows.Controls;

namespace WeUiSharp.Demo.Views
{
    /// <summary>
    /// Interaction logic for WeChatLoginView
    /// </summary>
    public partial class WeChatLoginView : UserControl
    {
        public WeChatLoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WeChatLoginWindow weChatLoginWindow = new WeChatLoginWindow();
            weChatLoginWindow.ShowDialog();
        }
    }
}
