using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PolestarTracker.WPF;
using PolestarTracker.WPF.ViewModels;

namespace PolestarTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Start tracking productivity and logging it

            //Code for setting up MVVM 
            ViewNavigator viewNavigator = new ViewNavigator();
            MainViewModel defaultViewModel = new MainViewModel(viewNavigator);
            viewNavigator.CurrentViewModel = defaultViewModel;
            Window window = new MainWindow();
            window.DataContext = defaultViewModel;
            window.Show();
            base.OnStartup(e);
        }
    }
}
