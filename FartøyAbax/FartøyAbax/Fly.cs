namespace FartøyAbax
{
    class Fly : Fartøy
    {
        public int Vingespenn { get; set; }
        public int Lasteevne { get; set; }
        public int Egenvekt { get; set; }

        public Fly(string id, int effekt, int spenn, int last, int vekt, string klasse) : base(id, effekt, klasse)
        {
            Vingespenn = spenn;
            Lasteevne = last;
            Egenvekt = vekt;
            var innehold = new string[] {
                "Kjennetegn: " + ID,
                "Effekt: " + Effekt.ToString() + "KW",
                "Vingespenn: " + Vingespenn.ToString() + "m",
                "Lasteevne: " + Lasteevne.ToString() + " tonn",
                "Egenvekt: " + Egenvekt.ToString() + " tonn",
                "Klasse: " + Klasse
            };
            Egenskaper = innehold;


        }
    }
}
