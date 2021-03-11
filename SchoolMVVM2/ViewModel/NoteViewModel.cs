using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.ViewModel
{
    public class NoteViewModel : BaseViewModel
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

        public NoteViewModel()
        {
            studentList = Repository.StudentRepository.GetAll();
            studentList = studentList.OrderByDescending(x => x.Id_section).ThenBy(x => x.LastName).ToList();
            CurrentStudent = studentList.First();
        }
    }
}
