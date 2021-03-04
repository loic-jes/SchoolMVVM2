using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Model
{
    public class Link : BaseModel
    {
        public Section Section { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }


        //SELECT teacher.firstname, teacher.lastname, subject.name FROM teacher, link, section, teacher_subject, subject WHERE link.id_section = section.id and link.id_teacher = teacher.id and teacher_subject.id_teacher = teacher.id and teacher_subject.id_subject = subject.id  and link.id_subject = teacher_subject.id_subject and section.id = 1

        //SELECT teacher.*, subject.* FROM teacher, link, subject WHERE teacher.id = link.id_teacher ANd link.id_subject = subject.id AND link.id_section = 1

    }
}
