using System;

namespace kmaodus_zadaca_2.Entiteti
{
    public class Utakmica
    {
        public int Broj { get; set; }
        public int Kolo { get; set; }
        public string ID_Domacin { get; set; }
        public string ID_Gost { get; set; }
        public DateTime Pocetak { get; set; }

        public Utakmica(int broj, int kolo, string id_domacin, string id_gost, DateTime pocetak)
        {
            Broj = broj;
            Kolo = kolo;
            ID_Domacin = id_domacin;
            ID_Gost = id_gost;
            Pocetak = pocetak;
        }
    }
}
