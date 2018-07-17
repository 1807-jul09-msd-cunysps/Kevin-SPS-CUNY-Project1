using System;
using ConsumeDrag.Drag;
namespace ConsumeDrag
{
    class Program
    {
        static void Main(string[] args)
        {
            DragClient client = new DragClient();
            Console.WriteLine($"Drag force = {client.calcDrag(0.23M,21M,30M)}");
            Console.Read();

        }
    }
}
