using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolMVVM2.View
{
    /// <summary>
    /// Logique d'interaction pour StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {

        public StudentView()
        {
            InitializeComponent();
            studentViewModel = new ViewModel.StudentViewModel();
            this.DataContext = studentViewModel;
        }

        public ViewModel.StudentViewModel studentViewModel;

        private void ListViewStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("A marche !");
        }
    }
}
