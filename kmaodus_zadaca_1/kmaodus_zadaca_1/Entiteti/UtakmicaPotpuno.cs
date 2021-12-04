using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class UtakmicaPotpuno
    {
        public KlubPotpuno KlubDomacin { get; set; }
        public KlubPotpuno KlubGost { get; set; }
        public Utakmica Utakmica { get; set; }

        public UtakmicaPotpuno() { }
    }
}
