using Prism.Mvvm;

namespace WeUiSharp.HelloWorldWithPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Hello WeUiSharp";
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
