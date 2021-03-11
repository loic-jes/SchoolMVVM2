using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.ViewModel
{
    public class TeacherViewModel : BaseViewModel
    {
        private Dictionary<Model.Subject, Model.Teacher> teacherList;

        public Dictionary<Model.Subject, Model.Teacher> TeacherList
        {
            get
            {
                return teacherList;
            }
            set
            {
                teacherList = value;
                OnPropertyChanged();
            }
        }

        public TeacherViewModel()
        {
            teacherList = Repository.LinkRepository.GetTeacherWithSubjectBySection(1);
        }


        internal void SetTeacherList(Model.Section selectedItem)
        {
            TeacherList = Repository.LinkRepository.GetTeacherWithSubjectBySection(selectedItem.Id);
        }
    }
}
