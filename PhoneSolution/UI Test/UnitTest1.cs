using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneAppLibrary;

namespace UI_Test
{
    [TestClass]
    public class UnitTest1
    {
      
        [TestMethod]
        public void TestSearchContactById()
        {
            //arrange
            Person p = new Person(Person.PopulatePersonListString());
            Person q = new Person(Person.PopulatePersonListString());
            string s = q.FirstName;
            string s2 = q.LastName;
            q.FirstName = s + "er";
            q.LastName = s2;

            //act

            //assert
        }
    }
}
