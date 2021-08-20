using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WeUiSharp.Models
{
    public class ContextMenuCommandItem: BindableBase
    {
        #region [Fields]
        private string _Header;
        private Visibility _Visibility;
        private ICommand _Command;
        #endregion

        public string Header 
        {
            get
            {
                return _Header;
            }
            set
            {
                SetProperty(ref _Header, value);
            }
        }
        public ICommand Command
        {
            get
            {
                return _Command;
            }
            set
            {
                SetProperty(ref _Command, value);
                _Command.CanExecuteChanged += Command_CanExecuteChanged;
            }
        }

        private void Command_CanExecuteChanged(object sender, EventArgs e)
        {
            if (_Command.CanExecute(null))
            {
                _Visibility = Visibility.Visible;
                RaisePropertyChanged(nameof(Visibility));
            }
            else
            {
                _Visibility = Visibility.Collapsed;
                RaisePropertyChanged(nameof(Visibility));
            }
        }

        public Visibility Visibility
        {
            get
            {
                return _Visibility;
            }
            set
            {
                SetProperty(ref _Visibility, value);
            }
        }

        public ContextMenuCommandItem()
        {
            _Visibility = Visibility.Visible;

        }
    }
}
