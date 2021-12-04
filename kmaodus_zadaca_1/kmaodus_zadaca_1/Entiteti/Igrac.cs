using System;
using System.Collections.Generic;

namespace kmaodus_zadaca_1.Entiteti
{
    public class Igrac : Osoba
    {
        public string ID_Klub { get; set; }
        public List<string> Pozicije { get; set; } = new List<string>();
        public DateTime Roden { get; set; }


        public Igrac(string id_klub, string imePrezime, List<string> pozicije, DateTime roden)
        {
            ID_Klub = id_klub;
            ImePrezime = imePrezime;
            Pozicije = pozicije;
            Roden = roden;
        }

    }
}
