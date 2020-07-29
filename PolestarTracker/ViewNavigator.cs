using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PolestarTracker.WPF.ViewModels;

namespace PolestarTracker.WPF
{
    public enum ViewType
    {
        Main,
        SettingsPage,
        HelpPage,
    }

    public class ViewNavigator : INotifyPropertyChanged
    {

        private ViewModelBase _currentViewModel;
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
