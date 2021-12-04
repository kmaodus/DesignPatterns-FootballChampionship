using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class UtakmicaPotpuno
    {
        public Sastav KlubDomacin { get; set; }
        public Sastav KlubGost { get; set; }
        public Utakmica Utakmica { get; set; }
        public List<Dogadaj> Dogadaji { get; set; }

        public int KrajnjiRezultat { get; set; }


        //public int BrojPobjedaGosta { get; set; }
        //public int BrojNerijesenihGosta { get; set; }
        //public int BrojGubitakaGosta { get; set; }
        //public int BrojBodovaGosta { get; set; }

        public UtakmicaPotpuno() { }


        public void DohvatiBrojGolovaDomacina() { }
        public void DohvatiBrojGolovaGosta() { }
        public void DohvatiBrojZutihKartonaDomacina() { }
        public void DohvatiBrojZutihKartonaGosta() { }
    }
}
