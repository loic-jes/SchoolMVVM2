using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new ViewModel.MainWindowViewModel(new ViewModel.ViewOneViewModel());
            mainGrid.DataContext = mainWindowViewModel;
        }

        ViewModel.MainWindowViewModel mainWindowViewModel;

        private void GotoButton_Click(object sender, RoutedEventArgs e)
        {
            //string buttonName = ((Button)sender).Name;
            //if(buttonName == "GotoViewOne")
            //{
            //    mainWindowViewModel.CurrentViewModel = new ViewModel.ViewOneViewModel();
            //}
            //if (buttonName == "GotoViewTwo")
            //{
            //    mainWindowViewModel.CurrentViewModel = new ViewModel.ViewTwoViewModel();
            //}
            //if (buttonName == "GotoViewThree")
            //{
            //    mainWindowViewModel.CurrentViewModel = new ViewModel.ViewThreeViewModel();
            //}
        }
    }
}
