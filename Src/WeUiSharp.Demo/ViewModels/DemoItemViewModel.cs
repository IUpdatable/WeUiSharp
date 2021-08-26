using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeUiSharp.Demo.ViewModels
{
    public class DemoItemViewModel : BindableBase
    {
        #region [Properties]
        public string Title { get; set; }
        public string Icon { get; set; }
        #endregion
        public DemoItemViewModel()
        {

        }
    }
}
