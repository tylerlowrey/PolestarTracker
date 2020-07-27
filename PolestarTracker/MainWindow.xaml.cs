﻿using System;
using System.Windows;
using System.Windows.Threading;
using PolestarTracker.Core;

namespace PolestarTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentWindowTitle.Content = ProcessTracker.GetActiveWindowTitle();
            CurrentProcessName.Content = ProcessTracker.GetActiveProcessName();

            //Periodically update the currently active window title
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };

            timer.Tick += (o, e) =>
            {
                CurrentWindowTitle.Content = ProcessTracker.GetActiveWindowTitle();
                CurrentProcessName.Content = ProcessTracker.GetActiveProcessName();
            };
            timer.IsEnabled = true;

        }
    }
}
