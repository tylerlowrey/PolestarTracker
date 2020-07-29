using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using PolestarTracker.Core;

namespace PolestarTracker.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICommand UpdateViewCommand { get; set; }

        private string _currentWindowTitle;
        private string _currentProcessName;
        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentWindowTitle
        {
            get => _currentWindowTitle;
            set
            {
                _currentWindowTitle = value;
                OnPropertyChanged();
            }

        }

        public string CurrentProcessName
        {
            get => _currentProcessName;
            set
            {
                _currentProcessName = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel(ViewNavigator navigator) : base(navigator)
        {
            UpdateViewCommand = new UpdateViewCommand(Navigator);
            CurrentWindowTitle = ProcessTracker.GetActiveWindowTitle();
            CurrentProcessName = ProcessTracker.GetActiveProcessName();

            //Periodically update the currently active window title
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };

            timer.Tick += (o, e) =>
            {
                CurrentWindowTitle = ProcessTracker.GetActiveWindowTitle();
                CurrentProcessName = ProcessTracker.GetActiveProcessName();
            };
            timer.IsEnabled = true;

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
