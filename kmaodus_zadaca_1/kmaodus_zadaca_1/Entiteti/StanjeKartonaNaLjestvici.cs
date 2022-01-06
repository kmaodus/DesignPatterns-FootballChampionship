using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class StanjeKartonaNaLjestvici
    {
        public Klub Klub { get; set; }
        public int BrojZutihKartona { get; set; }
        public int BrojDrugihZutihKartona { get; set; }
        public int BrojCrvenihKartona { get; set; }
        public int UkupanBrojKartona
        {
            get { return BrojZutihKartona + BrojDrugihZutihKartona + BrojCrvenihKartona; }
        }


    }
}
