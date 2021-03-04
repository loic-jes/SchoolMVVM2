using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Repository
{
    public class SectionRepository : BaseRepository<Model.Section>
    {

        public static Model.Section GetOne(int id)
        {

            Model.Section model = null;

            if (Connect())
            {
                string sql = "SELECT * FROM section WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    model = new Model.Section();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.Name = dataRow["name"].ToString();
                    model.Level = (Model.SectionLevel)(int.Parse(dataRow["level"].ToString()));
                }
            }

            Close();
            return model;
        }  
        
        
        public static List<Model.Section> GetAll(Predicate<Model.Section> filter = null)
        {

            List<Model.Section> list = new List<Model.Section>();

            if (Connect())
            {
                string sql = "SELECT * FROM section";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {

                    Model.Section model = new Model.Section();

                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.Name = dataRow["name"].ToString();
                    model.Level = (Model.SectionLevel)(int.Parse(dataRow["level"].ToString()));

                    list.Add(model);
                }
            }

            Close();
            if (filter != null)
            {
                list = list.FindAll(filter);

            }
            return list;
        }


        public static List<Model.Section> GetSubjectSectionList(int idSubject)
        {
            List<Model.Section> subjectList = new List<Model.Section>();
            if (Connect())
            {
                string sql = $"SELECT section.* FROM section, section_subject" +
                $" WHERE section.id=section_subject.id_section" +
                $" AND section_subject.id_subject=@id";
                SqlParameter idParam = new SqlParameter("@id", idSubject);
                DataTable dataTable = ExecuteQuery(sql, idParam);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Model.Section model = new Model.Section();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.Name = dataRow["name"].ToString();
                    model.Level = (Model.SectionLevel)(int.Parse(dataRow["level"].ToString()));
                    subjectList.Add(model);
                }
            }
            return subjectList;
        }


    }
}
