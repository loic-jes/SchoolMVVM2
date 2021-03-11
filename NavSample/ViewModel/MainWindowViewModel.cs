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

        public Helpers.RelayCommand NavigateToOneCmd { get; set; }
        public Helpers.RelayCommand NavigateToTwoCmd { get; set; }
        public Helpers.RelayCommand NavigateToThreeCmd { get; set; }

        public MainWindowViewModel(BaseViewModel currentViewModel)
        {
            NavigateToOneCmd = new Helpers.RelayCommand(DoNavigateToOne, CanDoNavigateToOne);
            NavigateToTwoCmd = new Helpers.RelayCommand(DoNavigateToTwo, CanDoNavigateToTwo);
            NavigateToThreeCmd = new Helpers.RelayCommand(DoNavigateToThree, CanDoNavigateToThree);
            CurrentViewModel = currentViewModel;

        }





        private bool CanDoNavigateToOne(object arg)
        {
            return CurrentViewModel.GetType() != typeof(ViewOneViewModel);
        }
        private void DoNavigateToOne(object obj)
        {
            CurrentViewModel = new ViewOneViewModel();
        }


        private bool CanDoNavigateToTwo(object arg)
        {
            return CurrentViewModel.GetType() != typeof(ViewTwoViewModel);
        }
        private void DoNavigateToTwo(object obj)
        {
            CurrentViewModel = new ViewTwoViewModel();
        }


        private bool CanDoNavigateToThree(object arg)
        {
            return CurrentViewModel.GetType() != typeof(ViewThreeViewModel);
        }

        private void DoNavigateToThree(object obj)
        {
            CurrentViewModel = new ViewThreeViewModel();
        }




    }
}
