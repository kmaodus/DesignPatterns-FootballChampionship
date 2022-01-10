using kmaodus_zadaca_2.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_2.Singleton
{
    public class BazaPodataka
    {
        private static BazaPodataka _instanca;

        public List<Igrac> Igraci { get; set; }
        public List<Klub> Klubovi { get; set; }
        public List<Utakmica> Utakmice { get; set; }
        public List<SastaviUtakmica> SastaviUtakmica { get; set; }
        public List<Dogadaj> Dogadaji { get; set; }


        private BazaPodataka() { }

        public static BazaPodataka DajInstancu()
        {
            if (_instanca == null)
            {
                _instanca = new BazaPodataka();
            }
            return _instanca;
        }
    }
}
