using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace PhoneAppLibrary
{
    public class UI {
        //class members
        #region
        static List<string> sl= new List<string>();
        List<Person> Contacts { get; set; }

        string connectionString = "Data Source=kevin-adventureworks.database.windows.net;Initial Catalog=PhoneApp;User ID=kevin;Password=revature2018!";
        string queryString = "select Pid, FirstName, LastName, Gender, DateOfBirth, Address.id, StreetName, HouseNumber, City, State, ZipCode, Country, Phones.id, CountryCode, AreaCode, PhoneNumber From persons inner join Address on Pid = PersonID inner join Phones on Pid = Phones.PersonID";
        #endregion

        //constructor//UIDisplay()
        #region 
        public UI()
        {
            Contacts = new List<Person>();
            sl.Add("Welcome to PhoneApp");
            sl.Add("Please enter the key corresponding to desired action: ");
            sl.Add("1. Read Contacts");
            sl.Add("2. Add Contact");
            sl.Add("3. Delete Contact");
            sl.Add("4. Edit Contact");
            sl.Add("5. Search Contacts");
        }
        #endregion

        //helper methods
        public void Print()
        {
            sl.ForEach(s => Console.WriteLine(s));
        }
        public int UIRead()
        {
            int number;
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out number))
            {
                Console.WriteLine("Please enter an integer");
                UIRead();
            }
            else
            {
                return number;
            }
            return 0;
        }
        #region

        //Switch Methods
        public void UISwitch(int input)
        {
            switch (input)
            {
                case 1:
                    ReadContacts();
                    break;
                case 2:
                    //Person p = new Person(Person.GetPersonInfo());
                    //AddContact();
                    break;
                case 3:
                    //DeleteContact();
                    break;

                case 4:
                    //EditContact();
                    break;
                case 5:
                    //SearchContact()
                    break;
                default:
                    //Switchboard()
                    break;

            }
        }
        //Reads Persons from SQL server and sets the Contacts as a new List of Persons
        public void ReadContacts()
        {
            //deletes content from Contacts

            this.Contacts.Clear();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;


                while (reader.Read())
                {
                    List<string> personString = new List<string>();
                    for(int i = 0; i < count; i++)
                    {
                        personString.Add(Convert.ToString(reader.GetValue(i)));
                    }
                    Person p = new Person(personString);
                    Contacts.Add(p);
                }
               
                connection.Close();
            }
            Contacts.ForEach(delegate (Person p) { p.Print(); });

            Console.Read();
        }
   
       
      


        //public void ViewContacts(ref List<Person> listPersons)
        //{
        //        listPersons.ForEach(delegate (Person p) {
        //        Console.WriteLine(p.Pid);
        //        }

        //}
        //Passes in a Person object and adds it to the Collection of Persons

        public void AddContact(Person person, ref List<Person> listPersons)
        {
            listPersons.Add(person);
            Console.WriteLine($"New Contact {person.FirstName} has been added to Contacts.");
        }
        public void DeleteContact(Person person, ref List<Person> listPersons)
        {
            listPersons.Remove(person);
            Console.WriteLine($"New Contact {person.FirstName} has been removed Contacts.");
        }
        public void EditContact(Person person, ref List<Person> listPersons)
        {
            Console.WriteLine("Which contact do you wish to edit?");

            //Prints all contacts to the Console
            Console.WriteLine(listPersons);
            listPersons.ForEach(i => Console.Write("{0}\r\n", i));

            //Get contact to edit
            int input = Convert.ToInt32(Console.Read());


        }
        public Person SearchContact(List<Person> Directory)
        {
            Console.WriteLine("Enter first name of person");
            string fName = Console.ReadLine();
            //search collections

            foreach (Person p in Directory)
            {
                if (p.FirstName.Equals(fName))
                {
                    return p;
                }
            }
            return null;
        }

    }
    #endregion
}
