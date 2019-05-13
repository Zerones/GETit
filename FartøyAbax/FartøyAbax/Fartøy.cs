using System;

namespace FartøyAbax
{
    public class Fartøy
    {
        public int Effekt { get; set; }
        public string Klasse { get; set; }
        public string[] Egenskaper { set; get; }
        public string ID { get;  set; }
        public int Maksfart { get;  set; }

        public Fartøy(string id, int effekt, int maksfart, string klasse)
        {
            Maksfart = maksfart;
            ID = id;
            Effekt = effekt;
            Klasse = klasse;
        }

        public virtual void Print()
        {
            foreach(string line in Egenskaper)
            {
                Console.Write(line + "   ");
            }
            Console.WriteLine();
        }
    }
}
