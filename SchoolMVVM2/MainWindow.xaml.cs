﻿using System;
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

namespace SchoolMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new ViewModel.MainWindowViewModel();
            this.DataContext = mainWindowViewModel;

            //var x = Repository.BaseRepository.Connect();
            //var y = Repository.SectionRepository.GetOne(1);
            //var w = Repository.SubjectRepository.GetOne(8);

            //var z = Repository.SectionRepository.GetAll(o => o.Level == Model.SectionLevel.Sixieme);

            //var a = Repository.StudentRepository.GetOne(1);
            //var b = Repository.StudentRepository.GetAll(o => o.Section.Id == Repository.SectionRepository.GetOne(1).Id);
            //var c = Repository.StudentRepository.GetAll(o => o.LastName == "Coker");

            //var d = Repository.SectionRepository.GetOne(1);
            //var sl = d.studentList;

            //var e = Repository.TeacherRepository.GetOne(1);

            //var f = Repository.LinkRepository.GetTeacherWithSubjectBySection(1);


            //var f = Repository.SectionRepository.ShowMeOne(1);

        }

        private ViewModel.MainWindowViewModel mainWindowViewModel;

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            View.StudentView studentWindow = (View.StudentView)StudentViewControl.Content;
            studentWindow.studentViewModel.SetStudentList((Model.Section)listView.SelectedItem);


            View.TeacherView teacherWindow = (View.TeacherView)TeacherViewControl.Content;
            teacherWindow.teacherViewModel.SetTeacherList((Model.Section)listView.SelectedItem);
            //ViewModel.StudentViewModel.SetStudentList((Model.Section)listView.SelectedItem);
        }
    }
}
