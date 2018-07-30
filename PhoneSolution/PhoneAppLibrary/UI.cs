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
        static List<string> sl = new List<string>();
        List<Person> Contacts { get; set; }
        bool isOpen = true;

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
            sl.Add("6. Exit");
        }
        #endregion

        //helper methods
        #region
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
        public bool IsOpen()
        {
            return isOpen;
        }
        public void PrintIDNamePhoneNum()
        {
            Contacts.ForEach(c => Console.WriteLine(Convert.ToString(c.Pid) + ', ' + c.FirstName + ', ' + c.myPhone.AreaCode + c.myPhone.Number));
        }
        #endregion

        //Switch Methods
        #region
        public void UISwitch(int input)
        {
            switch (input)
            {

                case 1:
                    ReadContacts();
                    break;
                case 2:
                    AddContact();
                    break;
                case 3:
                    DeleteContact();
                    break;

                case 4:
                    //EditContact();
                    break;
                case 5:
                    //SearchContact()
                    break;
                case 6:
                    isOpen = false;
                    break;
                default:
                    //Switchboard()
                    Console.WriteLine("Invalid integer, please enter desired action using corresponding integer");
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
                    for (int i = 0; i < count; i++)
                    {
                        personString.Add(Convert.ToString(reader.GetValue(i)));
                    }
                    Person p = new Person(personString);
                    Contacts.Add(p);
                }

                connection.Close();
            }
            Console.WriteLine($"Number of contacts loaded: {Contacts.Count()}");

            Console.Read();
        }


        //public void ViewContacts(ref List<Person> listPersons)
        //{
        //        listPersons.ForEach(delegate (Person p) {
        //        Console.WriteLine(p.Pid);
        //        }

        //}
        //Passes in a Person object and adds it to the Collection of Persons

        public void AddContact()
        {
            List<int> uniqueIDList = new List<int>();
            for (int i = 0; i < Contacts.Count(); i++)
            {
                uniqueIDList.Add(Convert.ToInt32(Contacts[i].Pid));
            }
            //In addition to getting Person information from user, it assigns the integer larger than the largest 
            //Pid to the newly created Person. If a person gets deleted, the Count of Contacts will change but the id should not
            //be repeated
            Person person = new Person(Person.GetPersonInfo(), uniqueIDList.Max() + 1);
            Contacts.Add(person);

            //Adds the person to the database

            List<string> queryInsertString = new List<string>();
            queryInsertString.Add($"insert into Persons values ('{person.FirstName}', '{person.LastName}', '{person.Gender}', '{person.DoB}');");
            queryInsertString.Add($"insert into Address values((select Max(Persons.Pid) from Persons)+1, '{person.myAddress.StreetName}', '{person.myAddress.HouseNum}', '{person.myAddress.City}', '{person.myAddress.State}', '{person.myAddress.Zipcode}', '{person.myAddress.Country}'); ");
            queryInsertString.Add($"insert into Phones values((select Max(Persons.Pid) from Persons)+1, '{person.myPhone.CountryCode}', '{person.myPhone.AreaCode}', '{person.myPhone.Number}'); ");


            //Adds the person to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                for (int i = 0; i < queryInsertString.Count(); i++)
                {
                    SqlCommand command = new SqlCommand(queryInsertString[i], connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            Console.WriteLine($"New Contact {person.FirstName} has been added to Contacts.");
        }
        public void DeleteContact()
        {

            Console.WriteLine("Please enter the id of the person you wish to delete");
            PrintIDNamePhoneNum();
            int input = Console.Read();
            Contacts.RemoveAll(p => p.Pid == input);
            string queryString = $"Delete from Persons where Pid={Convert.ToString(input)};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        
                Console.WriteLine("Contact Removed");
        }
        


        public void EditContact()
        {

            
            PrintIDNamePhoneNum();
            Console.WriteLine("Please enter the first name of the person you wish to delete");
            string inputFirstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the person you wish to delete");
            string inputLastName = Console.ReadLine();

            Console.WriteLine("Do you wish to change the Address? (Y/N)");
            string inputChar =(Console.ReadLine());
            inputChar = inputChar.ToUpper();
            
            //Get Address
            if (inputChar == "Y")
            {
                
                List<string> addressListStr = Person.GetAddressListStr();

                (from p in Contacts 
                 where p.FirstName == inputFirstName && p.LastName == inputLastName
                 select p.myAddress)
            }
            else if (inputChar == "N"){
                Console.WriteLine("Do you wish to change the Phone Number? (Y/N)");
            }
           


            //Prints all contacts to the Console
            Console.WriteLine(listPersons);
            Contacts.ForEach(i => Console.Write("{0}\r\n", i));

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
