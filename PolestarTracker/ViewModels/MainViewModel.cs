using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using PolestarTracker.Core;
using PolestarTracker.Core.Models;
using PolestarTracker.EntityFramework;

namespace PolestarTracker.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public SeriesCollection DailyApplicationUseDataCollection
        {
            get => _dailyApplicationUseDataCollection;
            private set
            {
                _dailyApplicationUseDataCollection = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection DailyProductivityDataCollection
        {
            get => _dailyProductivityDataCollection;
            set
            {
                _dailyProductivityDataCollection = value;
                OnPropertyChanged();
            }
        } 

        public string[] DailyProductivityAxisLabels { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _currentWindowTitle;
        public string CurrentWindowTitle
        {
            get => _currentWindowTitle;
            set
            {
                _currentWindowTitle = value;
                OnPropertyChanged();
            }

        }

        private string _currentProcessName;
        public string CurrentProcessName
        {
            get => _currentProcessName;
            set
            {
                _currentProcessName = value;
                OnPropertyChanged();
            }
        }

        private readonly TrackingDataContext _dbContext;
        private SeriesCollection _dailyApplicationUseDataCollection;
        private SeriesCollection _dailyProductivityDataCollection;

        public MainViewModel(ViewNavigator navigator) : base(navigator)
        {
            UpdateViewCommand = new UpdateViewCommand(Navigator);

            _dbContext = new TrackingDataContext();

            DailyApplicationUseDataCollection = new SeriesCollection();
            DailyProductivityDataCollection = new SeriesCollection();
            DailyProductivityAxisLabels = new[] {"Productive Time", "Unproductive Time"};

            DispatcherTimer dataUpdateTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(60000),
            };

            dataUpdateTimer.Tick += (o, e) =>
            {
                UpdateChartData();
            };
            dataUpdateTimer.IsEnabled = true;

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

            UpdateChartData();
        }

        private IEnumerable<TrackingRecord> GetTrackingData()
        {
            return _dbContext.TrackingRecords.AsEnumerable()?.ToList();
        }

        private void UpdateChartData()
        {
            UpdateDailyProductivityChart();
            UpdateDailyApplicationUseChart();
        }

        private void UpdateDailyProductivityChart()
        {
            var updatedDailyProductivityData = new SeriesCollection();
            var trackingData = GetTrackingData().ToList();

            // Add active minutes
            updatedDailyProductivityData.Add(new RowSeries
            {
                Title = "Productive Time",
                Values = new ChartValues<ObservableValue>
                {
                    new ObservableValue(trackingData.Count(item => item.Active) / 60)
                }
            });

            // Add inactive minutes
            updatedDailyProductivityData.Add(new RowSeries
            {
                Title = "Unproductive Time",
                Values = new ChartValues<ObservableValue>
                {
                    new ObservableValue(trackingData.Count(item => !item.Active) / 60)
                }
            });

            DailyProductivityDataCollection = updatedDailyProductivityData;
        }

        private void UpdateDailyApplicationUseChart()
        {
            var updatedDailyApplicationData = new SeriesCollection();
            var listOfData = GetTrackingData();
            var listOfActiveData = listOfData.Where(item => item.Active && item.Timestamp > DateTime.Today)
                                             .ToList();

            //Find all unique processes
            var uniqueProcessesList = listOfActiveData.Select(item => item.ProcessName)
                                                      .Distinct()
                                                      .ToList();

            var uniqueProcessesGroups = listOfActiveData.GroupBy(item => item.ProcessName)
                                                        .OrderByDescending(item => item.Count())
                                                        .Take(10);

            foreach (var processGroup in uniqueProcessesGroups)
            {
                updatedDailyApplicationData.Add(new PieSeries
                {
                    Title = processGroup.Key,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(processGroup
                                            .Select(item => item.ProcessName)
                                            .Count(itemProcessName => itemProcessName == processGroup.Key) / 60)
                    },
                    DataLabels = true,
                });
            }

            DailyApplicationUseDataCollection = updatedDailyApplicationData;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
