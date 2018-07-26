using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADONet_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //SQL Connection

            string conStr = "Data Source = kevin - adventureworks.database.windows.net; Initial Catalog = AdventureWorksLT; Persist Security Info = True; User ID = kevin; Password = 'revature2018!'";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(conStr);

            using (connection)
            {
                connection.Open();
                #region

                #endregion
                //SQL query
                #region
                string query = "SELECT * FROM SalesLT.ProductCategory; ";
                SqlCommand command = new SqlCommand(query, connection);

                //reader gets results of the query
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(Convert.ToString(reader.GetInt32(0)), Convert.ToString(reader.GetInt32(0)), reader.GetString(32), reader.GetString(32), reader.GetDateTime(32));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                reader.Close();
                #endregion


            }
        }
    }
}
