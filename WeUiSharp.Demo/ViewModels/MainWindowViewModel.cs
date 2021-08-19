using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace WeUiSharp.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
        }

    }
}
