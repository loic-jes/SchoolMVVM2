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
    /// Logique d'interaction pour TeacherView.xaml
    /// </summary>
    public partial class TeacherView : UserControl
    {
        public TeacherView()
        {
            InitializeComponent();
            teacherViewModel = new ViewModel.TeacherViewModel();
            this.DataContext = teacherViewModel;
        }

        public ViewModel.TeacherViewModel teacherViewModel;
    }
}
