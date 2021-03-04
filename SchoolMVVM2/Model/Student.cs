using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Model
{
    public class Student : BaseModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Id_section { get; set;}
        public Section Section { 
            get { return Repository.SectionRepository.GetOne(Id_section); }
            set { Id_section = value.Id; } 
        }
    }
}
