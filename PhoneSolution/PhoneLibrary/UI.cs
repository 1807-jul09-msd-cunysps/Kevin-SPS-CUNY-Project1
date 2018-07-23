using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace PhoneLibrary
{
    public interface IUserInterface
    {
        void UIDisplay();
        int UIRead();
        void UISwitch(int input);

    }

    public class UI : IUserInterface(){
        //constructor//UIDisplay()
        #region 
        static List<string> sl;
        public UI()
        {
            sl.Add("Welcome to PhoneApp");
            sl.Add(""Please enter the key corresponding to desired action: "");
            sl.Add("1. Read Contacts");
            sl.Add("2. Add Contact");
            sl.Add("3. Delete Contact");
            sl.Add("4. Edit Contact");
            sl.Add("5. Search Contacts");
        }
        public void PrintS()
        {
            foreach(string s in sl)
            {
                Console.WriteLine(s);
            }
        }
          
        
    #endregion
        public List<Person> Contacts { get; set; }
        
        #region 

        public void UIDisplay() {
            foreach (var s in this._s) {
                Console.WriteLine(s);

            }
            #endregion
            int UIRead()
            {
                int number;
                string input = Console.ReadLine();
                if (!Int32.TryParse(input, out number))
                {
                    Console.WriteLine('Please enter an integer');
                    UIRead();
                }
                else
                {
                    return number;
                }
                return 0;
            }
            void UISwitch(int input)
            {
                switch (input)
                {

                    case 0:
                        break;
                    case 1:
                        ReadContacts();
                        break;
                    case 2:
                        Person p = new Person(Person.GetPersonInfo());
                        AddContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;

                    case 4:
                        EditContact();
                        break;
                    case 5:
                        //SearchContact()
                        break;
                    default:
                        //Switchboard()
                        break;

                }
            }
            #region
            public void ReadContacts()
            {
            //Initialize Property of Collection of Persons
           private List<Person> pList;

        //IO stream to obtain JSON

        //Deserialize JSON

        /*string filepath = "C:\Users\Kevin\Source\Repos\Kevin-SPS-CUNY-Project0.contacts.json";
            FileStream stream1 = new FileStream(filepath, FileMode.Open; FileAccess.Read);
        */
        //Set contacts to the newly read contact list

        contacts = PList;      
         
    #endregion

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

        }
        public Person SearchContact(in List<Person> Directory)
        {
            Console.WriteLine('Enter first name of person');
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
    
}

