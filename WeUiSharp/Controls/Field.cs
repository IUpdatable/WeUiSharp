using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeUiSharp.Enums;
using WeUiSharp.Windows;
using System.Windows.Controls;
using System.Security;

namespace WeUiSharp.Controls
{
    public class Field: System.Windows.Controls.TextBox
    {
        #region [Fields]
        private PasswordBox _PasswordBox;
        #endregion
        static Field()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Field), new FrameworkPropertyMetadata(typeof(Field)));
        }

        public Field()
        {
            ClearInputCommand = new DelegateCommand<object>(OnClearInput);
            PasswordChangedCommand = new DelegateCommand<object>(OnPasswordChanged);
            KeyboardNavigation.SetIsTabStop(this, true);
        }

        #region [PlaceHolder]


        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }
        /// <summary>
        /// PlaceHolder
        /// </summary>
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(Field), new PropertyMetadata(null, OnPlaceHolderChanged));

        private static void OnPlaceHolderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }


        #endregion

        #region [IsClearAndLostFocus]
        public bool IsClearAndLostFocus
        {
            get { return (bool)GetValue(IsClearAndLostFocusProperty); }
            set { SetValue(IsClearAndLostFocusProperty, value); }
        }
        /// <summary>
        /// IsClearAndLostFocus：点击清除输入按钮，是否同时失去焦点，默认：True
        /// </summary>
        public static readonly DependencyProperty IsClearAndLostFocusProperty =
            DependencyProperty.Register("IsClearAndLostFocus", typeof(bool), typeof(Field), new PropertyMetadata(true));


        #endregion

        #region [ClearInputCommand] 清除输入命令
        /// <summary>
        /// 清除输入命令
        /// </summary>
        internal ICommand ClearInputCommand
        {
            get { return (ICommand)GetValue(ClearInputCommandProperty); }
            set { SetValue(ClearInputCommandProperty, value); }
        }
        internal static readonly DependencyProperty ClearInputCommandProperty =
            DependencyProperty.Register(nameof(ClearInputCommand), typeof(ICommand), typeof(Field), new PropertyMetadata(null));
        #endregion

        #region [PasswordChangedCommand] 密码输入变更命令
        /// <summary>
        /// 密码输入变更命令
        /// </summary>
        internal ICommand PasswordChangedCommand
        {
            get { return (ICommand)GetValue(PasswordChangedCommandProperty); }
            set { SetValue(PasswordChangedCommandProperty, value); }
        }
        internal static readonly DependencyProperty PasswordChangedCommandProperty =
            DependencyProperty.Register(nameof(PasswordChangedCommand), typeof(ICommand), typeof(Field), new PropertyMetadata(null));
        #endregion

        #region [IsPassword] 是否是密码输入框
        /// <summary>
        /// 是否是密码输入框
        /// </summary>
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.Register("IsPassword", typeof(bool), typeof(Field), new PropertyMetadata(false, OnIsPasswordChanged));

        private static void OnIsPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Field field)
            {
                // 默认的文本输入与PasswordBox会同时占用TabStop，这里加以限制
                KeyboardNavigation.SetIsTabStop(field, !(bool)e.NewValue);
            }
        }
        #endregion

        #region [Password] 密码

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(Field), new PropertyMetadata(null));
        #endregion

        #region [IsHasContent] 是否有内容

        /// <summary>
        /// 是否有内容
        /// </summary>
        public bool IsHasContent
        {
            get { return (bool)GetValue(IsHasContentProperty); }
            set { SetValue(IsHasContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsHasContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHasContentProperty =
            DependencyProperty.Register("IsHasContent", typeof(bool), typeof(Field), new PropertyMetadata(false));


        #endregion

        private void OnClearInput(object obj)
        {
            
            this.Text = string.Empty;
            if (IsClearAndLostFocus)
            {
                this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            if (IsPassword && _PasswordBox != null)
            {
                _PasswordBox.Clear();
            }
            IsHasContent = false;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            IsHasContent = true;

            base.OnTextChanged(e);

            // 确保光标一直在最后
            this.CaretIndex = this.Text.Length;
            this.ScrollToHorizontalOffset(double.MaxValue);
        }

        private void OnPasswordChanged(object sender)
        {
            if (sender is PasswordBox passwordBox)
            {
                Password = passwordBox.Password;
                if (_PasswordBox == null)
                {
                    _PasswordBox = passwordBox;
                }
                IsHasContent = true;
            }
        }
    }
}
