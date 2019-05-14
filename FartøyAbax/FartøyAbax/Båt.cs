namespace FartøyAbax
{
    class Båt : Fartøy
    {
        public int Bruttotonnasje { get; private set; }

        public Båt(string id, int effekt, int maksfart, int bruttotonnasje) : base(id, effekt, maksfart, "")
        {
            Bruttotonnasje = bruttotonnasje;
            var innehold = new string[] {
                "Kjennetegn: " + ID,
                "Effekt: " + Effekt.ToString() + "KW",
                "Maksfart: " + Maksfart.ToString() + "knop",
                "Bruttotonnasje: " + Bruttotonnasje.ToString() + " tonn"};
            Egenskaper = innehold;

        }
    }
}
