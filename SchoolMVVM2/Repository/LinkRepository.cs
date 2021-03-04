using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Repository
{
    public class LinkRepository : BaseRepository<Model.Link>
    {

        public static Dictionary<Model.Subject, Model.Teacher> GetTeacherWithSubjectBySection(int idSection)
        {

            Dictionary<Model.Subject, Model.Teacher> dictionnary = new Dictionary<Model.Subject, Model.Teacher>();

            if (Connect())
            {
                string sql = "SELECT teacher.*, subject.* FROM teacher, link, subject WHERE teacher.id = link.id_teacher ANd link.id_subject = subject.id AND link.id_section = @id";
                SqlParameter idParam = new SqlParameter("@id", idSection);
                DataTable dataTable = ExecuteQuery(sql, idParam);
                foreach (DataRow dataRow in dataTable.Rows)
                {

                    //dictionnary.Add(dataRow.ItemArray[4], dataRow.ItemArray[1] + " " + dataRow.ItemArray[2]);

                    Model.Subject subject = new Model.Subject();
                    subject.Id = (int)dataRow.ItemArray[3];
                    subject.Name = (string)dataRow.ItemArray[4];


                    Model.Teacher teacher = new Model.Teacher();
                    teacher.Id = (int)dataRow.ItemArray[0];
                    teacher.FirstName = (string)dataRow.ItemArray[1];
                    teacher.LastName = (string)dataRow.ItemArray[2];


                    dictionnary.Add(subject, teacher);


                }
            }

            Close();
            return dictionnary;

        }

    }
}
