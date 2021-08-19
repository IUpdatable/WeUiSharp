using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeHistorian.Common;
using WeHistorian.Controls;

namespace WeHistorian.Modules.Accounts.Views
{
    public class MenuItem : HamburgerMenuItemBase
    {

        #region [Fields]
        private IContainerExtension _Container;
        private IRegionManager _RegionManager;
        private AccountsListView _AccountsListView;
        private string _ViewName;
        #endregion

        public MenuItem(IContainerExtension container, IRegionManager regionManager)
        {
            //配置图标
            MenuItemImgSrc = new BitmapImage(new Uri("pack://application:,,,/WeHistorian.Modules.Accounts;component/Resources/Icons/Contract.png"));
            MenuItemMouseOverImgSrc = new BitmapImage(new Uri("pack://application:,,/WeHistorian.Modules.Accounts;component/Resources/Icons/Contract_MouseOver.png"));
            MenuItemCheckedImgSrc = new BitmapImage(new Uri("pack://application:,,/WeHistorian.Modules.Accounts;component/Resources/Icons/Contract_Checked.png"));

            //配置ToolTip
            ToolTip = "公众号列表";

            _Container = container;
            _RegionManager = regionManager;
            _ViewName = "Accounts";
            _AccountsListView = _Container.Resolve<AccountsListView>();
            _AccountsListView.Name = _ViewName;
            IRegion listRegion = _RegionManager.Regions[Global.ListRegion];
            if (listRegion.GetView(_ViewName) == null)
            {
                listRegion.Add(_AccountsListView, _ViewName);
                listRegion.Deactivate(_AccountsListView);
            }
            this.Checked += OnChecked;
            this.IsChecked = true;
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            MenuItem radioButton = sender as MenuItem;
            if (radioButton.IsChecked.HasValue)
            {
                IRegion listRegion = _RegionManager.Regions[Global.ListRegion];

                if (radioButton.IsChecked.Value)
                {
                    if (listRegion.GetView(_ViewName) != null)
                    {
                        listRegion.Activate(_AccountsListView);
                    }
                }
            }
        }

    }
}
