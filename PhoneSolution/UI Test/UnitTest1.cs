using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneAppLibrary;

namespace UI_Test
{
    [TestClass]
    public class UnitTest1
    {
        Person p = new Person(Person.PopulatePersonListString());
        Person q = new Person(Person.PopulatePersonListString());
        q.FirstName = q.FirstName.Concat("er");
        [TestMethod]
        public void TestSearchContactById(int id)
        {
            //arrange

            //act

            //assert
        }
    }
}
