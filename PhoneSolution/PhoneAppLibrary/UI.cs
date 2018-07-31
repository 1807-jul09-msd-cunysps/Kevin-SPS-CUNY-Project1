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
        string queryString = "select Pid, FirstName, LastName, Gender, DateOfBirth, StreetName, HouseNumber, City, State, ZipCode, Country,  CountryCode, AreaCode, PhoneNumber From persons left join Address on Pid = PersonID left join Phones on Pid = Phones.PersonID";
        #endregion

        //constructor//UIDisplay()
        #region 
        public UI()
        {
            Contacts = new List<Person>();
            sl.Add("Please enter the key corresponding to desired action: \n");
            sl.Add("\t1. Read Contacts");
            sl.Add("\t2. Add Contact");
            sl.Add("\t3. Delete Contact");
            sl.Add("\t4. Edit Contact");
            sl.Add("\t5. Search Contacts");
            sl.Add("\t6. Exit");
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
            
            int input = Convert.ToInt32(Console.ReadLine());
            try
            {
                return input;
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception");
                return 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return 0;
            }

        }
        public bool IsOpen()
        {
            return isOpen;
        }
        public void PrintIDNamePhoneNum()
        {
            Contacts.ForEach(c => Console.WriteLine(Convert.ToString(c.Pid) + ", " + c.FirstName + ", " + c.myPhone.AreaCode + c.myPhone.Number));
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
                    Contacts.ForEach(p => p.Print());
                    break;
                case 2:
                    AddContact();
                    break;
                case 3:
                    DeleteContact();
                    break;

                case 4:
                    EditContact();
                    break;
                case 5:
                    SearchContactById(Contacts).Print();
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
          
            //In addition to getting Person information from user, it assigns the integer larger than the largest 
            //Pid to the newly created Person. If a person gets deleted, the Count of Contacts will change but the id should not
            //be repeated


            Person person = new Person(Person.PopulatePersonListString());
            Contacts.Add(person);

            //Adds the person to the database

            List<string> queryInsertString = new List<string>();
            queryInsertString.Add($"insert into Persons values ('{person.FirstName}', '{person.LastName}', '{person.Gender}', '{person.DoB}');");
            queryInsertString.Add($"insert into Address values((select Max(Persons.Pid) from Persons), '{person.myAddress.StreetName}', '{person.myAddress.HouseNum}', '{person.myAddress.City}', '{person.myAddress.State}', '{person.myAddress.Zipcode}', '{person.myAddress.Country}'); ");
            queryInsertString.Add($"insert into Phones values((select Max(Persons.Pid) from Persons), '{person.myPhone.CountryCode}', '{person.myPhone.AreaCode}', '{person.myPhone.Number}'); ");

            queryInsertString.ForEach(s => Console.WriteLine(s));
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
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Input value: {input}\tInput type: {input.GetType()}");
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
            #region
            UI.ListPrint(Contacts);
        //    bool isPersonNotFound = true;
        //    string inputLName;
        //    string inputFName;
        //    //Confirm input name exists in the Contacts
        //    while (isPersonNotFound) { 
        //        PrintIDNamePhoneNum();
        //        Console.WriteLine("Please enter the first name of the person you wish to edit");
        //        string inputFirstName = Console.ReadLine();
        //        Console.WriteLine("Please enter the last name of the person you wish to edit");
        //        string inputLastName = Console.ReadLine();
        //        foreach (Person person in Contacts)
        //        {
        //            if (inputFirstName == person.FirstName && inputLastName == person.LastName)
        //            {
        //                isPersonNotFound = false;

        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Please enter a name in the Contacts list");
        //            }

        //        }
        //    }
        #endregion
            Console.WriteLine("Do you wish to change the Address? (Y/N)");
            string inputChar =(Console.ReadLine()).ToUpper();
            //Get Address
            if (inputChar == "Y")
            {
                Console.WriteLine("Please enter the new Address");
                List<string> addressListStr = Person.GetAddressListStr();
                Person.Address newAddress = new Person.Address();
                SearchContactById(Contacts).myAddress = new Person.Address(addressListStr);
            }
            
            Console.WriteLine("Do you wish to change the Phone Number? (Y/N)");
            inputChar = Console.ReadLine().ToUpper();
            //Get Phone
            if (inputChar == "Y")
            {
                Console.WriteLine("Please enter the Country Code");
                string cCode = Console.ReadLine();
                Console.WriteLine("Please enter the Area Code");
                string aCode = Console.ReadLine();
                Console.WriteLine("Please enter the Phone Number");
                string pNumber = Console.ReadLine();
                Person p = SearchContactById(Contacts);
                p.myPhone = new Person.Phone(p.Pid, cCode, aCode, pNumber);

            }
           


            //Prints all contacts to the Console
            Contacts.ForEach(i => Console.Write("{0}\r\n", i));

            //Get contact to edit
            int input = Convert.ToInt32(Console.Read());



        }
        public Person SearchContactById(List<Person> Directory)
        {
            Contacts.ForEach(p => p.Print());
               Console.WriteLine("Enter Pid of person");

            int Pid=0;

            try
            {
                Pid = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //search collections

            foreach (Person p in Directory)
            {
                if (p.Pid.Equals(Pid))
                {
                    return p;
                }
            }
            return null;
        }
        public static void ListPrint(List<Person> lp) { lp.ForEach(person=>person.Print()); }
    }
   
    #endregion
}
