using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace PhoneAppLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.Address address = new Person.Address("1400 Pennsylvania Avenue", "Washington D.C.", "DC", "20500", "United States");
            Person.Phone phone = new Person.Phone("1", "900", "9871234");
            Person person = new Person("Barack", "Obama", "M", "12/5/1988 12:00:00 AM", address, phone);

            string connectionString = "Data Source=kevin-adventureworks.database.windows.net;Initial Catalog=PhoneApp;User ID=kevin;Password=revature2018!";
            string queryInsertString = "";
            queryInsertString += ($"insert into Persons values ('{person.FirstName}', '{person.LastName}', '{person.Gender}', '{person.DoB}');");
            queryInsertString += ($"insert into Address values((select Max(Persons.Pid) from Persons), '{person.myAddress.City}', '{person.myAddress.State}', '{person.myAddress.Zipcode}', '{person.myAddress.Country}','{person.myAddress.Address1}'); ");
            queryInsertString += ($"insert into Phones values((select Max(Persons.Pid) from Persons), '{person.myPhone.CountryCode}', '{person.myPhone.AreaCode}', '{person.myPhone.Number}'); ");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryInsertString, connection);
                connection.Open();
                command.ExecuteNonQuery();




                //while (reader.Read())
                //{
                //    List<string> personString = new List<string>();
                //    for (int i = 0; i < count; i++)
                //    {
                //        personString.Add(Convert.ToString(reader.GetValue(i)));

                //    }

                //    Person p = new Person(personString);

                //    Contacts.Add(p);
                //}

                connection.Close();
            }
            //foreach (Person p in Contacts)
            //{
            //    p.Print();
            //}
            Console.ReadLine();
            //Console.SetWindowSize(170, 59);
            ////Display UI on Console
            //UI uI = new UI();
            //uI.ReadContacts();
            //Console.WriteLine("\n\n\t\tWelcome to PhoneApp\n");
            ////Read user input
            //while (uI.IsOpen()) {
            //    uI.Print();
            //    int input = uI.UIRead();
            //    uI.UISwitch(input);
            //}
        }

    }
}
