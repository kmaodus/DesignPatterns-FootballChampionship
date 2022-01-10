namespace kmaodus_zadaca_2.Entiteti
{
    public class Dogadaj
    {
        public int Broj { get; set; }
        public string Minuta { get; set; }
        public int Vrsta { get; set; }
        public string Klub { get; set; }
        public string Igrac { get; set; }
        public string Zamjena { get; set; }

        public Dogadaj(int broj, string minuta, int vrsta, string klub, string igrac, string zamjena)
        {
            Broj = broj;
            Minuta = minuta;
            Vrsta = vrsta;
            Klub = klub;
            Igrac = igrac;
            Zamjena = zamjena;
        }
    }
}
