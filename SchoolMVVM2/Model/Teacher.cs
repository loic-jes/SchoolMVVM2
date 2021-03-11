using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Model
{
    public class Teacher : BaseModel
    {
        public int Id { get; set; }
        public string LastName{ get; set; }
        public string FirstName { get; set; }

        public List<Subject> SubjectList
        {
            get
            {
                return Repository.TeacherRepository.GetTeacherSubjectList(Id);
            }
            /*set
            {

            }*/
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


    }
}
