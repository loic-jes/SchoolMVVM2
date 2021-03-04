using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMVVM2.Repository
{
    public class StudentRepository : BaseRepository<Model.Student>
    {
        public static Model.Student GetOne(int id)
        {

            Model.Student model = null;

            if (Connect())
            {
                string sql = "SELECT * FROM student WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    model = new Model.Student();
                    model.LastName = dataRow["lastname"].ToString();
                    model.FirstName = dataRow["firstname"].ToString();
                    model.Section = (Model.Section)SectionRepository.GetOne(int.Parse(dataRow["id_section"].ToString()));
                }
            }

            Close();
            return model;
        }



        public static List<Model.Student> GetAll(Predicate<Model.Student> filter = null)
        {

            List<Model.Student> list = new List<Model.Student>();

            if (Connect())
            {
                string sql = "SELECT * FROM student";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {

                    Model.Student model =  new Model.Student();
                    model.LastName = dataRow["lastname"].ToString();
                    model.FirstName = dataRow["firstname"].ToString();
                    model.Id_section = int.Parse(dataRow["id_section"].ToString());
                    model.Section = (Model.Section)SectionRepository.GetOne(int.Parse(dataRow["id_section"].ToString()));

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

    }
}
