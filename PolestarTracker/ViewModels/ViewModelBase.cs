using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PolestarTracker.WPF.ViewModels
{
    
    public class ViewModelBase
    {
        public ViewNavigator Navigator { get; set; }

        public ViewModelBase(ViewNavigator navigator)
        {
            Navigator = navigator;
        }
    }
}
