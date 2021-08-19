using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeUiSharp.Controls
{
    public class MenuItemSeparator: System.Windows.Controls.Separator
    {
        static MenuItemSeparator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuItemSeparator), new FrameworkPropertyMetadata(typeof(MenuItemSeparator)));
        }
        
    }
}
