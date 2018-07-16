using System;
using System.Collections;
using PalindromicLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPalindromic
{
    [TestClass]
    public class UnitTestIsPalindromic
    {
        [TestMethod]
        public void TestMethodIsPalindromic()
        {
            //Arrange

            string s1 = "A nut for a jar of tuna.";
            string s2 ="Borrow or rob";
            string s3 = "343";
            string[] s = new string[3];

            //Act
            bool b1 = Palindromic.IsPalindromic(s1);
            bool b2 = Palindromic.IsPalindromic(s2);
            bool b3 = Palindromic.IsPalindromic(s3);
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);
            //Assert
            Assert.IsTrue(b1);
            Assert.IsTrue(b2);
            Assert.IsTrue(b3);
        }
    }
}
