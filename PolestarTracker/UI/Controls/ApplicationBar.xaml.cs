using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace PolestarTracker.WPF.UI.Controls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class ApplicationBar : UserControl
    {
        private double _previousWindowHeight;
        private double _previousWindowWidth;
        private double _previousWindowTop;
        private double _previousWindowLeft;

        public ApplicationBar()
        {
            InitializeComponent();
            _previousWindowHeight = SystemParameters.WorkArea.Width;
            _previousWindowWidth =  SystemParameters.WorkArea.Height;
        }

        
        /**
         * Resizes the window on double clicking the UIElement
         *
         * Resizes to full screen (but still showing the taskbar) if the current window is smaller than full screen,
         * otherwise it resizes the screen back down to the size it was previously
         */
        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid appBar = (Grid)FindName("AppBarGrid");
            if (e.ClickCount == 2)
            {
                if (Width < System.Windows.SystemParameters.WorkArea.Width ||
                   GetParentWindow().Height < System.Windows.SystemParameters.WorkArea.Height)
                {
                    RecordCurrentWindowSizeAndPosition();
                    MaximizeWindow(appBar);
                }
                else
                {
                    var (previousHeight, previousWidth, 
                        previousTop, previousLeft) = GetPreviousWindowSizeAndPosition();

                    //Catches edge case where window is not max size but still in the maximized state
                    // TODO: Fix issue where minimizing from a maximized state will prevent double clicking 
                    if (GetParentWindow().WindowState == WindowState.Maximized)
                    {
                        GetParentWindow().WindowState = WindowState.Normal;
                        appBar.Margin = new Thickness(0);
                    }

                    GetParentWindow().Height = previousHeight;
                    GetParentWindow().Width = previousWidth;
                    GetParentWindow().Top = previousTop;
                    GetParentWindow().Left = previousLeft;

                    RecordCurrentWindowSizeAndPosition();
                }
            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            GetParentWindow().Close();
        }

        private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            GetParentWindow().WindowState = WindowState.Minimized;
        }

        private void WindowRestoreButton_OnClick(object sender, RoutedEventArgs e)
        {
            Grid appBar = (Grid)FindName("AppBarGrid");
            if (GetParentWindow().WindowState == WindowState.Normal)
            {
                MaximizeWindow(appBar);
            }
            else
            {
                MinimizeWindow(appBar);
            }
        }

        private void MaximizeWindow(Grid appBar)
        {
            RecordCurrentWindowSizeAndPosition();
            PackIcon windowRestoreIcon = (PackIcon) FindName("WindowRestoreIcon");
            windowRestoreIcon.Kind = PackIconKind.WindowRestore;
            GetParentWindow().WindowState = WindowState.Maximized;
            appBar.Margin = new Thickness(0, 6, 0, 0);
        }

        private void MinimizeWindow(Grid appBar)
        {
            PackIcon windowRestoreIcon = (PackIcon) FindName("WindowRestoreIcon");
            windowRestoreIcon.Kind = PackIconKind.WindowMaximize;
            GetParentWindow().WindowState = WindowState.Normal;
            appBar.Margin = new Thickness(0, 0, 0, 0);
        }

        /**
         * Stores the current window size and position in the previous window state variables
         */
        private void RecordCurrentWindowSizeAndPosition()
        {
            _previousWindowHeight = GetParentWindow().Height;
            _previousWindowWidth = GetParentWindow().Width;
            _previousWindowTop = GetParentWindow().Top;
            _previousWindowLeft = GetParentWindow().Left;
        }

        /**
         * <returns>A Tuple of doubles of the previous window size and window position
         * in the format:(Window Height, Window Width, Window Top position, Window Left Position</returns>
         */
        private (double, double, double, double) GetPreviousWindowSizeAndPosition()
        {
            return (
                _previousWindowHeight,
                _previousWindowWidth,
                _previousWindowTop,
                _previousWindowLeft
            );
        }

        private Window GetParentWindow()
        {
            return Window.GetWindow(this);
        }
    }
}
