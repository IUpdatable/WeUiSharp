using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WeUiSharp.Utilities
{
    public class ScrollBarEx: DependencyObject
    {


        public static double GetVerticalScrollBarWidth(ScrollViewer obj)
        {
            return (double)obj.GetValue(VerticalScrollBarWidthProperty);
        }

        public static void SetVerticalScrollBarWidth(ScrollViewer obj, double value)
        {
            obj.SetValue(VerticalScrollBarWidthProperty, value);
            obj.ApplyTemplate();
            ScrollBar scrollBar = obj.Template.FindName("PART_VerticalScrollBar", obj) as ScrollBar;
            scrollBar.SetValue(Border.WidthProperty, value);

            // 修改圆角
            //Style thumbStyle = obj.FindResource("ScrollBarThumb") as Style;
            //foreach (Setter setter in thumbStyle.Setters)
            //{
            //    if (setter.Property.PropertyType == typeof(ControlTemplate))
            //    {
            //        ControlTemplate template = setter.Value as ControlTemplate;
            //        Border border = template.LoadContent() as Border;

            //        Task.Run(async () =>
            //        {
            //            await Application.Current.Dispatcher.InvokeAsync(() =>
            //            {
            //                border.SetValue(Border.CornerRadiusProperty, new CornerRadius(value));
            //                border.UpdateLayout();
            //            });
            //        });
            //    }
            //}
            
        }

        public static readonly DependencyProperty VerticalScrollBarWidthProperty =
            DependencyProperty.RegisterAttached("VerticalScrollBarWidth", typeof(double), typeof(ScrollViewer), new PropertyMetadata(7.0));


    }

    public static class DependencyObjectExtension
    {
        public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        public static T GetParentOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            var parentObj = VisualTreeHelper.GetParent(depObj);
            var parent = parentObj as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return GetParentOfType<T>(parentObj);
            }

        }
    }
}
