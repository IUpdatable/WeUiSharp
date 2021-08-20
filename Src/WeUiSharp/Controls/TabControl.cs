using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dragablz;

namespace WeUiSharp.Controls
{
    public class TabControl : TabablzControl
    {
        public TabControl()
        {
            Style style = Application.Current.FindResource("newTabablzControlStyle") as Style;
            base.Style = style;
        }

        static TabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabControl), new FrameworkPropertyMetadata(typeof(TabControl)));
        }
    }
}
