using Prism.Mvvm;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;
using Prism.Commands;
using System.Windows.Controls.Primitives;
using Prism.Regions;
using Prism.Ioc;
using WeUiSharp.Demo.Utilities;
using WeUiSharp.Demo.Views;
using System.Windows.Controls;
using System.Collections.Generic;
using WeUiSharp.Windows;
using WeUiSharp.Demo.Properties;
using System.Threading;
using WeUiSharp.Localization;
using System.ComponentModel;

namespace WeUiSharp.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region [Fields]
        private string _Title = "Hello WeUiSharp";
        private ICommand _SwitchMenuItemCommand;
        private ICommand _LoadedCommand;
        private IRegionManager _RegionManager;
        private IContainerProvider _ContainerProvider;
        private ICommand _MenuItemCommand;
        private List<MenuItem> _MenuItems;
        #endregion

        #region [Properites]
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        public ICommand SwitchMenuItemCommand
        {
            get
            {
                if (_SwitchMenuItemCommand == null)
                {
                    _SwitchMenuItemCommand = new DelegateCommand<object>(OnSwitchMenuItem);
                }

                return _SwitchMenuItemCommand;
            }
        }
        public ICommand LoadedCommand
        {
            get
            {
                if (_LoadedCommand == null)
                {
                    _LoadedCommand = new DelegateCommand<object>(OnLoaded);
                }

                return _LoadedCommand;
            }
        }
        public List<MenuItem> MenuItems { get => _MenuItems; }
        #endregion


        public MainWindowViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _RegionManager = regionManager;
            _ContainerProvider = containerProvider;
        }

        private void OnSwitchMenuItem(object obj)
        {
            if (obj is ToggleButton toggleButton)
            {
                IRegion listRegion = _RegionManager.Regions[RegionNames.ListRegion];
                if (toggleButton.Name.Equals("ComponentMenuItem"))
                {
                    var view = listRegion.GetView(nameof(DemoItemListView));
                    if (view == null)
                    {
                        DemoItemListView newView = _ContainerProvider.Resolve<DemoItemListView>();
                        listRegion.Add(newView, nameof(DemoItemListView));
                        listRegion.Activate(newView);
                    }
                    else
                    {
                        listRegion.Activate(view);
                        ((view as DemoItemListView).DataContext as DemoItemListViewModel).UpdateDetailView();
                    }
                }
                else if (toggleButton.Name.Equals("YourCustomMenuItem"))
                {
                    var listView = listRegion.GetView(nameof(MyCustomListView));
                    if (listView == null)
                    {
                        MyCustomListView newListView = _ContainerProvider.Resolve<MyCustomListView>();
                        listRegion.Add(newListView, nameof(MyCustomListView));
                        listRegion.Activate(newListView);
                    }
                    else
                    {
                        listRegion.Activate(listView);
                    }

                    IRegion detailRegion = _RegionManager.Regions[RegionNames.DetailRegion];
                    var detailView = detailRegion.GetView(nameof(MyCustomDetailView));
                    if (detailView == null)
                    {
                        MyCustomDetailView newDetailView = _ContainerProvider.Resolve<MyCustomDetailView>();
                        detailRegion.Add(newDetailView, nameof(MyCustomDetailView));
                        detailRegion.Activate(newDetailView);
                    }
                    else
                    {
                        detailRegion.Activate(detailView);
                    }
                }
            }
        }

        private void OnLoaded(object sender)
        {
            if (sender is MainWindow mainWindow)
            {
                // default: select Overview 
                mainWindow.ComponentMenuItem.IsChecked = true;

                IRegion listRegion = _RegionManager.Regions[RegionNames.ListRegion];
                DemoItemListView demoItemListView = _ContainerProvider.Resolve<DemoItemListView>();
                listRegion.Add(demoItemListView, nameof(DemoItemListView));
                listRegion.Activate(demoItemListView);

                InitContextMenu();
                TranslationSource.Instance.PropertyChanged += TranslationInstance_PropertyChanged;
            }
        }

        private void TranslationInstance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InitContextMenu();
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
                Header = Strings.ResourceManager.GetString(nameof(Strings.Settings), Thread.CurrentThread.CurrentUICulture),
                Command = _MenuItemCommand
            };
            menuItem3.CommandParameter = menuItem3;

            _MenuItems.Add(menuItem1);
            _MenuItems.Add(menuItem2);
            _MenuItems.Add(menuItem3);
        }

        private void OnClickMenuItem(object obj)
        {
            if (obj is MenuItem menuItem)
            {
                string settingsStr = Strings.ResourceManager.GetString(nameof(Strings.Settings), Thread.CurrentThread.CurrentUICulture);
                if (menuItem.Header.Equals(settingsStr))
                {
                    SettingsWindow settingsWindow = new SettingsWindow();
                    settingsWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You clicked " + menuItem.Header, "ContextMenu");
                }
            }
        }
    }
}
