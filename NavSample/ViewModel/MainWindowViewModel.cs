using System;
using System.Collections.Generic;
using System.Text;

namespace NavSample.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => currentViewModel; 
            set {
                currentViewModel = value;
                OnPropertyChanged();
             }
        }

        public MainWindowViewModel(BaseViewModel currentViewModel)
        {
            CurrentViewModel = currentViewModel;
        }
    }
}
