using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeUiSharp.Interfaces;

namespace WeUiSharp.Controls
{
    public abstract class HamburgerMenuItemBase : RadioButton, ISortedView
    {
        #region [Properties]

        public abstract int Index { get; set; }

        /// <summary>
        /// 正常情况下，背景图的ImageSource
        /// </summary>
        public ImageSource MenuItemImgSrc
        {
            get { return (ImageSource)GetValue(MenuItemImgSrcProperty); }
            set { SetValue(MenuItemImgSrcProperty, value); }
        }
        public static readonly DependencyProperty MenuItemImgSrcProperty =
            DependencyProperty.Register("MenuItemImgSrc", typeof(ImageSource), typeof(HamburgerMenuItemBase), new PropertyMetadata(null));

        /// <summary>
        /// 鼠标停靠时，背景图的ImageSource
        /// </summary>
        public ImageSource MenuItemMouseOverImgSrc
        {
            get { return (ImageSource)GetValue(MenuItemMouseOverImgSrcProperty); }
            set { SetValue(MenuItemMouseOverImgSrcProperty, value); }
        }
        public static readonly DependencyProperty MenuItemMouseOverImgSrcProperty =
            DependencyProperty.Register("MenuItemMouseOverImgSrc", typeof(ImageSource), typeof(HamburgerMenuItemBase), new PropertyMetadata(null));

        /// <summary>
        /// 选中时，背景图的ImageSource
        /// </summary>
        public ImageSource MenuItemCheckedImgSrc
        {
            get { return (ImageSource)GetValue(MenuItemCheckedImgSrcProperty); }
            set { SetValue(MenuItemCheckedImgSrcProperty, value); }
        }
        public static readonly DependencyProperty MenuItemCheckedImgSrcProperty =
            DependencyProperty.Register("MenuItemCheckedImgSrc", typeof(ImageSource), typeof(HamburgerMenuItemBase), new PropertyMetadata(null));

        #endregion

        public HamburgerMenuItemBase()
        {
            MenuItemImgSrc = new BitmapImage(new Uri("pack://application:,,,/WeUiSharp;component/Resources/Icons/Plugin.png"));
            MenuItemMouseOverImgSrc = new BitmapImage(new Uri("pack://application:,,,/WeUiSharp;component/Resources/Icons/Plugin_MouseOver.png"));
            MenuItemCheckedImgSrc = new BitmapImage(new Uri("pack://application:,,,/WeUiSharp;component/Resources/Icons/Plugin_Checked.png"));
            this.Style = Application.Current.FindResource("HamburgerMenuItemBaseStyle") as Style;
        }
    }
}
