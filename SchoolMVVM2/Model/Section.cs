using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Model
{
    public class Section : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SectionLevel Level { get; set; }

        public List<Student> studentList
        {
            get
            {
                return Repository.StudentRepository.GetAll(o => o.Section.Id == Id);

            }
            //set
            //{

            //}
        }

        public List<Subject> SubjectList
        {
            get
            {
                return Repository.SubjectRepository.GetSectionSubjectList(Id);
            }
            /*set
            {

            }*/
        }

        public Dictionary<Subject, Teacher> SubjectTeacherList
        {
            get
            {
                return Repository.LinkRepository.GetTeacherWithSubjectBySection(Id);
            }
        }



    }

    public enum SectionLevel
    {
        Null = 0, Troisieme = 3, Quatrieme = 4, Cinquieme = 5, Sixieme = 6
    }
}
