using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PhoneAppLibrary
{
    [DataContract]
    public class Person
    {
        //Data Members
        static int max_id = 0;
        //Default Constructor
        public Person()
        {
        }

        //Person constructors
        #region
        //Constructor that takes in List of strings that has size of 14 elements
        public Person(List<string> p)
        {

            Pid = Convert.ToInt32(p[0]);
            if (Pid > Person.max_id) {
                Person.max_id = Pid;
            }
            FirstName = p[1];
            LastName = p[2];
            Gender = p[3];
            DoB = Convert.ToString(p[4]);
            myAddress = new Address(Convert.ToInt32(p[0]), p[5], p[6], p[7], p[8], p[9], p[10]);
            myPhone = new Phone(Convert.ToInt32(p[0]), p[11], p[12], p[13]);
        }
        public Person(int pid, string fName, string lName, string gender, string DoB, Address address, Phone phone)
        {
            this.Pid = pid;
            this.FirstName = fName;
            this.LastName = lName;
            this.Gender = gender;
            this.DoB = DoB;
            this.myAddress = address;
            this.myPhone = phone;
        }

        #region
        [DataMember]
        public int Pid { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string DoB { get; set; }
        [DataMember]
        public Address myAddress { get; set; }
        [DataMember]
        public Phone myPhone { get; set; }
        #endregion


        #endregion
        [DataContract]

        public class Address
        {
            public Address()
            {

            }
            #region
            public Address(int pid, string sName, string hNum, string city, string state, string zCode, String Country)
            {
                this.Pid = pid;
                this.StreetName = sName;
                this.HouseNum = hNum;
                this.City = city;
                this.State = state;
                this.Zipcode = zCode;
                this.Country = Country;
            }
            #endregion
            //constructor given List of string
            public Address(List<string> addstr)
            {
                this.Pid = Convert.ToInt16(addstr[0]);
                this.StreetName = addstr[1];
                this.HouseNum = addstr[2];
                this.City = addstr[3];
                this.State = addstr[4];
                this.Zipcode = addstr[5];
                this.Country = addstr[6];
            }

            //Data members
            #region
            [DataMember]
            public int Pid { get; set; }
            [DataMember]
            public string StreetName { get; set; }
            [DataMember]
            public string HouseNum { get; set; }
            [DataMember]
            public string City { get; set; }
            [DataMember]
            public string State { get; set; }
            [DataMember]
            public string Zipcode { get; set; }
            [DataMember]
            public string Country { get; set; }
            #endregion



        }


        [DataContract]
        public class Phone
        {
            public Phone(int pid, string cCode, string aCode, string number)
            {
                this.Pid = pid;
                this.CountryCode = cCode;
                this.AreaCode = aCode;
                this.Number = number;
            }
            [DataMember]
            public long Pid { get; set; }
            [DataMember]
            public string CountryCode { get; set; }
            [DataMember]
            public string AreaCode { get; set; }
            [DataMember]
            public string Number { get; set; }

        }

        //Returns List of String containing Person fields
        //Requires additional implementation
        public static List<string> GetPersonInfo()
        {
            List<string> personString = new List<string>();

            personString.Add(Convert.ToString(Person.max_id));
            Console.WriteLine("Please enter the first name of the person");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the last name of the person");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the Date of Birth");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the gender of the person ('M' or 'F' or 'U' for undeclared");
            personString.Add(Console.ReadLine());


            //Address
            Console.WriteLine("Please enter the Street Name");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the Street Number");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the city");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the state");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the zip code");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the country");
            personString.Add(Console.ReadLine());

            //Phone
            Console.WriteLine("Please enter the Country Code");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the area code (3 numbers)");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the phone number without area code and dashes");
            personString.Add(Console.ReadLine());

            personString.ForEach(p => Console.WriteLine($"Value: {p}, Type: {p.GetType()}"));

            if (personString.Count() == 14)
            {
                return personString;
            }
            else
            {
                for (int i = personString.Count(); i < 14; i++)
                {
                    personString.Add(null);
                }
                return personString;
            }

        }
        public static List<string> GetAddressListStr()
        {
            List<string> addStr = new List<string>();

            Console.WriteLine("Please enter the house number of the address: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("Please enter the street name of the address: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("Please enter the city: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("Please enter the state: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("Please enter the zip code: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("Please enter the country: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            return addStr;
        }


        public void Print()
        {
            String s = String.Format("{0,5} {1,15} {2,15}", this.Pid, this.FirstName, this.LastName);
            Console.WriteLine(s);

            //Console.WriteLine(this.Pid);
            //Console.WriteLine(this.FirstName);
            //Console.WriteLine(this.LastName);
            //Console.WriteLine(this.Gender);
            //Console.WriteLine(this.DoB);
            //Console.WriteLine(this.myAddress.StreetName);
            //Console.WriteLine(this.myAddress.HouseNum);
            //Console.WriteLine(this.myAddress.City);
            //Console.WriteLine(this.myAddress.Zipcode);
            //Console.WriteLine(this.myAddress.Country);
            //Console.WriteLine(this.myPhone.CountryCode);
            //Console.WriteLine(this.myPhone.AreaCode);
            //Console.WriteLine(this.myPhone.Number);
        }
        public static string NoPunctuation(string s)
        {
            string s2 = new string(s.Where(c => !char.IsPunctuation(c)).ToArray());
            return s2;
        }

        public static List<String> PopulatePersonListString(){
            return new List<string> {Convert.ToString(Person.max_id), "Elon", "Musk", "M", "06-28-1971", "Tesla Ln", "5", "Los Angeles", "CA","21001", "United States", "1", "410", "2223333" };
        }
    }
        

}
