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
            //Display UI on Console
            UI uI = new UI();
            uI.Print();
            //Read user input
            while (uI.IsOpen()) { 
                int input = uI.UIRead();
                uI.UISwitch(input);
            }
        }
    }
}
