using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WeUiSharp.Controls
{
    public class PathButton : Button
    {
        static PathButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PathButton), new FrameworkPropertyMetadata(typeof(PathButton)));
        }

        public Brush DefaultBackground
        {
            get { return (Brush)GetValue(DefaultBackgroundProperty); }
            set { SetValue(DefaultBackgroundProperty, value); }
        }

        public static readonly DependencyProperty DefaultBackgroundProperty =
            DependencyProperty.Register(nameof(DefaultBackground), typeof(Brush), typeof(PathButton), new PropertyMetadata(null));

        public Brush DefaultForeground
        {
            get { return (Brush)GetValue(DefaultForegroundProperty); }
            set { SetValue(DefaultForegroundProperty, value); }
        }

        public static readonly DependencyProperty DefaultForegroundProperty =
            DependencyProperty.Register(nameof(DefaultForeground), typeof(Brush), typeof(PathButton), new PropertyMetadata(null));

        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register(nameof(MouseOverBackground), typeof(Brush), typeof(PathButton), new PropertyMetadata(null));

        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register(nameof(MouseOverForeground), typeof(Brush), typeof(PathButton), new PropertyMetadata(null));

        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register(nameof(PressedBackground), typeof(Brush), typeof(PathButton), new PropertyMetadata(null));

        public Brush PressedForeground
        {
            get { return (Brush)GetValue(PressedForegroundProperty); }
            set { SetValue(PressedForegroundProperty, value); }
        }
        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register(nameof(PressedForeground), typeof(Brush), typeof(PathButton), new PropertyMetadata(null));

        public Path Path
        {
            get { return (Path)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(Path), typeof(PathButton), new PropertyMetadata(null));

    }
}
