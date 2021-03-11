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

        public Helpers.RelayCommand NativateToOneCmd { get; set; }
        public Helpers.RelayCommand NativateToTwoCmd { get; set; }
        public Helpers.RelayCommand NativateToThreeCmd { get; set; }

        public MainWindowViewModel(BaseViewModel currentViewModel)
        {
            NativateToOneCmd = new Helpers.RelayCommand(DoNavigateToOne);
            NativateToTwoCmd = new Helpers.RelayCommand(DoNavigateToTwo);
            NativateToThreeCmd = new Helpers.RelayCommand(DoNavigateToThree);
            CurrentViewModel = currentViewModel;

        }

        private void DoNavigateToThree(object obj)
        {
            CurrentViewModel = new ViewThreeViewModel();
        }

        private void DoNavigateToTwo(object obj)
        {
            CurrentViewModel = new ViewTwoViewModel();
        }

        private void DoNavigateToOne(object obj)
        {
            CurrentViewModel = new ViewOneViewModel();
        }
    }
}
