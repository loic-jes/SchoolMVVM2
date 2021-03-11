using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.ViewModel
{
    public class TestsDependencyViewModel : BaseViewModel
    {

        private List<Model.Student> studentList;
        public List<Model.Student> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {
                studentList = value;
                OnPropertyChanged();
            }
        }
    }
}
