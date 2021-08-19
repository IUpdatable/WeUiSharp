

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace WeUiSharp
{
    /// <summary>
    /// Popup拓展类
    /// 
    /// </summary>
    public class PopupEx : Popup
    {
        public static readonly DependencyProperty IsTopmostProperty =
        DependencyProperty.Register("IsTopmost", typeof(bool), typeof(PopupEx), new FrameworkPropertyMetadata(false, OnIsTopmostChanged));

        private bool? _AppliedTopMost;

        /// <summary>
        /// 是否将Popup置顶，默认：false，不置顶
        /// </summary>
        public bool IsTopmost
        {
            get { return (bool)GetValue(IsTopmostProperty); }
            set { SetValue(IsTopmostProperty, value); }
        }

        private bool _AlreadyLoaded;
        public PopupEx()
        {
            this.Loaded += new RoutedEventHandler(PopupNonTopmost_Loaded);

        }

        private System.Windows.Window _parentWindow;
        void PopupNonTopmost_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_AlreadyLoaded)
            {
                _AlreadyLoaded = true;

                if (this.Child != null)
                {
                    this.Child.AddHandler(UIElement.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(Child_PreviewMouseLeftButtonDown), true);
                }

                _parentWindow = System.Windows.Window.GetWindow(this);

                if (_parentWindow != null)
                {
                    _parentWindow.Activated += new EventHandler(ParentWindow_Activated);
                    _parentWindow.Deactivated += new EventHandler(ParentWindow_Deactivated);
                }
            }

        }

        void ParentWindow_Activated(object sender, EventArgs e)
        {
            //Console.WriteLine("ParentWindow_Activated");
            SetTopmostState(true);
        }

        void ParentWindow_Deactivated(object sender, EventArgs e)
        {
            if (IsTopmost == false)
            {
                SetTopmostState(IsTopmost);
            }
        }

        void Child_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetTopmostState(true);

            if (!_parentWindow.IsActive && IsTopmost == false)
            {
                _parentWindow.Activate();
            }
        }

        private static void OnIsTopmostChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var thisobj = obj as PopupEx;

            thisobj.SetTopmostState(thisobj.IsTopmost);
        }

        protected override void OnOpened(EventArgs e)
        {
            SetTopmostState(IsTopmost);
        }

        private void SetTopmostState(bool isTop)
        {
            // Don’t apply state if it’s the same as incoming state
            if (_AppliedTopMost.HasValue && _AppliedTopMost == isTop)
            {
                return;
            }

            if (this.Child != null)
            {
                var hwndSource = (PresentationSource.FromVisual(this.Child)) as HwndSource;

                if (hwndSource != null)
                {
                    var hwnd = hwndSource.Handle;

                    RECT rect;

                    if (GetWindowRect(hwnd, out rect))
                    {
                        //Console.WriteLine("setting z - order " + isTop);
                        if (isTop)
                        {
                            SetWindowPos(hwnd, HWND_TOPMOST, rect.Left, rect.Top, (int)this.Width, (int)this.Height, TOPMOST_FLAGS);
                        }
                        else
                        {
                            // Z-Order would only get refreshed/reflected if clicking the
                            // the titlebar (as opposed to other parts of the external
                            // window) unless I first set the popup to HWND_BOTTOM
                            // then HWND_TOP before HWND_NOTOPMOST
                            SetWindowPos(hwnd, HWND_BOTTOM, rect.Left, rect.Top, (int)this.Width, (int)this.Height, TOPMOST_FLAGS);
                            SetWindowPos(hwnd, HWND_TOP, rect.Left, rect.Top, (int)this.Width, (int)this.Height, TOPMOST_FLAGS);
                            SetWindowPos(hwnd, HWND_NOTOPMOST, rect.Left, rect.Top, (int)this.Width, (int)this.Height, TOPMOST_FLAGS);
                        }

                        _AppliedTopMost = isTop;
                    }
                }
            }
        }

        #region P/Invoke imports & definitions

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
        int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOZORDER = 0x0004;
        const UInt32 SWP_NOREDRAW = 0x0008;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const UInt32 SWP_FRAMECHANGED = 0x0020; /* The frame changed: send WM_NCCALCSIZE */
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 SWP_HIDEWINDOW = 0x0080;
        const UInt32 SWP_NOCOPYBITS = 0x0100;
        const UInt32 SWP_NOOWNERZORDER = 0x0200; /* Don’t do owner Z ordering */
        const UInt32 SWP_NOSENDCHANGING = 0x0400; /* Don’t send WM_WINDOWPOSCHANGING */

        const UInt32 TOPMOST_FLAGS = SWP_NOACTIVATE | SWP_NOOWNERZORDER | SWP_NOSIZE | SWP_NOMOVE | SWP_NOREDRAW | SWP_NOSENDCHANGING;

        #endregion
    }
}

