using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PolestarTracker.WPF.ViewModels
{
    class SettingsPageViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public SettingsPageViewModel(ViewNavigator navigator) : base(navigator)
        {
            UpdateViewCommand = new UpdateViewCommand(Navigator);
        }
    }
}
