using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeUiSharp.Enums;
using WeUiSharp.Windows;

namespace WeUiSharp.Controls
{
    public class Button: System.Windows.Controls.Button
    {
        static Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Button), new FrameworkPropertyMetadata(typeof(Button)));
        }



        public ButtonGreenType GreenType
        {
            get { return (ButtonGreenType)GetValue(GreenTypeProperty); }
            set { SetValue(GreenTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GreenTypeProperty =
            DependencyProperty.Register(nameof(GreenType), typeof(ButtonGreenType), typeof(Button), 
                new PropertyMetadata(ButtonGreenType.None));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Button), new PropertyMetadata(new CornerRadius(0)));


    }
}
