using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using PolestarTracker.Core;
using PolestarTracker.Core.Models;
using PolestarTracker.EntityFramework;
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
            ApplicationDataContext applicationDataContext = new ApplicationDataContext();
            MouseTracker mouseTracker = new MouseTracker();
            KeyboardTracker keyboardTracker = new KeyboardTracker();

            
            //Set timer to record activity data every second
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };

            //Start tracking productivity and logging it
            timer.Tick += (o, e) =>
            {
                var newTrackingRecord = new TrackingRecord
                {
                    Active = false,
                    ProcessName = ProcessTracker.GetActiveProcessName(),
                    Timestamp = DateTime.Now
                };

                if (mouseTracker.HasMouseMoved() || keyboardTracker.GetTimeElapsedSinceLastKeyPress() < timer.Interval.TotalMilliseconds)
                {
                    newTrackingRecord.Active = true;
                    applicationDataContext.Add(newTrackingRecord);
                }
                else
                {
                    applicationDataContext.Add(newTrackingRecord);
                }

                applicationDataContext.SaveChanges();

            };
            timer.IsEnabled = true;

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
