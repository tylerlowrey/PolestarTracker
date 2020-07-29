using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PolestarTracker.WPF.ViewModels
{
    class HelpPageViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public HelpPageViewModel(ViewNavigator navigator) : base(navigator)
        {
            UpdateViewCommand = new UpdateViewCommand(Navigator);
        }
    }
}
