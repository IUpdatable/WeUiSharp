using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WeUiSharp.Localization;
using WeUiSharp.Models;
using WeUiSharp.Windows;

namespace WeUiSharp.Demo.ViewModels
{
    public class OverviewViewModel : BindableBase
    {
        #region [Fields]
        private List<MenuItem> _MenuItems;
        private ICommand _MenuItemCommand;
        private int _LanguageIndex;
        #endregion
        #region [Properties]
        public List<MenuItem> MenuItems { get => _MenuItems; }

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

        public OverviewViewModel()
        {
            InitContextMenu();
            InitLanguage();
        }

        private void OnClickMenuItem(object obj)
        {
            if (obj is MenuItem menuItem)
            {
                MessageBox.Show("You clicked " + menuItem.Header, "ContextMenu");
            }
        }

        private void InitContextMenu()
        {
            _MenuItemCommand = new DelegateCommand<object>(OnClickMenuItem);
            _MenuItems = new List<MenuItem>();
            var menuItem1 = new MenuItem()
            {
                Header = "Item1",
                Command = _MenuItemCommand
            };
            menuItem1.CommandParameter = menuItem1;
            var menuItem2 = new MenuItem()
            {
                Header = "Item2",
                Command = _MenuItemCommand
            };
            menuItem2.CommandParameter = menuItem2;
            var menuItem3 = new MenuItem()
            {
                Header = "Item3",

                Command = _MenuItemCommand
            };
            menuItem3.CommandParameter = menuItem3;
            var menuItem4 = new MenuItem()
            {
                Header = "Item4",
                IsEnabled = false,
                Command = _MenuItemCommand
            };
            menuItem4.CommandParameter = menuItem4;
            _MenuItems.Add(menuItem1);
            _MenuItems.Add(menuItem2);
            _MenuItems.Add(null); // 分割线 MenuItemSeparator
            _MenuItems.Add(menuItem3);
            _MenuItems.Add(menuItem4);
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
