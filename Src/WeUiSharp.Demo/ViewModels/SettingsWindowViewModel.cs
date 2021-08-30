using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WeUiSharp.Localization;

namespace WeUiSharp.Demo.ViewModels
{
    public class SettingsWindowViewModel : BindableBase
    {
        #region [Fields]
        private int _LanguageIndex;
        #endregion

        #region [Properties]
        public int LanguageIndex
        {
            get
            {
                return _LanguageIndex;
            }
            set
            {
                SetProperty(ref _LanguageIndex, value);
                if (value == 0)
                {
                    TranslationSource.Instance.Language = "zh-CN";
                }
                else if (value == 1)
                {
                    TranslationSource.Instance.Language = "en";
                }
                else if (value == 2)
                {
                    TranslationSource.Instance.Language = "zh-Hant";
                }
            }
        }
        #endregion
        public SettingsWindowViewModel()
        {
            InitLanguage();
        }

        private void InitLanguage()
        {
            if (TranslationSource.Instance.Language == "zh-CN")
            {
                _LanguageIndex = 0;
            }
            else if (TranslationSource.Instance.Language == "en")
            {
                _LanguageIndex = 1;
            }
            else if (TranslationSource.Instance.Language == "zh-Hant")
            {
                _LanguageIndex = 1;
            }
            else
            {
                _LanguageIndex = 0;
            }
        }
    }
}
