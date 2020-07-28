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
            if (e.ClickCount == 2)
            {
                if (Width < System.Windows.SystemParameters.WorkArea.Width ||
                   GetParentWindow().Height < System.Windows.SystemParameters.WorkArea.Height)
                {
                    _previousWindowHeight =GetParentWindow().Height;
                   GetParentWindow().Height = System.Windows.SystemParameters.WorkArea.Height;
                    _previousWindowWidth =GetParentWindow().Width;
                   GetParentWindow().Width = System.Windows.SystemParameters.WorkArea.Width;

                    _previousWindowTop = GetParentWindow().Top;
                    GetParentWindow().Top = 0;
                    _previousWindowLeft = GetParentWindow().Left;
                   GetParentWindow().Left = 0;
                }
                else
                {
                    double tempHeight =GetParentWindow().Height;
                    double tempWidth =GetParentWindow().Width;
                    double tempTop =GetParentWindow().Top;
                    double tempLeft =GetParentWindow().Left;

                   GetParentWindow().Height = _previousWindowHeight;
                   GetParentWindow().Width = _previousWindowWidth;
                   GetParentWindow().Top = _previousWindowTop;
                   GetParentWindow().Left = _previousWindowLeft;

                    _previousWindowHeight = tempHeight;
                    _previousWindowWidth = tempWidth;
                    _previousWindowTop = tempTop;
                    _previousWindowLeft = tempLeft;
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

        private Window GetParentWindow()
        {
            return Window.GetWindow(this);
        }
    }
}
