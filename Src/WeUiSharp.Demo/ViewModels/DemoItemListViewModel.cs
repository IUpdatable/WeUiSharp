using Prism;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WeUiSharp.Demo.Utilities;
using WeUiSharp.Demo.Views;

namespace WeUiSharp.Demo.ViewModels
{
    public class DemoItemListViewModel : BindableBase
    {
        #region [Fields]
        private ObservableCollection<DemoItemViewModel> _DemoItems;
        private int _SelectedIndex;
        private IRegionManager _RegionManager;
        private IContainerProvider _ContainerProvider;
        #endregion

        #region [Properties]
        public ObservableCollection<DemoItemViewModel> DemoItems
        {
            get
            {
                return _DemoItems;
            }
            set
            {
                SetProperty(ref _DemoItems, value);
            }
        }
        public int SelectedIndex 
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                SetProperty(ref _SelectedIndex, value);
                UpdateDetailView();
            }
        }
        #endregion

        public DemoItemListViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _RegionManager = regionManager;
            _ContainerProvider = containerProvider;

            _DemoItems = new ObservableCollection<DemoItemViewModel>();
            _DemoItems.Add(new DemoItemViewModel() { Title = "Overview", Icon="../Resources/Overview.png" });
            _DemoItems.Add(new DemoItemViewModel() { Title = "WeChatLogin", Icon = "../Resources/Overview.png" });

            _SelectedIndex = 0;
            IRegion detailRegion = _RegionManager.Regions[RegionNames.DetailRegion];
            OverviewView overviewView = _ContainerProvider.Resolve<OverviewView>();
            detailRegion.Add(overviewView, nameof(OverviewView));
            detailRegion.Activate(overviewView);
        }

        public void UpdateDetailView()
        {
            IRegion detailRegion = _RegionManager.Regions[RegionNames.DetailRegion];
            if (_SelectedIndex == 0)
            {
                var view = detailRegion.GetView(nameof(OverviewView));
                if (view == null)
                {
                    OverviewView newView = _ContainerProvider.Resolve<OverviewView>();
                    detailRegion.Add(newView, nameof(OverviewView));
                    detailRegion.Activate(newView);
                }
                else
                {
                    detailRegion.Activate(view);
                }
            }
            else if (_SelectedIndex == 1)
            {
                var view = detailRegion.GetView(nameof(WeChatLoginView));
                if (view == null)
                {
                    WeChatLoginView newView = _ContainerProvider.Resolve<WeChatLoginView>();
                    detailRegion.Add(newView, nameof(WeChatLoginView));
                    detailRegion.Activate(newView);
                }
                else
                {
                    detailRegion.Activate(view);
                }
            }
        }
    }
}
