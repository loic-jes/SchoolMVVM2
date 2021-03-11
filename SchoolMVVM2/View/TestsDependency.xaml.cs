using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour TestsDependency.xaml
    /// </summary>
    public partial class TestsDependency : UserControl
    {
        public TestsDependency()
        {
            InitializeComponent();
            testsDependencyViewModel = new ViewModel.TestsDependencyViewModel();
            mainGridTest.DataContext = testsDependencyViewModel;
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(myListView_OnColumnClick));
        }


        public ViewModel.TestsDependencyViewModel testsDependencyViewModel;

        //Dependency Property implementation :
        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register("SetText", typeof(Model.Section), typeof(TestsDependency),
                new PropertyMetadata(null, new PropertyChangedCallback(OnSetTextChanged)));

        public Model.Section SetText
        {
            get { return (Model.Section)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        private static void OnSetTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            TestsDependency UserControl1Control = d as TestsDependency;
            UserControl1Control.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            //textBoxSectionFullName.Text = ((Model.Section)e.NewValue).ToString();
            testsDependencyViewModel.StudentList = ((Model.Section)e.NewValue).studentList;
        }














        private void Ascending_Click(object sender, RoutedEventArgs e)
        {
            testsDependencyViewModel.StudentList = testsDependencyViewModel.StudentList.OrderBy(x => x.LastName).ToList();

        }   
        private void Descending_Click(object sender, RoutedEventArgs e)
        {
            testsDependencyViewModel.StudentList = testsDependencyViewModel.StudentList.OrderByDescending(x => x.LastName).ToList();

        }

        private static bool ordered = false;

        private void myListView_OnColumnClick(object sender, RoutedEventArgs e)
        {
           if (TestsDependency.ordered)
            {
                testsDependencyViewModel.StudentList = testsDependencyViewModel.StudentList.OrderByDescending(x => x.LastName).ToList();
                TestsDependency.ordered = false;
            }
            else
            {
                testsDependencyViewModel.StudentList = testsDependencyViewModel.StudentList.OrderBy(x => x.LastName).ToList();
                TestsDependency.ordered = true;

            }
        }


    }
}
