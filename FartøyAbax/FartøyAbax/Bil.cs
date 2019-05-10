using System;

namespace FartøyAbax
{
    public class Bil : Fartøy
    {
        public int Maksfart { get; private set; }
        public string Farge { get; private set; }

        public Bil(string id, int effekt, int maksfart, string farge, string klasse) : base(id, effekt, klasse)
        {
            Maksfart = maksfart;
            Farge = farge;
             var test = new string[] {
                "Reg.nr: " + ID.ToString(),
                "Effekt:" + Effekt.ToString() + "kw", "Maksfart: " + 
                "Maksfart: " + Maksfart.ToString() + "km/t",
                "Farge:" + Farge,
                "Klasse:" + Klasse};
            Egenskaper = test;
        }
        public bool Compare(Bil fartøy)
        {
            if (ID != fartøy.ID || Effekt != fartøy.Effekt || Maksfart != fartøy.Effekt || Farge != fartøy.Farge) return false;
            else return true;
        }
        public void Sammenlikne(Bil Fartøy)
        {
            if (Compare(Fartøy) == true) Console.WriteLine("Bil 1 og Bil 2 er like!");
            else Console.WriteLine("Bil 1 og Bil 2 er ikke like!");
        }
    }
}
