using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WeUiSharp.Controls;

namespace WeUiSharp.Windows
{

    public class Window : System.Windows.Window, IDisposable
    {
        #region [Properties]

        #region [CornerRadius] 窗体圆角半径
        /// <summary>
        /// 窗体圆角半径
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set
            {
                //外部调用时，在xaml中赋值不会调用次set
                _CornerRadius = value; // 存到成员变量，以便状态变化后恢复初始设置值
                SetValue(CornerRadiusProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Window), new PropertyMetadata(new CornerRadius(double.NaN)));

        #endregion

        #region [BorderThickness] Border的Thickness

        /// <summary>
        /// Border的Thickness
        /// </summary>
        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set
            {
                //外部调用时，在xaml中赋值不会调用次set
                _BorderThickness = value; // 存到成员变量，以便状态变化后恢复初始设置值
                SetValue(BorderThicknessProperty, value);
            }
        }

        public new static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register(nameof(BorderThickness), typeof(Thickness), typeof(Window), new PropertyMetadata(new Thickness(double.MaxValue)));

        #endregion

        #region [IsResizeEnable] 是否允许变换窗体尺寸

        /// <summary>
        /// 是否允许变换窗体尺寸
        /// </summary>
        public bool IsResizeEnable
        {
            get { return (bool)GetValue(IsResizeEnableProperty); }
            set { SetValue(IsResizeEnableProperty, value); }
        }
        public static readonly DependencyProperty IsResizeEnableProperty =
            DependencyProperty.Register(nameof(IsResizeEnable), typeof(bool), typeof(Window), new PropertyMetadata(true));

        #endregion

        #region [标题相关]

        #region [TitleColor] 标题颜色

        /// <summary>
        /// 标题颜色
        /// </summary>
        public Brush TitleColor
        {
            get { return (Brush)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        public static readonly DependencyProperty TitleColorProperty =
            DependencyProperty.Register(nameof(TitleColor), typeof(Brush), typeof(Window), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        #endregion

        #region [TitleFontSize] 标题字体大小

        /// <summary>
        /// 标题字体大小
        /// </summary>
        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register(nameof(TitleFontSize), typeof(double), typeof(Window), new PropertyMetadata(16.0));

        #endregion

        #region [TitleAlign] 标题对齐方式

        /// <summary>
        /// 标题对齐方式，可选：HorizontalAlignment.Left，HorizontalAlignment.Center
        /// </summary>
        public HorizontalAlignment TitleAlign
        {
            get { return (HorizontalAlignment)GetValue(TitleAlignProperty); }
            set
            {
                if (value == HorizontalAlignment.Right)
                {
                    value = HorizontalAlignment.Center;
                }
                SetValue(TitleAlignProperty, value);
            }
        }

        public static readonly DependencyProperty TitleAlignProperty =
            DependencyProperty.Register(nameof(TitleAlign), typeof(HorizontalAlignment), typeof(Window), new PropertyMetadata(HorizontalAlignment.Center));

        #endregion

        #region [TitleMargin]
        /// <summary>
        /// 标题文字的Margin
        /// </summary>
        public Thickness TitleMargin
        {
            get { return (Thickness)GetValue(TitleMarginProperty); }
            set { SetValue(TitleMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleMarginProperty =
            DependencyProperty.Register(nameof(TitleMargin), typeof(Thickness), typeof(Window), new PropertyMetadata(new Thickness(11, 7, 10, 0)));

        #endregion

        #region [CaptionHeight]
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register(nameof(CaptionHeight), typeof(double), typeof(Window), new PropertyMetadata(30.0));


        #endregion
        #endregion

        #region [阴影相关]

        #region [IsShadowEnable] 是否启用阴影

        /// <summary>
        /// 是否启用阴影，默认启用
        /// </summary>
        public bool IsShadowEnable
        {
            get { return (bool)GetValue(IsShadowEnableProperty); }
            set { SetValue(IsShadowEnableProperty, value); }
        }
        public static readonly DependencyProperty IsShadowEnableProperty =
            DependencyProperty.Register("IsShadowEnable", typeof(bool), typeof(Window), new PropertyMetadata(true));

        #endregion

        #region [ShadowSpaceThickness] 阴影区域大小
        /// <summary>
        /// MainBorder与窗体之间留出来展示阴影的大小，同时区域大小等同于ResizeBorderThickness的大小
        /// </summary>
        public Thickness ShadowSpaceThickness { get; set; }

        #endregion

        #region [ShadowBlurRadius] 阴影半径，数值越大阴影越大

        /// <summary>
        /// 阴影半径，数值越大阴影越大
        /// </summary>
        public double ShadowBlurRadius
        {
            get { return (double)GetValue(ShadowBlurRadiusProperty); }
            set { SetValue(ShadowBlurRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShadowBlurRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShadowBlurRadiusProperty =
            DependencyProperty.Register("ShadowBlurRadius", typeof(double), typeof(Window), new PropertyMetadata(double.NaN));
        #endregion

        #region [ShadowDepth] 阴影的偏移量
        /// <summary>
        /// 阴影的偏移量
        /// </summary>
        public double ShadowDepth
        {
            get { return (double)GetValue(ShadowDepthProperty); }
            set { SetValue(ShadowDepthProperty, value); }
        }
        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register("ShadowDepth", typeof(double), typeof(Window), new PropertyMetadata(double.NaN));
        #endregion

        #region [ShadowDirection] 窗体投影方向（以水平向右为0，逆时针旋转360）
        /// <summary>
        /// 窗体投影方向（以水平向右为0，逆时针旋转360）
        /// </summary>
        public double ShadowDirection
        {
            get { return (double)GetValue(ShadowDirectionProperty); }
            set { SetValue(ShadowDirectionProperty, value); }
        }
        public static readonly DependencyProperty ShadowDirectionProperty =
            DependencyProperty.Register("ShadowDirection", typeof(double), typeof(Window), new PropertyMetadata(double.NaN));


        #endregion

        #region [ShadowColor] 阴影颜色，默认为黑色
        /// <summary>
        /// 阴影颜色，默认为黑色
        /// </summary>
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(Window), new PropertyMetadata(Colors.Black));


        #endregion

        #region [ShadowOpacity] 阴影透明度
        /// <summary>
        /// 窗体阴影透明度
        /// </summary>
        public double ShadowOpacity
        {
            get { return (double)GetValue(ShadowOpacityProperty); }
            set { SetValue(ShadowOpacityProperty, value); }
        }
        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register("ShadowOpacity", typeof(double), typeof(Window), new PropertyMetadata(double.NaN));
        #endregion

        #region [ShadowEffect] 阴影效果
        /// <summary>
        /// 阴影效果
        /// </summary>
        public DropShadowEffect ShadowEffect
        {
            get { return (DropShadowEffect)GetValue(ShadowEffectProperty); }
            set { SetValue(ShadowEffectProperty, value); }
        }

        public static readonly DependencyProperty ShadowEffectProperty =
            DependencyProperty.Register("ShadowEffect", typeof(DropShadowEffect), typeof(Window), new PropertyMetadata(null));
        #endregion

        #endregion

        #region [系统按钮相关]

        #region [IsTopMostBtnEnable] 是否启用置顶按钮
        /// <summary>
        /// 是否启用置顶按钮
        /// </summary>
        public bool IsTopmostBtnEnable
        {
            get { return (bool)GetValue(IsTopmostBtnEnableProperty); }
            set { SetValue(IsTopmostBtnEnableProperty, value); }
        }
        public static readonly DependencyProperty IsTopmostBtnEnableProperty =
            DependencyProperty.Register("IsTopmostBtnEnable", typeof(bool), typeof(Window), new PropertyMetadata(true));
        #endregion

        #region [IsMinBtnEnable] 是否启用最小化按钮
        /// <summary>
        /// 是否启用最小化按钮
        /// </summary>
        public bool IsMinBtnEnable
        {
            get { return (bool)GetValue(IsMinBtnEnableProperty); }
            set { SetValue(IsMinBtnEnableProperty, value); }
        }
        public static readonly DependencyProperty IsMinBtnEnableProperty =
            DependencyProperty.Register("IsMinBtnEnable", typeof(bool), typeof(Window), new PropertyMetadata(true));
        #endregion

        #region [IsMaxBtnEnable] 是否启用最大化按钮
        /// <summary>
        /// 是否启用最大化按钮
        /// </summary>
        public bool IsMaxBtnEnable
        {
            get { return (bool)GetValue(IsIsMaxBtnEnableProperty); }
            set { SetValue(IsIsMaxBtnEnableProperty, value); }
        }
        public static readonly DependencyProperty IsIsMaxBtnEnableProperty =
            DependencyProperty.Register("IsMaxBtnEnable", typeof(bool), typeof(Window), new PropertyMetadata(true));
        #endregion

        #region [IsCloseBtnEnable] 是否启用关闭按钮
        /// <summary>
        /// 是否启用关闭按钮
        /// </summary>
        public bool IsCloseBtnEnable
        {
            get { return (bool)GetValue(IsCloseBtnEnableProperty); }
            set { SetValue(IsCloseBtnEnableProperty, value); }
        }
        public static readonly DependencyProperty IsCloseBtnEnableProperty =
            DependencyProperty.Register("IsCloseBtnEnable", typeof(bool), typeof(Window), new PropertyMetadata(true));
        #endregion

        #endregion

        #region [Alert 报警相关]
        /// <summary>
        /// 报警消息
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AlertMessage
        {
            get { return (string)GetValue(AlertMessageProperty); }
            set { SetValue(AlertMessageProperty, value); }
        }
        public static readonly DependencyProperty AlertMessageProperty =
            DependencyProperty.Register(nameof(AlertMessage), typeof(string), typeof(Window), new PropertyMetadata(""));
        #endregion

        #region [命令相关]

        #region [CloseCommand] 关闭命令
        /// <summary>
        /// 关闭命令
        /// </summary>
        internal ICommand CloseCommand 
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        internal static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(Window), new PropertyMetadata(null));
        #endregion

        #region [MinCommand] 最小化命令
        /// <summary>
        /// 最小化命令
        /// </summary>
        internal ICommand MinCommand
        {
            get { return (ICommand)GetValue(MinCommandProperty); }
            set { SetValue(MinCommandProperty, value); }
        }
        internal static readonly DependencyProperty MinCommandProperty =
            DependencyProperty.Register("MinCommand", typeof(ICommand), typeof(Window), new PropertyMetadata(null));
        #endregion

        #region [MinCommand] 最大化命令
        /// <summary>
        /// 最大化命令
        /// </summary>
        internal ICommand MaxCommand
        {
            get { return (ICommand)GetValue(MaxCommandProperty); }
            set { SetValue(MaxCommandProperty, value); }
        }
        internal static readonly DependencyProperty MaxCommandProperty =
            DependencyProperty.Register("MaxCommand", typeof(ICommand), typeof(Window), new PropertyMetadata(null));
        #endregion

        #region [TopmostCommand] 置顶命令
        /// <summary>
        /// 置顶命令
        /// </summary>
        internal ICommand TopmostCommand
        {
            get { return (ICommand)GetValue(TopmostCommandProperty); }
            set { SetValue(TopmostCommandProperty, value); }
        }
        internal static readonly DependencyProperty TopmostCommandProperty =
            DependencyProperty.Register("TopmostCommand", typeof(ICommand), typeof(Window), new PropertyMetadata(null));
        #endregion

        #region [TriggerAlertCommand] 触发报警命令
        /// <summary>
        /// 触发报警命令
        /// </summary>
        public ICommand TriggerAlertCommand
        {
            get { return (ICommand)GetValue(TriggerAlertCommandProperty); }
            set { SetValue(TriggerAlertCommandProperty, value); }
        }
        public static readonly DependencyProperty TriggerAlertCommandProperty =
            DependencyProperty.Register("TriggerAlertCommand", typeof(ICommand), typeof(Window), new PropertyMetadata(null));
        #endregion

        #region [CancelAlertCommand] 取消报警命令
        /// <summary>
        /// 取消报警命令
        /// </summary>
        public ICommand CancelAlertCommand
        {
            get { return (ICommand)GetValue(CancelAlertCommandProperty); }
            set { SetValue(CancelAlertCommandProperty, value); }
        }
        public static readonly DependencyProperty CancelAlertCommandProperty =
            DependencyProperty.Register("CancelAlertCommand", typeof(ICommand), typeof(Window), new PropertyMetadata(null));
        #endregion

        #endregion

        #endregion

        #region [Fields]
        private Thickness _BorderThickness;
        private CornerRadius _CornerRadius;
        private PopupEx _AlertPopup;
        private Grid _TopCenterAnchor;
        #endregion

        public Window()
        {
            this.Style = Application.Current.FindResource("Window") as Style;

            this.Initialized += Window_Initialized;
            this.Loaded += Window_Loaded;
            this.StateChanged += OnStateChanged;
          
            this.LocationChanged += Window_LocationChanged;
            this.SizeChanged += Window_SizeChanged;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        #region [InitChrome] 初始化Chrome
        /// <summary>
        /// 初始化Chrome
        /// </summary>
        private void InitChrome()
        {

            WindowChrome windowChrome = new WindowChrome();
            if (this.IsResizeEnable)
            {
                this.ResizeMode = ResizeMode.CanResize;
                windowChrome.ResizeBorderThickness = ShadowSpaceThickness;
            }
            else
            {
                this.ResizeMode = ResizeMode.NoResize;
            }

            windowChrome.CornerRadius = this.CornerRadius;
            windowChrome.CaptionHeight = this.CaptionHeight;
            WindowChrome.SetWindowChrome(this, windowChrome);
        }
        #endregion

        #region [InitShadow] 初始化阴影

        /// <summary>
        /// 初始化阴影
        /// </summary>
        private void InitShadow()
        {
            if (!IsShadowEnable)
            {
                return;
            }
            DropShadowEffect dropShadowEffect = new DropShadowEffect();

            double defaultShadowBlurRadius = 20;
            if (!double.IsNaN(this.ShadowBlurRadius) && this.ShadowBlurRadius > 0)
            {
                defaultShadowBlurRadius = this.ShadowBlurRadius;
            }
            dropShadowEffect.BlurRadius = defaultShadowBlurRadius;

            double defaultShadowDepth = 0;
            if (!double.IsNaN(this.ShadowDepth))
            {
                defaultShadowDepth = this.ShadowDepth;
            }
            dropShadowEffect.ShadowDepth = defaultShadowDepth;

            double defaultShadowDirection = 0;
            if (!double.IsNaN(this.ShadowDirection))
            {
                defaultShadowDirection = this.ShadowDirection;
            }
            dropShadowEffect.Direction = defaultShadowDirection;

            Color defaultShadowColor = Colors.Black;
            if (!this.ShadowColor.Equals(Colors.Black))
            {
                defaultShadowColor = this.ShadowColor;
            }
            dropShadowEffect.Color = defaultShadowColor;

            double defaultShadowOpacity = 0.1;
            if (!double.IsNaN(this.ShadowOpacity))
            {
                defaultShadowOpacity = this.ShadowOpacity;
            }
            dropShadowEffect.Opacity = defaultShadowOpacity;

            dropShadowEffect.RenderingBias = RenderingBias.Performance;

            this.ShadowEffect = dropShadowEffect;

            Thickness shadowSpaceThickness = new Thickness();
            double top = dropShadowEffect.BlurRadius / 2 + dropShadowEffect.ShadowDepth * Math.Sin(dropShadowEffect.Direction);
            double bottom = dropShadowEffect.BlurRadius / 2 - dropShadowEffect.ShadowDepth * Math.Sin(dropShadowEffect.Direction);
            double left = dropShadowEffect.BlurRadius / 2 - dropShadowEffect.ShadowDepth * Math.Cos(dropShadowEffect.Direction);
            double right = dropShadowEffect.BlurRadius / 2 + dropShadowEffect.ShadowDepth * Math.Cos(dropShadowEffect.Direction);
            shadowSpaceThickness.Left = left > 0 ? left : 2;
            shadowSpaceThickness.Top = top > 0 ? top : 2;
            shadowSpaceThickness.Right = right > 0 ? right : 2;
            shadowSpaceThickness.Bottom = bottom > 0 ? bottom : 2;
            this.ShadowSpaceThickness = shadowSpaceThickness;
        }
        #endregion

        #region [InitParameters] 初始化参数
        /// <summary>
        /// 初始化参数
        /// </summary>
        private void InitParameters()
        {
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;

            if (this.Background == null)
            {
                this.Background = new SolidColorBrush(Colors.WhiteSmoke);
            }

            CornerRadius nanCornerRadius = new CornerRadius(double.NaN);
            if (this.CornerRadius == nanCornerRadius)
            {
                this.CornerRadius = new CornerRadius(2); // 边框圆角
            }

            Thickness nullThickness = new Thickness(double.MaxValue);
            if (this.BorderThickness == nullThickness)
            {
                this.BorderThickness = new Thickness(1);
            }

            _CornerRadius = this.CornerRadius;
            _BorderThickness = this.BorderThickness;

            //Border的颜色
            if (this.BorderBrush == null)
            {
                this.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFD0D0D0");
            }
            if (this.CaptionHeight == double.NaN)
            {
                this.CaptionHeight = 30.0;
            }
        }
        #endregion

        #region [InitCommands] 初始化命令相关
        /// <summary>
        /// 初始化命令相关
        /// </summary>
        private void InitCommands()
        {
            CloseCommand = new DelegateCommand(CloseWindow);
            MinCommand = new DelegateCommand(MinWindow);
            MaxCommand = new DelegateCommand(MaxWindow);
            TopmostCommand = new DelegateCommand(TopmostWindow);
            TriggerAlertCommand = new DelegateCommand<string>(TriggerAlert, CanTriggerAlert);
            CancelAlertCommand = new DelegateCommand(CancelAlert, CanCancelAlert);
        }

        #endregion

        #region [Commands] 命令相关
        private void CloseWindow()
        {
            this.Close();
        }
        private void MinWindow()
        {
            this.WindowState = WindowState.Minimized;
        }
        private void MaxWindow()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void TopmostWindow()
        {
            if (!this.Topmost)
            {
                Toast.Show("你设置了保持窗口在最前，请在主界面取消");
            }
            this.Topmost = !this.Topmost;
        }

        /// <summary>
        /// 触发一个报警
        /// </summary>
        private void TriggerAlert(string message)
        {
            AlertMessage = message;
            _AlertPopup.IsOpen = true;
            UpdateAlertPanelLocation();
        }
        private bool CanTriggerAlert(string message)
        {
            return IsAlertTriggered();
        }
        private void CancelAlert()
        {
            _AlertPopup.IsOpen = false;

        }
        private bool CanCancelAlert()
        {
            return IsAlertTriggered();
        }
        #endregion

        #region [窗体相关]
        private void Window_Initialized(object sender, EventArgs e)
        {
            InitParameters();
            InitShadow();
            InitChrome();
            InitCommands();
        }

        //static Window()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(typeof(Window)));
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitAlert();
        }
        private void Window_LocationChanged(object sender, EventArgs e)
        {
            UpdateAlertPanelLocation();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateAlertPanelLocation();
        }
        private void OnStateChanged(object sender, EventArgs e)
        {
            UpdateAlertPanelLocation();

            if (this.WindowState == WindowState.Normal)
            {
                SetValue(BorderThicknessProperty, _BorderThickness);

                SetValue(CornerRadiusProperty, _CornerRadius);
            }
            else
            {
                SetValue(BorderThicknessProperty, new Thickness(0));

                SetValue(CornerRadiusProperty, new CornerRadius(0));
                
                //SetValue()

                //解决拓展显示器问题
                //如果使用拓展显示器与首屏的分辨率不同，使用SystemParameters.PrimaryScreenWidth就不是拓展显示器的实际大小。
                var screen = System.Windows.Forms.Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(this).Handle);

                //获取 WPF默认DPI（默认为96） 与 当前显示器DPI 的比例
                PresentationSource source = PresentationSource.FromVisual(this);
                double ratioX = 1;
                double ratioY = 1;
                if (source != null)
                {
                    ratioX = source.CompositionTarget.TransformFromDevice.M11;
                    ratioY = source.CompositionTarget.TransformFromDevice.M22;
                }
                this.MaxHeight = screen.WorkingArea.Height * ratioY + 14;
                this.MaxWidth = screen.WorkingArea.Width * ratioX + 14;
            }

        }

        public void Dispose()
        {
            this.Close();
        }
        #endregion

        #region [Alert相关]

        #region [UpdateAlertPanelLocation] 更新Alert的位置
        /// <summary>
        /// 更新Alert的位置
        /// </summary>
        private void UpdateAlertPanelLocation()
        {
            if (_AlertPopup != null && IsAlertTriggered())
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    _AlertPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.AbsolutePoint;
                    double halfWidth = (_AlertPopup.Child as Border).ActualWidth / 2;
                    _AlertPopup.HorizontalOffset = System.Windows.SystemParameters.PrimaryScreenWidth / 2 - halfWidth + 0.1;
                    _AlertPopup.HorizontalOffset = System.Windows.SystemParameters.PrimaryScreenWidth / 2 - halfWidth;
                }
                else
                {
                    _AlertPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Center;

                    double offsetX = _AlertPopup.HorizontalOffset;
                    _AlertPopup.HorizontalOffset = 0.1;
                    _AlertPopup.HorizontalOffset = 0;

                    double offsetY = _AlertPopup.VerticalOffset;
                    _AlertPopup.VerticalOffset = 0.1 - (_AlertPopup.Child as Border).ActualHeight / 2 - 4;
                    _AlertPopup.VerticalOffset = -(_AlertPopup.Child as Border).ActualHeight / 2 - 4;
                }
            }
        }
        #endregion

        #region [InitAlert] 初始化Alert
        /// <summary>
        /// 初始化Alert
        /// </summary>
        private void InitAlert()
        {
            //放置一个居中置顶的元素作为锚点，让AlertPopup以此来定位
            _TopCenterAnchor = new Grid();
            _TopCenterAnchor.Name = "Anchor";
            _TopCenterAnchor.Width = 1;
            _TopCenterAnchor.Height = 1;
            _TopCenterAnchor.Background = new SolidColorBrush(Colors.Transparent);
            _TopCenterAnchor.Visibility = Visibility.Hidden;
            _TopCenterAnchor.IsHitTestVisible = false;
            _TopCenterAnchor.VerticalAlignment = VerticalAlignment.Top;
            _TopCenterAnchor.HorizontalAlignment = HorizontalAlignment.Center;
            if (this.Content is Grid)
            {
                (this.Content as Grid).Children.Add(_TopCenterAnchor);
            }
            else
            {
                throw new Exception("[InitAlert ERROR]: Please use grid as root node under window!");
            }

            _AlertPopup = new PopupEx();
            _AlertPopup.IsOpen = false;
            _AlertPopup.StaysOpen = true;
            _AlertPopup.AllowsTransparency = true;
            _AlertPopup.Height = 34;
            _AlertPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Center;


            Binding targetBinding = new Binding();
            targetBinding.Source = _TopCenterAnchor;
            targetBinding.Path = new PropertyPath(".");
            _AlertPopup.SetBinding(PopupEx.PlacementTargetProperty, targetBinding);


            Border border = new Border();
            border.CornerRadius = new CornerRadius(2);
            border.Background = (Brush)new BrushConverter().ConvertFromString("#CC5353");
            border.Opacity = 1;

            border.BorderThickness = new Thickness(1);
            border.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#AE4747");

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60) });

            Image icon = new Image();
            icon.Source = new BitmapImage(new Uri("pack://application:,,,/WeUiSharp;component/Resources/Icons/Info_12px.png"));
            icon.Width = 12;
            icon.Height = 12;
            icon.HorizontalAlignment = HorizontalAlignment.Center;
            icon.VerticalAlignment = VerticalAlignment.Center;

            TextBlock textBlock = new TextBlock();
            textBlock.Foreground = new SolidColorBrush(Colors.White);
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.TextWrapping = TextWrapping.Wrap;
            Binding textBinding = new Binding();
            textBinding.Source = this;
            textBinding.Path = new PropertyPath(nameof(AlertMessage));
            textBlock.SetBinding(TextBlock.TextProperty, textBinding);
            ScaleTransform scaleTransform = new ScaleTransform(1.16, 1.16);//拉伸文本
            textBlock.LayoutTransform = scaleTransform;

            Grid.SetColumn(icon, 1);
            Grid.SetColumn(textBlock, 2);

            grid.Children.Add(icon);
            grid.Children.Add(textBlock);

            border.Child = grid;
            _AlertPopup.Child = border;
            if (this.Content is Grid)
            {
                (this.Content as Grid).Children.Add(_AlertPopup);
            }
            else
            {
                throw new Exception("[InitAlert ERROR]: Please use Grid as root node under window!");
            }
        }
        #endregion

        /// <summary>
        /// 是否已经触发了Alert
        /// </summary>
        /// <returns></returns>
        public bool IsAlertTriggered()
        {
            return _AlertPopup.IsOpen;
        }
        #endregion

    }
}
