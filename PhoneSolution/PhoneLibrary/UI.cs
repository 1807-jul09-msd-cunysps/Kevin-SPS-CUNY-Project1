using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace PhoneLibrary
{
    public static class UI
    {

        static string s1 = "1. Read Contacts";
        static string s2 = "2. Add Contact";
        static string s3 = "3. Delete Contact";
        static string s4 = "4. Edit Contact";
        static string s5 = "5. Search Contacts";
        private static readonly string[] _ui = { s1, s2, s3, s4, s5 };

        public  static void DisplayStringArray()
        {
            foreach (var s in _ui){ 
                Console.WriteLine(s);
            }
        }

        public void Switchboard(int input)
        {
            switch (input)
            {
                case 0:
                    break;
                case 1:
                //ReadContacts()
                case 2:
                //AddContact()
                case 3:
                //DeleteContact()
                case 4:
                //EditContact()
                case 5:
                //SearchContact()
                default:
                    //Switchboard()

            }
        }

        private void ReadContacts()
        {

            private List<Person> p { get; set};
            string filepath = "C:\Users\Kevin\Source\Repos\Kevin-SPS-CUNY-Project0.contacts.json";
            FileStream stream1 = new FileStream(filepath, FileMode.Open; FileAccess.Read);
            


            
        }

        private string AddContact()
        {
            
            Person p = new Person();

        }
        private string DeleteContact()
        {

        }
        private string EditContact()
        {

        }
        private string SearchContact()
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





    }

    public interface Add
    {
        void Add();
        Console.WriteLine("Please enter " + string s);
        Console.ReadLine(string input);
        
    }
