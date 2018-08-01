using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PhoneAppLibrary
{
    public class UI {

        public NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();//for logging exceptions
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
            sl.Add("\t6. Export Json file");
            sl.Add("\t7. Exit");
        }
        #endregion

        //helper methods
        #region
        public void Print()
        {
            sl.ForEach(s => Console.WriteLine(s));
        }
        public Person SearchContactById(int id)
        {
            foreach (Person p in Contacts)
            {
                if (p.Pid == id) { return p; }
            }
            return null;

        }

        public int UIRead()
        {
            bool isNotInt = true;
            while (isNotInt) { 
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    isNotInt = false;
                    return input;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid integer");
                    
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("OverflowException");
                    //logger.LogException(ex, "OverflowException occurred at UIRead()");
 
                }
            }
            return 7;
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

        public void useConnection(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        //Switch Methods
        #region
        public void UISwitch(int input)
        {
            switch (input)
            {

                case 1:
                    ReadContacts();

                    ListPrint(Contacts);
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
                    Console.WriteLine("Please enter the first name of the Person to be searched: \n");
                    string fName = Console.ReadLine();
                    List<Person> results = SearchByFirstName(fName);
                    foreach(Person p in results) { p.Print(); }
                    break;
                case 6:
                    getJSON();
                    Console.WriteLine("Json file written");
                    break;
                case 7:
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

        public void AddContact()
        {
          
            //In addition to getting Person information from user, it assigns the integer larger than the largest 
            //Pid to the newly created Person. If a person gets deleted, the Count of Contacts will change but the id should not
            //be repeated


            Person person = new Person(Person.GetPersonInfo());
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
            Console.WriteLine();
            Contacts.RemoveAll(p => p.Pid == input);
            string queryString = $"Delete from Persons where Pid={input};";
            useConnection(queryString);
             Console.WriteLine("Contact Removed");
        }
        
        public void EditContact()
        {
            //prints contacts and asks for integer id input
            #region
            UI.ListPrint(Contacts);
            bool isPersonNotFound = true;
            int input=0;

            //verify input is valid Pid within Contacts
            while (isPersonNotFound){
                Console.WriteLine("Please enter the id of the person to be updated");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    foreach (Person p in Contacts)
                    {
                        if (p.Pid == input)
                        {
                            isPersonNotFound = false; break;
                        }

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid id integer");
                }
                catch(OverflowException)
                {
                    break;
                }
            }

        #endregion
            Console.WriteLine("Do you wish to change the Address? (Y/N)");
            string inputChar =(Console.ReadLine()).ToUpper();
            //Get Address
            
            if (inputChar == "Y")
            {
                
                Console.WriteLine("Please enter the new Address");
                List<string> addressListStr = Person.GetAddressListStr();
                addressListStr.Insert(0, Convert.ToString(input));
                foreach (string s in addressListStr) { Console.WriteLine(s); };
                Person.Address newAddress = new Person.Address(addressListStr);
               //Set Update Address on local machine
                
                Person p = SearchContactById(input);
                p.myAddress = newAddress;
                //Update on Database
                string queryUpdateString =$"update Address set Streetname = '{p.myAddress.StreetName}', HouseNumber = '{p.myAddress.HouseNum}', City = '{p.myAddress.City}', State = '{p.myAddress.State}', ZipCode='{p.myAddress.Zipcode}', Country = '{p.myAddress.Country}' where PersonId = '{p.Pid}'";

                //queryInsertString.ForEach(s => Console.WriteLine(s));
                //Adds the person to the database
                useConnection(queryUpdateString);
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
                Person p = SearchContactById(input);
                p.myPhone = new Person.Phone(p.Pid, cCode, aCode, pNumber);
                Console.WriteLine("\t\tUpdated Contact");
                p.Print();
                //Update database
                string queryUpdateString = $"update Phones set CountryCode = '{p.myPhone.CountryCode}', AreaCode = '{p.myPhone.AreaCode}', PhoneNumber  = '{p.myPhone.Number}' where PersonId = '{p.Pid}'";
                useConnection(queryUpdateString);

            }

        }
        public List<Person> SearchByFirstName(string fName)
        {
            
            return(from person in Contacts where person.FirstName == fName select person).ToList<Person>() ;
        }

        public static void ListPrint(List<Person> lp) {
            String s = String.Format("\n{0,5} {1,15} {2,15}, {3,5}, {4,10}", "Pid", "First Name", "Last Name", "Gender", "Date of Birth\n");
            Console.WriteLine(s);
            lp.ForEach(person => person.Print());

        }

        public void getJSON()
        {

            string s = JsonConvert.SerializeObject(Contacts);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/Users/Kevin/source/repos/kaur-code/PersonContactApp/ContactLibrary/json.txt")) {
                file.WriteLine(s);
            };
        }

    }
   
    #endregion
}
