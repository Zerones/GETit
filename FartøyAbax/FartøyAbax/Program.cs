using System;
using System.Collections.Generic;

namespace FartøyAbax
{
    class Program
    {
        static void Main(string[] args)
        {
            Sammenlikne();
            Liste();
            Console.ReadKey();
        }
        public static void Sammenlikne()
        {
            var bil1 = new Bil("NF123456", 147, 200, "Grønn", "lett kjøretøy");
            var bil2 = new Bil("NF654321", 150, 195, "Blå", "lett kjøretøy");
            bil1.Sammenlikne(bil2);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        }
        public static void Liste()
        {
            var array = Garasje();
            foreach(var item in array)
            {
                item.Print();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            }
        }
        public static Fartøy[] Garasje()
        {
            var bil1 = new Bil("NF123456", 147, 200, "Grønn", "lett kjøretøy");
            var bil2 = new Bil("NF654321", 150, 195, "Blå", "lett kjøretøy");
            var fly = new Fly("LN1234", 1000, 30, 2, 10, "jetfly");
            var båt = new Båt("ABC123", 100, 30, 500);
            return new Fartøy[] { bil1, bil2, fly, båt};
        }
    }
}
