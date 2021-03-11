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
    /// Logique d'interaction pour NoteView.xaml
    /// </summary>
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
            InitializeComponent();
            noteViewModel = new ViewModel.NoteViewModel();
            this.DataContext = noteViewModel;

        }

        private ViewModel.NoteViewModel noteViewModel;

        //Dependency Property implementation :
        public static readonly DependencyProperty SetTextProperty =
            DependencyProperty.Register("SetText", typeof(Model.Student), typeof(NoteView),
                new PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        public Model.Student SetText
        {
            get { return (Model.Student)GetValue(SetTextProperty); }
            set { SetValue(SetTextProperty, value); }
        }

        private static void OnSetTextChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            NoteView UserControl1Control = d as NoteView;
            UserControl1Control.OnSetTextChanged(e);
        }

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            NotetextBoxSectionFullName.Text = e.NewValue.ToString();
        }
    }
}
