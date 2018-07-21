using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Calculator;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorSoapClient client = new CalculatorSoapClient();
            Console.WriteLine(client.Add(1 + 3));

        }
    }
}
