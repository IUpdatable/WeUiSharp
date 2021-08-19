using LanChat.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace LanChat.ViewModels
{
    public class AccountViewModel : BindableBase
    {
        #region [Fields]
        private IContainerExtension _Container;
        private IRegionManager _RegionManager;
        #endregion

        #region [Properties]
        public Account Account { get; set; }
        public ICommand NavigateCommand { get; private set; }

        #endregion

        public AccountViewModel()
        {

        }

        public AccountViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;
            Account = new Account();
            NavigateCommand = new DelegateCommand<Account>(OnNavigate, CanNavigate);
        }

        private void OnNavigate(Account account)
        {
            NavigationParameters keyValuePairs = new NavigationParameters();
            keyValuePairs.Add("Account", account);
            //_RegionManager.RequestNavigate("DocumentsRegion", nameof(ArticleListView), keyValuePairs);
        }

        private bool CanNavigate(Account account)
        {
            return true;
        }
    }
}
