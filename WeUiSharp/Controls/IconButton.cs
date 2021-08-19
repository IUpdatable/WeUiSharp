using System.Windows;
using System.Windows.Media;

namespace WeUiSharp.Controls
{
    public class IconButton: System.Windows.Controls.Button
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        #region [StaticIcon]
        public ImageSource StaticIcon
        {
            get { return (ImageSource)GetValue(StaticIconProperty); }
            set { SetValue(StaticIconProperty, value); }
        }
        public static readonly DependencyProperty StaticIconProperty =
            DependencyProperty.Register("StaticIcon", typeof(ImageSource), typeof(IconButton), new PropertyMetadata(null));
        #endregion

        #region [MouseOverIcon]
        public ImageSource MouseOverIcon
        {
            get { return (ImageSource)GetValue(MouseOverIconProperty); }
            set { SetValue(MouseOverIconProperty, value); }
        }
        public static readonly DependencyProperty MouseOverIconProperty =
            DependencyProperty.Register("MouseOverIcon", typeof(ImageSource), typeof(IconButton), new PropertyMetadata(null));
        #endregion

        #region [PressedIcon]
        public ImageSource PressedIcon
        {
            get { return (ImageSource)GetValue(PressedIconProperty); }
            set { SetValue(PressedIconProperty, value); }
        }
        public static readonly DependencyProperty PressedIconProperty =
            DependencyProperty.Register("PressedIcon", typeof(ImageSource), typeof(IconButton), new PropertyMetadata(null));
        #endregion


    }
}
