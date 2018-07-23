using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PhoneLibrary
{
    [DataContract]
    public class Person
    {
        //Data Members
        #region
        public Person()
        {
        }
        
        public Person(long pid, string fName, string lName, string DoB, Address address, Phone phone)
        {
            this.Pid = pid;
            this.FirstName = fName;
            this.LastName = lName;
            this.DoB = DoB;
            this.Address = address;
            this.Phone = phone;
        }
        [DataMember]
        public long Pid { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime DoB { get; set; }
        [DataMember]
        public Address myAddress { get; set; }
        [DataMember]
        public Phone myPhone { get; set; }

        [DataContract]
        public class Address
        {
            public Address(long pid, string sName, string hNum, string city, string state, int zCode, Enum Country)
            {
                this.Pid = pid;
                this.StreetName = sName;
                this.HouseNum = hNum;
                this.City = city;
                this.State = state;
                this.Zipcode = zCode;
                this.Country = Country;
            }
            [DataMember]
            public long Pid { get; set; }
            [DataMember]
            public string StreetName { get; set; }
            [DataMember]
            public string HouseNum { get; set; }
            [DataMember]
            public string City { get; set; }
            [DataMember]
            public string State { get; set; }
            [DataMember]
            public int Zipcode { get; set; }
            [DataMember]
            public Enum Country { get; set; }

        }
        [DataContract]
        public class Phone
        {
            public Phone(long pid, int cCode, int aCode, int number)
            {
                this.Pid = pid;
                this.CountryCode = cCode;
                this.AreaCode = aCode;
                this.Number = number;
            }
            [DataMember]
            public long Pid { get; set; }
            [DataMember]
            public int CountryCode { get; set; }
            [DataMember]
            public int AreaCode { get; set; }
            [DataMember]
            public int Number { get; set; }

        }
        #endregion
        //Returns List of String containing Person fields
        //Requires additional implementation
        public static List<string> GetPersonInfo()
        {
            List<string> personString = new List<string>();
            Console.WriteLine("Please enter the first name of the person");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the last name of the person");
            personString.Add(Console.ReadLine());
            Console.WriteLine("Please enter the Date of Birth");
            personString.Add(Console.ReadLine());
            //personString.Add(Console.ReadLine());
            //Console.WriteLine();
            //Console.WriteLine();
            return personString;
        }
    }
}
