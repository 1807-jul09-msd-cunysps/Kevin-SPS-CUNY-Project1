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

        public List<Person> Contacts { get; set; }
        #region UIDisplay()
        public void UIDisplay()
        {

            string readonly s1 = "1. Read Contacts";
            string readonly s2 = "2. Add Contact";
            string readonly s3 = "3. Delete Contact";
            string readonly s4 = "4. Edit Contact";
            string readonly s5 = "5. Search Contacts";
            private static readonly string[] _ui = { s1, s2, s3, s4, s5 };
            foreach (var s in _ui){ 
                Console.WriteLine(s);
            }
    #endregion
        int UIRead(){
        }

}

        public void UISwitch(int input)
        {
            switch (input)
            {
                default:
                //Switchboard()
                case 0:
                    break;
                case 1:
                    ReadContacts();
                case 2:
                //AddContact()
                case 3:
                //DeleteContact()
                case 4:
                //EditContact()
                case 5:
                //SearchContact()
               

            }
        }

        public void ReadContacts()
        {
            //Initialize Property of Collection of Persons
           private List<Person> pList;

            public List<Person> PList { get => pList; set => pList = value; }

            //IO stream to obtain JSON

            //Deserialize JSON

            /*string filepath = "C:\Users\Kevin\Source\Repos\Kevin-SPS-CUNY-Project0.contacts.json";
                FileStream stream1 = new FileStream(filepath, FileMode.Open; FileAccess.Read);
            */
            //Set contacts to the newly read contact list
            
                contacts = PList;      
         }
        //Passes in a Person object and adds it to the Collection of Persons
        public static void AddContact(Person person, ref List<Person> listPersons)
        {
            
            listPersons.Add(person);
            Console.WriteLine($'New Contact \' '+ person.FirstName + ' has beend added to Contacts.');
        }

        public static string DeleteContact()
        {

        }
        public static string EditContact()
        {

        }
        public static string SearchContact()
        {
            var persons = p.Get();
            //LINQ-Language Integrate Query
            //Query Syntax
            /*var query = from p1 in persons
                        where p1.firstName.StartsWith("T")
                        select p1;*/
            var query = from p1 in persons
                        where p1.address.houseNum.Equals("121")
                        select p1;

        }

        public static Person AddPerson()
        {
            Person p = new Person;
            Console.WriteLine("Please enter " + string s);
            Console.ReadLine(string input);

            return  p;
    }

}


