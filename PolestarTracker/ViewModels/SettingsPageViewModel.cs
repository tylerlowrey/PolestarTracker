using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using PolestarTracker.Core.Models;

namespace PolestarTracker.WPF.ViewModels
{
    class SettingsPageViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }

        public ObservableCollection<ApplicationAlias> ApplicationAliasesCollection { get; set; }
        public ObservableCollection<ApplicationFilter> ApplicationFiltersCollection { get; set; }
        public SettingsPageViewModel(ViewNavigator navigator) : base(navigator)
        {
            UpdateViewCommand = new UpdateViewCommand(Navigator);
        }
    }
}
