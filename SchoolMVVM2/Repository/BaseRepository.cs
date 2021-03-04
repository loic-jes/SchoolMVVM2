using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Windows;

namespace SchoolMVVM2.Repository
{
    public class BaseRepository<T> where T : Model.BaseModel
    {
        protected  static SqlConnection sqlConnection;

        protected static bool Connect()
        {
            sqlConnection = new SqlConnection(Properties.Settings.Default.connectionString);

            try
            {
                sqlConnection.Open();
            }
            catch
            {
                sqlConnection = null;
                MessageBox.Show("A marche pas");
            }
            return sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open;
        }

        protected  static void Close()
        {
            if (sqlConnection != null && sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                try
                {
                    sqlConnection.Close();
                }
                catch
                {

                }
            }
        }

        protected static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            foreach (object param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }



        public static T ShowMeOne(int id)
        {

            T model = Activator.CreateInstance<T>();
            string table = typeof(T).Name.ToLower();


            if (Connect())
            {
                string sql = $"SELECT * FROM {table} WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    GetModelInstanceFromDatarow(dataRow);

                }
            }

            Close();








            return model;
            
        }


        private static T GetModelInstanceFromDatarow(DataRow dataRow)
        {

            Type type = typeof(T);
            T model = Activator.CreateInstance<T>();

            //var a = type.GetDefaultMembers();
            //var b = type.GetElementType();
            //var c = type.GetFields();
            var d = type.GetProperties();

            List<String> ListType = new List<String>();
            List<String> ListKey = new List<string>();

            foreach (var item in d)
            {
  
                    ListType.Add(item.PropertyType.Name);
                    ListKey.Add(item.Name.ToLower());
                

            }

            var e = dataRow;


            foreach (var item in dataRow.ItemArray)
            {
                //model.ListType[0]
                var x = item;
                var y = dataRow.Table.Columns;


            }

            foreach (var item in dataRow.Table.Columns)
            {
                var z = item;
               
            }










            return model;


        }
    }
}
