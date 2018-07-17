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
        [DataMember]
        public long Pid { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime DoB {get ; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public Phone Phone { get; set; }

        
    }

    }
    [DataContract]
    public class Address
    {
        [DataMember]
        public long Pid { get; set; }
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public string HouseNum   {get; set;}
        [DataMember]
        public string City   {get; set;}
        [DataMember]
        public string State   {get; set;}
        [DataMember]
        public int Zipcode { get; set; }
        [DataMember]
        public Enum Country { get; set; }

    }
    [DataContract]
    public class Phone
    {
        [DataMember]
        public long Pid             {get;set;}
        [DataMember]
        public int CountryCode      {get;set;}
        [DataMember]
        public int AreaCode         {get;set;}
        [DataMember]
        public int Number        { get; set; }

    }

    public static Person createPerson()
    {

    }
}
