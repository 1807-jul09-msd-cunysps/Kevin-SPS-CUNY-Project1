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
        public static string connectionString = "Data Source=kevin-adventureworks.database.windows.net;Initial Catalog=PhoneApp;User ID=kevin;Password=revature2018!";

        public List<Person> GetPersons()
        {
            List<Person> Contacts = new List<Person>();
            string queryString = "FirstName, LastName, Gender, DateOfBirth, Address1, City, State, ZipCode, Country,  CountryCode, AreaCode, PhoneNumber From persons left join Address on Pid = PersonID left join Phones on Pid = Phones.PersonID";
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
        public void InsertPerson(Person person)
        {
            string queryInsertString = "";
            queryInsertString+=($"insert into Persons values ('{person.FirstName}', '{person.LastName}', '{person.Gender}', '{person.DoB}');");
            queryInsertString+=($"insert into Address values((select Max(Persons.Pid) from Persons), '{person.myAddress.StreetName}', '{person.myAddress.HouseNum}', '{person.myAddress.City}', '{person.myAddress.State}', '{person.myAddress.Zipcode}', '{person.myAddress.Country}'); ");
            queryInsertString+=($"insert into Phones values((select Max(Persons.Pid) from Persons), '{person.myPhone.CountryCode}', '{person.myPhone.AreaCode}', '{person.myPhone.Number}'); ");
            useConnection(queryInsertString);
            //string queryString = 
        }
         
        public static void useConnection(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }


}
