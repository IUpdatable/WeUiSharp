using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeUiSharp.Windows
{
    public class DocumentBase : UserControl
    {
        #region [Properties]

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DocumentBase), new PropertyMetadata("This is Title"));

        #endregion

        

        //static DocumentBase()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(DocumentBase), new FrameworkPropertyMetadata(typeof(DocumentBase)));
        //}
    }
}
