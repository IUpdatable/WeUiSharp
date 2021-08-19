using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeUiSharp.Controls
{
    public class WheelSpeedScrollViewer: ScrollViewer
    {
        public static readonly DependencyProperty SpeedFactorProperty =
        DependencyProperty.Register(nameof(SpeedFactor),
                                    typeof(Double),
                                    typeof(WheelSpeedScrollViewer),
                                    new PropertyMetadata(1.0));

        public Double SpeedFactor
        {
            get { return (Double)GetValue(SpeedFactorProperty); }
            set { SetValue(SpeedFactorProperty, value); }
        }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (!e.Handled &&
                ScrollInfo is ScrollContentPresenter scp &&
                ComputedVerticalScrollBarVisibility == System.Windows.Visibility.Visible)
            {
                scp.SetVerticalOffset(VerticalOffset - e.Delta * SpeedFactor);
                e.Handled = true;
            }
        }
    }
}
