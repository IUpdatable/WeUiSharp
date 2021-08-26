using WeUiSharp.Demo.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Regions;
using WeUiSharp.Demo.Utilities;
using WeUiSharp.Demo.ViewModels;
using WeUiSharp.Localization;

namespace WeUiSharp.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            
            var ttt = SystemColors.GrayTextBrush.Color;  // #FF6D6D6D
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<OverviewView>();
        }
        protected override void Initialize()
        {
            base.Initialize();

            // --------------------------- 确定默认语言 ---------------------------------------
            string cultureName = System.Globalization.CultureInfo.CurrentCulture.Name;

            // zh-CN 0x0804 中文（中国） zh-Hans 0x0004 中文（简体） zh-SG 0x1004 中文（新加坡）
            if (cultureName.Equals("zh-CN") || cultureName.Equals("zh-Hans") || cultureName.Equals("zh-SG"))
            {
                TranslationSource.Instance.Language = "zh-CN";
            }
            // zh-Hant 中文（繁体） zh-TW 中文（台湾）zh-HK 中文（香港特别行政区，中国）zh-MO 中文（澳门特别行政区）
            else if (cultureName.Equals("zh-Hant") || cultureName.Equals("zh-TW") || cultureName.Equals("zh-MO"))
            {
                TranslationSource.Instance.Language = "zh-Hant";
            }
            else
            {
                // 非中文系统全部按英文系统处理
                TranslationSource.Instance.Language = "en";
            }
        }
    }
}
