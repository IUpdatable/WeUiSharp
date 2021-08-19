using LanChat.Models;
//using WeHistorian.Common;
//using WeHistorian.Common.Models;
using LanChat.Views;
using Prism;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanChat.ViewModels
{
    public class ArticleListViewModel : BindableBase, INavigationAware, IActiveAware
    {

        #region [Fields]
        private Account _AccountInfo;
        IContainerExtension _Container;
        IRegionManager _RegionManager;
        private bool _IsActive;

        #endregion

        #region [Properties]

        #region [Title]
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return AccountInfo.Name;
            }
        }
        #endregion

        #region [AccountInfo]
        /// <summary>
        /// 账号信息
        /// </summary>
        public Account AccountInfo
        {
            get
            {
                return _AccountInfo;
            }
            set
            {
                SetProperty(ref _AccountInfo, value);
                RaisePropertyChanged(nameof(Title));
            }
        }
        #endregion

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                SetProperty(ref _IsActive, value);
            }
        }
        public event EventHandler IsActiveChanged;
        #endregion

        #region [Constractor]
        public ArticleListViewModel()
        {

        }
        public ArticleListViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;
            _AccountInfo = new Account();
        }
        #endregion

        #region [Implement INavigationAware]
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Account account = navigationContext.Parameters["Account"] as Account;
            if (account != null)
            {
                AccountInfo = account;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Account account = navigationContext.Parameters["Account"] as Account;
            if (account != null)
            {
                return AccountInfo != null && AccountInfo.Id == account.Id;
            }
            else
            {
                return true;
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion



    }
}
