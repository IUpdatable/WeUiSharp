using System;
using System.ComponentModel;
using System.Windows;

namespace WeUiSharp.Interfaces
{
    public interface ICloseWindow
    {
        Action Close { get; set; }
        bool CanClose { get; set; }

        void OnClosing(Window window);
    }
}
