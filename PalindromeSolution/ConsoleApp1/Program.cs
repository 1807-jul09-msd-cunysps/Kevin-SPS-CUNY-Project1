using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalindromicLibrary;
using System.Threading.Tasks;


namespace Palindromic
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "A nut for a jar of tuna.";
            string s2 = "Borrow or rob";
            string s3 = "343";
        
            Console.WriteLine(PalindromicLibrary.Palindromic.getPalindrome(s1));
            Console.WriteLine(PalindromicLibrary.Palindromic.getPalindrome(s2));
            Console.WriteLine(PalindromicLibrary.Palindromic.getPalindrome(s3));
            Console.ReadLine();
        }
    }
}
