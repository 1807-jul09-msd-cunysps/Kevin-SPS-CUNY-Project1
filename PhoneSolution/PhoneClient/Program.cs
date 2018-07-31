using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace PhoneAppLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(170, 59);
            //Display UI on Console
            UI uI = new UI();
            uI.ReadContacts();
            Console.WriteLine("\n\n\t\tWelcome to PhoneApp\n");
            //Read user input
            while (uI.IsOpen()) {
                uI.Print();
                int input = uI.UIRead();
                uI.UISwitch(input);
            }
        }
    }
}
