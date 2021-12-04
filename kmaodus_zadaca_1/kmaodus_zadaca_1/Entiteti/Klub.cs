namespace kmaodus_zadaca_1.Entiteti
{
    public class Klub
    {
        public string ID_Klub { get; set; }
        public string Naziv { get; set; }
        public string Trener { get; set; }

        public Klub(string idKlub, string naziv, string trener)
        {
            ID_Klub = idKlub;
            Naziv = naziv;
            Trener = trener;
        }
    }
}
