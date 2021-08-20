using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace WeUiSharp.Controls
{
    /// <summary>
    /// SearchBar.xaml 的交互逻辑
    /// </summary>
    public partial class SearchBar : UserControl
    {
        public SearchBar()
        {
            InitializeComponent();
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = string.Empty;
            textBox.SetResourceReference(ForegroundProperty, "SearchBar.Focus.Foreground");
            SearchCloseBtn.Visibility = Visibility.Visible;
            MainBoarder.SetResourceReference(BackgroundProperty, "SearchBar.Focus.Background");
            MainBoarder.SetResourceReference(BorderBrushProperty, "SearchBar.Focus.Border");
            MainBoarder.BorderThickness = new Thickness(1);
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = Properties.Strings.ResourceManager.GetString("SearchBarText", Thread.CurrentThread.CurrentUICulture);
            textBox.SetResourceReference(ForegroundProperty, "SearchBar.Static.Foreground");
            SearchCloseBtn.Visibility = Visibility.Collapsed;
            MainBoarder.SetResourceReference(BackgroundProperty, "SearchBar.Static.Background");
            MainBoarder.BorderThickness = new Thickness(0);
        }
    }
}
