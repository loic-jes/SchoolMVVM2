using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SchoolMVVM2.Repository
{
    public class SubjectRepository : BaseRepository<Model.BaseModel>
    {
        public static Model.Subject GetOne(int id)
        {
            Model.Subject model = null;
            if (Connect())
            {
                string sql = "SELECT * FROM subject WHERE id=@id";
                SqlParameter idParam = new SqlParameter("@id", id);
                DataTable dataTable = ExecuteQuery(sql, idParam);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    model = new Model.Subject();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.Name = dataRow["name"].ToString();

                }
            }
            Close();
            return model;
        }

        public static List<Model.Subject> GetAll(Predicate<Model.Subject> filter = null)
        {
            List<Model.Subject> list = new List<Model.Subject>();
            if (Connect())
            {
                string sql = "SELECT * FROM subject";
                DataTable dataTable = ExecuteQuery(sql);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Model.Subject model = new Model.Subject();
                    model.Id = int.Parse(dataRow["id"].ToString());
                    model.Name = dataRow["name"].ToString();
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

        public static List<Model.Subject> GetSectionSubjectList(int idSection)
        {
            List<Model.Subject> subjectList = new List<Model.Subject>();
            if (Connect())
            {
                string sql = $"SELECT subject.* FROM subject, section_subject" +
                $" WHERE subject.id=section_subject.id_subject" +
                $" AND section_subject.id_section=@id";
                SqlParameter idParam = new SqlParameter("@id", idSection);
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

    }
}
