using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLibrary
{
    public class Person
    {
        public long Pid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB {
            public DateTime DoB(int year, int month, int day);
             {get ; set; }
        }

    }
    public class Address
    {
        public long Pid { get; set; }
        public string StreetName { get; set; }
        public string HouseNum   {get; set;}
        public string City   {get; set;}
        public string State   {get; set;}
        public int Zipcode { get; set; }
        public Enum Country { get; set; }

    }

    public class Phone
    {
        public long Pid             {get;set;}
        public int CountryCode      {get;set;}
        public int AreaCode         {get;set;}
        public int Number        { get; set; }

    }
}
