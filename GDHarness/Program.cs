using System;
using GDConsumer;

namespace GDHarness
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new GDConsumer.GDConsumer().GDWireupTest());
            Console.ReadLine();
        }
    }
}
