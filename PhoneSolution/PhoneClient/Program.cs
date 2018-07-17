using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //Display main menu
            Console.WriteLine("Welcome to PhoneApp");
            Console.WriteLine("Please enter the key corresponding to desired action: ");
            PhoneLibrary.UI.DisplayStringArray();
            //Read user input
            int input = int.Parse(Console.ReadLine());

        }
    }
}
