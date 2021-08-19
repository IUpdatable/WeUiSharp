using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace LanChat.ViewModels
{
    public class AccountsListViewModel : BindableBase
    {

        #region [Fields]
        IContainerExtension _Container;
        IRegionManager _RegionManager;
        #endregion

        #region [Properties]
        public ObservableCollection<AccountViewModel> AccountViewModels { get; set; }

        #endregion

        #region [Constructor]

        public AccountsListViewModel()
        {

        }
        public AccountsListViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;

            AccountViewModels = new ObservableCollection<AccountViewModel>();

            for (int i = 0; i < 300; i++)
            {
                AccountViewModel accountViewModel = new AccountViewModel(container, regionManager);

                accountViewModel.Account.Id = "ID" + i.ToString();
                accountViewModel.Account.Name = i.ToString();
                accountViewModel.Account.Avatar = "pack://application:,,/Resources/Icons/UserDefaultAvatar.png";
                AccountViewModels.Add(accountViewModel);
            }
        }
        #endregion
    }
}
