using Prism.Commands;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using WeUiSharp.Controls;
using WeUiSharp.Windows;

namespace WeUiSharp.Demo.Views
{
    
    /// <summary>
    /// Interaction logic for OverviewView
    /// </summary>
    public partial class OverviewView : UserControl
    {
        #region [Fields]

        #endregion

        public OverviewView()
        {
            InitializeComponent();
        }

        private void MessageBox0_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("This is a MessageBox!", "Title");
        }

        private void MessageBox1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("This is a MessageBox!", "Title", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("You clicked Yes");
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                MessageBox.Show("You clicked No");
            }
        }

        private void MessageBox2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("This is a MessageBox!", "Title", MessageBoxButton.OKCancel);
            if (dialogResult == MessageBoxResult.OK)
            {
                MessageBox.Show("You clicked Ok");
            }
            else if (dialogResult == MessageBoxResult.Cancel)
            {
                MessageBox.Show("You clicked Cancel");
            }
        }

        private void Toast_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Toast.Show("Tis is a Toast!", 1);
        }

        private void OnTriggerAlert(object sender, System.Windows.RoutedEventArgs e)
        {
            (System.Windows.Application.Current.MainWindow as WeUiSharp.Windows.Window).TriggerAlertCommand.Execute("Your alert message!");
        }

        private void OnCancelTriggerAlert(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = System.Windows.Application.Current.MainWindow as WeUiSharp.Windows.Window;
            if (window.IsAlertTriggered)
            {
                window.CancelAlertCommand.Execute(null);
            }
        }
    }
}
