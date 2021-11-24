using kmaodus_zadaca_1.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class Igrac : Osoba
    {

        public string ID_Klub { get; set; }
        public List<string> Pozicija { get; set; } = new List<string>();
        public DateTime Roden { get; set; }


        public Igrac()
        {

        }

    }
}
