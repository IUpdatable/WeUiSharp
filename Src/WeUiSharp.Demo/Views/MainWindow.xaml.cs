using Prism.Ioc;
using Prism.Regions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WeUiSharp.Controls;

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
            MoreBtnContextMenu.Placement = PlacementMode.Custom;
            MoreBtnContextMenu.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(PlaceMoreBtnContextMenu);
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
        #region [MoreButton related]
        public CustomPopupPlacement[] PlaceMoreBtnContextMenu(Size popupSize, Size targetSize, Point offset)
        {
            // 针对显示设置成不同DPI情况下
            // https://stackoverflow.com/a/44692724
            double dpiFactor = System.Windows.PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice.M11; // dpiFactor范围：1.0 - 2.5

            CustomPopupPlacement[] ttplaces = new CustomPopupPlacement[] { new CustomPopupPlacement() };
            Point relevantPoint = MoreButton.TranslatePoint(new Point(0, 0), HamburgerMenuGrid);
            double xOffset = targetSize.Width;
            if (dpiFactor != 1)
            {
                xOffset -= 1;
            }
            double yOffset = relevantPoint.Y * dpiFactor + MoreButton.ActualHeight * dpiFactor - popupSize.Height + 5 * dpiFactor;

            ttplaces[0].Point = new Point(xOffset, yOffset);
            ttplaces[0].PrimaryAxis = PopupPrimaryAxis.Horizontal;
            return ttplaces;
        }

        private void MoreButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                e.Handled = true;
            }
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is PathButton pathButton)
            {
                ContextMenu menu = pathButton.ContextMenu;
                menu.PlacementTarget = HamburgerMenuGrid;
                menu.IsOpen = !menu.IsOpen;
            }
        }
        #endregion


        private void Avatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/IUpdatable/WeUiSharp"));
        }
    }
}
