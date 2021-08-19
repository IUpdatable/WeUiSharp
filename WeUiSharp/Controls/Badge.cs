using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeUiSharp.Controls
{
    public class Badge: System.Windows.Controls.ContentControl
    {
        static Badge()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Badge), new FrameworkPropertyMetadata(typeof(Badge)));
        }

        #region [Value]
        /// <summary>
        /// Value: 只支持int类型数字（Only supports int type）
        /// </summary>
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value);  }
        }
        /// <summary>
        /// 只支持int类型数字（Only supports int type）
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(Badge), 
                new PropertyMetadata(-1, new PropertyChangedCallback(OnNumberChanged)));

        public static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int value = int.Parse(e.NewValue.ToString());
            
            if (value <= 0)
            {
                d.SetValue(IsEnabledProperty, false);
            }
            else
            {
                d.SetValue(IsEnabledProperty, true);
            }
            if (value > 0 && value.ToString().Length == 1)
            {
                d.SetValue(ValueLengthProperty, 1);
                d.SetValue(TextProperty, value.ToString());
            }
            else if (value > 0 && value.ToString().Length == 2)
            {
                d.SetValue(ValueLengthProperty, 2);
                d.SetValue(TextProperty, value.ToString());
            }
            else if (value > 0 && value.ToString().Length == 3)
            {
                d.SetValue(ValueLengthProperty, 3);
                d.SetValue(TextProperty, "...");
            }
            else
            {
                d.SetValue(IsEnabledProperty, false);
            }
            
        }
        #endregion

        #region [Text]
        internal string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        internal static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(Badge), 
                new PropertyMetadata(string.Empty));

        #endregion

        #region [IsValueVisible]
        public bool IsValueVisible
        {
            get { return (bool)GetValue(IsValueVisibleProperty); }
            set 
            {
                if (!value)
                {
                    SetValue(ValueLengthProperty, 0);
                }
                SetValue(IsValueVisibleProperty, value); 
            }
        }
        public static readonly DependencyProperty IsValueVisibleProperty =
            DependencyProperty.Register(nameof(IsValueVisible), typeof(bool), typeof(Badge), new PropertyMetadata(false));
        #endregion

        #region [ValueLength]
        /// <summary>
        /// ValueLength: 0, 1, 2, 3
        /// </summary>
        internal int ValueLength
        {
            get { return (int)GetValue(ValueLengthProperty); }
            private set { SetValue(ValueLengthProperty, value); }
        }

        internal static readonly DependencyProperty ValueLengthProperty =
            DependencyProperty.Register(nameof(ValueLength), typeof(int), typeof(Badge), new PropertyMetadata(0));
        #endregion

        #region [CornerRadius]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Badge), new PropertyMetadata(new System.Windows.CornerRadius(0)));
        #endregion

    }
}
