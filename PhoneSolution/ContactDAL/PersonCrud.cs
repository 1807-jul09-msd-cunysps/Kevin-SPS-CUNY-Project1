using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneAppLibrary;
using System.Data.SqlClient;


namespace ContactDAL
{
    public class PersonCrud
    {

        public List<Person> GetPersons()
        {
            List<Person> Contacts = new List<Person>();
            string connectionString = "Data Source=kevin-adventureworks.database.windows.net;Initial Catalog=PhoneApp;User ID=kevin;Password=revature2018!";
            string queryString = "Select * from Persons";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;



                while (reader.Read())
                {
                    List<string> personString = new List<string>();
                    for (int i = 0; i < count; i++)
                    {
                        personString.Add(Convert.ToString(reader.GetValue(i)));


                    }

                    Person p = new Person(personString);

                    Contacts.Add(p);
                }

                connection.Close();
            }
            return Contacts;
        }
    }


}
