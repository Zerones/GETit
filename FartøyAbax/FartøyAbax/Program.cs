using System;

namespace FartøyAbax
{
    class Program
    {
        static void Main(string[] args)
        {
            Bildel();
            Fly();
            Console.ReadKey();
        }
        public static void Bildel()
        {
            var bil1 = new Bil("NF123456", 147, 200, "Grønn", "lett kjøretøy");
            var bil2 = new Bil("NF654321", 150, 195, "Blå", "lett kjøretøy");
            bil1.Sammenlikne(bil2);
            bil1.Print();
            bil2.Print();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        }
        public static void Fly()
        {
            var fly = new Fly("LN1234", 1000, 30, 2, 10, "jetfly");
            fly.Print();
        }

    }
}
