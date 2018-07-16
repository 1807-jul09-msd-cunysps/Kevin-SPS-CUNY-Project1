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
            //test strings
            string s1 = "A nut for a jar of tuna.";
            string s2 ="Borrow or rob";
            string s3 = "343";

            //Remove Whitespace and Puncuation
            s1 = Palindromic.removeWhitePunct(s1);
            s2 = Palindromic.removeWhitePunct(s2);
            s3 = Palindromic.removeWhitePunct(s3);

            //Create the palindrome
            s1 = Palindromic.getPalindrome(s1);
            s2 = Palindromic.getPalindrome(s2);
            s3 = Palindromic.getPalindrome(s3);

            //Act

            bool b1 = Palindromic.IsPalindromic(s1);
            bool b2 = Palindromic.IsPalindromic(s2);
            bool b3 = Palindromic.IsPalindromic(s3);

            //Assert
            Assert.IsTrue(b1);
            Assert.IsTrue(b2);
            Assert.IsTrue(b3);
        }
    }
}
