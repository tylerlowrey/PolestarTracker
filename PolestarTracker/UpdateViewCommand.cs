using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using PolestarTracker.WPF.ViewModels;

namespace PolestarTracker.WPF
{
    class UpdateViewCommand : ICommand
    {
        private readonly ViewNavigator _navigator;

        public UpdateViewCommand(ViewNavigator navigator)
        {
            this._navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch ((ViewNavigator.Views) parameter)
            {
                case ViewNavigator.Views.Main:
                    _navigator.CurrentViewModel = new MainViewModel(_navigator);
                    break;
                case ViewNavigator.Views.SettingsPage:
                    _navigator.CurrentViewModel = new SettingsPageViewModel(_navigator);
                    break;
                case ViewNavigator.Views.HelpPage:
                    _navigator.CurrentViewModel = new HelpPageViewModel(_navigator);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
