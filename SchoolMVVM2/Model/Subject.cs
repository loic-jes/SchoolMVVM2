using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Model
{
    public class Subject : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Section> SubjectSectionList
        {
            get
            {
                return Repository.SectionRepository.GetSubjectSectionList(Id);
            }
            /*set
            {

            }*/
        }

        public List<Teacher> TeacherList
        {
            get
            {
                return Repository.TeacherRepository.GetSubjectTeacherList(Id);
            }
        }
    }
}
