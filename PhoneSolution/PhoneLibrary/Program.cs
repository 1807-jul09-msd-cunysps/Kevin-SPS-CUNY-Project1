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
            PhoneLibrary.UI uI = new PhoneLibrary.UI();
            //Displays UI on Console
            uI.PrintS();
            //Read user input
            int input = int.Parse(Console.ReadLine());

        }
    }
}
