using WeUiSharp.Interfaces;
using System.Windows;

namespace WeUiSharp.Utilities
{
    public class WindowCloser
    {

        public static bool? GetEnableWindowClosing(DependencyObject obj)
        {
            return (bool?)obj.GetValue(EnableWindowClosingProperty);
        }

        public static void SetEnableWindowClosing(DependencyObject obj, bool? value)
        {
            obj.SetValue(EnableWindowClosingProperty, value);
        }

        public static readonly DependencyProperty EnableWindowClosingProperty =
            DependencyProperty.RegisterAttached("EnableWindowClosing", typeof(bool?), typeof(WindowCloser), new PropertyMetadata(null, OnEnableWindowClosingChanged));

        private static void OnEnableWindowClosingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.Loaded += (s1, e1) =>
                {
                    if (window.DataContext is ICloseWindow vm)
                    {
                        vm.Close += () =>
                        {
                            window.Close();
                        };
                        window.Closing += (s2, e2) =>
                        {
                            vm.OnClosing(window);
                            e2.Cancel = !vm.CanClose;
                        };
                    }
                };
            }
        }
    }
}
