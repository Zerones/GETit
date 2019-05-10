using System;

namespace FartøyAbax
{
    public class Fartøy
    {
        public int Effekt { get; set; }
        public string Klasse { get; set; }
        public string[] Egenskaper { set; get; }
        public string ID { get;  set; }

        public Fartøy(string id, int effekt, string klasse)
        {
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
