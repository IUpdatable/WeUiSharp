using System.Windows;

namespace WeUiSharp.Demo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
          //  this.CornerRadius = new CornerRadius(2);
            this.BorderThickness = new Thickness(0);
            this.Title = string.Empty;

            InitializeComponent();
        }
    }
}
