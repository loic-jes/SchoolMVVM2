using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Repository
{
    public class TeacherRepository : BaseRepository<Model.Teacher>
    {
        public static Model.Teacher GetOne(int id)
        {

            Model.Teacher model = null;

            if (Connect())
            {
                string sql = "SELECT * FROM teacher WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    model = new Model.Teacher();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.FirstName = dataRow["firstname"].ToString();
                    model.LastName = dataRow["lastname"].ToString();

                }
            }

            Close();
            return model;
        }




        public static List<Model.Subject> GetTeacherSubjectList(int idTeacher)
        {
            List<Model.Subject> subjectList = new List<Model.Subject>();

            if (Connect())
            {
                string sql = $"SELECT subject.* FROM subject, teacher_subject, teacher WHERE subject.Id=teacher_subject.Id_subject AND teacher_subject.Id_teacher = teacher.Id AND teacher.Id = @id";
                SqlParameter idParam = new SqlParameter("@id", idTeacher);
                DataTable dataTable = ExecuteQuery(sql, idParam);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Model.Subject model = new Model.Subject();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.Name = dataRow["name"].ToString();
                    subjectList.Add(model);
                }
            }

            return subjectList;


        }

        public static List<Model.Teacher> GetSubjectTeacherList (int idSubject)
        {

            List<Model.Teacher> teacherList = new List<Model.Teacher>();

            if (Connect())
            {
                string sql = $"SELECT teacher.* FROM teacher, teacher_subject, subject WHERE subject.Id=teacher_subject.Id_subject AND teacher_subject.Id_teacher = teacher.Id AND subject.Id = @id";
                SqlParameter idParam = new SqlParameter("@id", idSubject);
                DataTable dataTable = ExecuteQuery(sql, idParam);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Model.Teacher model = new Model.Teacher();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.FirstName = dataRow["firstname"].ToString();
                    model.LastName = dataRow["lastname"].ToString();

                    teacherList.Add(model);
                }
            }

            return teacherList;



        }

        // Select subjects and teachers by section
        //SELECT subject.*, teacher.* FROM subject, section_subject, teacher, link WHERE subject.id= section_subject.id_subject AND link.id_section = section_subject.id_section AND link.id_teacher= teacher.id AND link.id_subject = section_subject.id_subject AND section_subject.id_section= 1

    }
}
