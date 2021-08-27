using Prism.Ioc;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WeUiSharp.Demo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region [Fields]
        ToggleButton _PreToggleButton;
        #endregion


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _PreToggleButton = ComponentMenuItem;
           
        }

        // 实现拖拽左侧汉堡菜单移动主窗体
        private void MainMenu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!(e.Source is Grid))
            {
                return;
            }

            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        // 实现菜单项的单选
        private void OnMenuItemPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ToggleButton toggleButton)
            {
                if (toggleButton.IsChecked.HasValue && toggleButton.IsChecked.Value)
                {
                    e.Handled = true;
                    return;
                }
                if (_PreToggleButton != null && _PreToggleButton.IsChecked.HasValue && _PreToggleButton.IsChecked.Value)
                {
                    _PreToggleButton.IsChecked = false;
                }
                _PreToggleButton = toggleButton;
            }
        }
    }
}
