using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromicLibrary
{
    public static class Palindromic
    {

        public static string removeWhitePunct(string s)
        {
            s.Trim();
            s.ToLower();
            string s1 = "";
            for (int i = 0; i < s1.Length; i++)
            {
                char c = Convert.ToChar(s[i]);

                if (!Char.IsWhiteSpace(c) && !Char.IsPunctuation(c))
                {
                    s1 = s1 + c;
                }
            }
            return s1;
        }
        
        public static string getPalindrome(string s)
        {
            string s1 = removeWhitePunct(s);
            string s2 = "";
            for (int i=0;i<s1.Length;i++)
            {
                s2 = s2 += s1[s1.Length - 1 - i];
            }
            return s2;
         }

    

        public static bool IsPalindromic(string s)
        {
            s.Trim();
            s.ToLower();
            if (Palindromic.getPalindrome(s) == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    }
}
   
