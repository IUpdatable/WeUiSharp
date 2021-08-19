using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeUiSharp.Controls
{
    public class AddButton: System.Windows.Controls.Button
    {
        static AddButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddButton), new FrameworkPropertyMetadata(typeof(AddButton)));
        }
    }
}
