namespace kmaodus_zadaca_2.Entiteti
{
    public class SastaviUtakmica
    {
        public int Broj { get; set; }
        public string Klub { get; set; }
        public string Vrsta { get; set; }
        public string Igrac { get; set; }
        public string Pozicija { get; set; }

        public SastaviUtakmica(int broj, string klub, string vrsta, string igrac, string pozicija)
        {
            Broj = broj;
            Klub = klub;
            Vrsta = vrsta;
            Igrac = igrac;
            Pozicija = pozicija;
        }
    }
}
