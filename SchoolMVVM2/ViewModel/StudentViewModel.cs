using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        private  List<Model.Student> studentList;

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

        private Model.Student currentStudent;

        public Model.Student CurrentStudent
        {
            get
            {
                return currentStudent;
            }
            set
            {
                currentStudent = value;
                OnPropertyChanged();
            }
        }

        public StudentViewModel()
        {
            studentList = Repository.StudentRepository.GetAll();
            studentList = studentList.OrderBy(x => x.Id_section).ThenBy(x => x.LastName).ToList();
            CurrentStudent = studentList.First();

        }

        internal void SetStudentList(Model.Section selectedItem)
        {
            StudentList = Repository.StudentRepository.GetAll(x => x.Id_section == selectedItem.Id);
        }


    }
}
