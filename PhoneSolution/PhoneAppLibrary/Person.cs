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
        //Default Constructor
        public Person()
        {
        }

        //Person constructors
        #region
        //Constructor that takes in List of strings that has size of 14 elements
        public Person(List<string> p)
        {

            FirstName = p[0];
            LastName = p[1];
            Gender = p[2];
            DoB = Convert.ToString(p[3]);
            myAddress = new Address(p[4], p[5],p[6], p[7], p[8]);
            myPhone = new Phone(p[9], p[10], p[11]);
        }
        public Person(string fName, string lName, string gender, string DoB, Address address, Phone phone)
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
            public Address(string add, string city, string state, string zCode, string Country)
            {
                this.Address1 = add;
                this.City = city;
                this.State = state;
                this.Zipcode = zCode;
                this.Country = Country;
            }
            #endregion
            //constructor given List of string
            public Address(List<string> addstr)
            {
                this.City = addstr[0];
                this.State = addstr[1];
                this.Zipcode = addstr[2];
                this.Country = addstr[3];
            }

            //Data members
            #region

            [DataMember]
            public string Address1 { get; set; }
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
            public Phone(string cCode, string aCode, string number)
            {
                this.CountryCode = cCode;
                this.AreaCode = aCode;
                this.Number = number;
            }

            [DataMember]
            public string CountryCode { get; set; }
            [DataMember]
            public string AreaCode { get; set; }
            [DataMember]
            public string Number { get; set; }

        }

        //Returns List of String containing Person fields
        //Requires additional implementation
        //public static List<string> GetPersonInfo()
        //{
        //    List<string> personString = new List<string>();

        //    personString.Add(Convert.ToString(Person.max_id));
        //    Console.WriteLine("Please enter the first name of the person");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the last name of the person");
        //    personString.Add(Console.ReadLine());
            
        //    Console.WriteLine("Please enter the gender of the person ('M' or 'F' or 'U' for undeclared");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the Date of Birth");
        //    personString.Add(Console.ReadLine());


        //    //Address
        //    Console.WriteLine("Please enter the Street Name");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the Street Number");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the city");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the state");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the zip code");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the country");
        //    personString.Add(Console.ReadLine());

        //    //Phone
        //    Console.WriteLine("Please enter the Country Code");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the area code (3 numbers)");
        //    personString.Add(Console.ReadLine());
        //    Console.WriteLine("Please enter the phone number without area code and dashes");
        //    personString.Add(Console.ReadLine());

        //    if (personString.Count() == 14)
        //    {
        //        return personString;
        //    }
        //    else
        //    {
        //        for (int i = personString.Count(); i < 14; i++)
        //        {
        //            personString.Add(null);
        //        }
        //        return personString;
        //    }

        //}
        public static List<string> GetAddressListStr()
        {
            List<string> addStr = new List<string>();

            Console.WriteLine("Please enter the street name of the address: ");
            addStr.Add(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("Please enter the house number of the address: ");
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
            


            String s = String.Format("{0,5} {1,15} {2,15} {3,5} {4,25}", this.Pid, this.FirstName, this.LastName, this.Gender, this.myAddress.HouseNum+' '+this.myAddress.Address1);
            s += String.Format("{0,12} {1,12} {2,15} {3, 15}", this.myAddress.City, this.myAddress.State, this.myAddress.Zipcode, this.myAddress.Country);
            s += String.Format("{0,8} {1,8}{2,12}", this.myPhone.CountryCode, this.myPhone.AreaCode, this.myPhone.Number);
            Console.WriteLine(s);
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
