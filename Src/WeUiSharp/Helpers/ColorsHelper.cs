using System;
using System.Collections;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using WeUiSharp.Helpers;

namespace WeUiSharp
{
    internal class ColorsHelper : DispatcherObject
    {
        private readonly ResourceDictionary _colors = new ResourceDictionary();

        private Color _SystemBackground;

        private ColorsHelper()
        {
        }

        public static ColorsHelper Current { get; } = new ColorsHelper();

        public ResourceDictionary Colors => _colors;

        public ApplicationTheme? SystemTheme { get; private set; }

        public event EventHandler SystemThemeChanged;

        public void UpdateBrushes(ResourceDictionary themeDictionary)
        {
            UpdateBrushes(themeDictionary, _colors);
        }

        public static void UpdateBrushes(ResourceDictionary themeDictionary, ResourceDictionary colors)
        {
            foreach (DictionaryEntry entry in themeDictionary)
            {
                if (entry.Value is SolidColorBrush brush && !brush.IsFrozen)
                {
                    object colorKey = ThemeResourceHelper.GetColorKey(brush);
                    if (colorKey != null && colors.Contains(colorKey))
                    {
                        brush.SetCurrentValue(SolidColorBrush.ColorProperty, (Color)colors[colorKey]);
                    }
                }
            }
        }

        private void UpdateSystemAppTheme()
        {
            SystemTheme = IsDarkBackground(_SystemBackground) ? ApplicationTheme.Dark : ApplicationTheme.Light;
        }

        private static bool IsDarkBackground(Color color)
        {
            return color.R + color.G + color.B < (255 * 3 - color.R - color.G - color.B);
        }
    }
}
