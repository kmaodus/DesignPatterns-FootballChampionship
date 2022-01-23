using kmaodus_zadaca_2.Decorator;
using System.Collections.Generic;

namespace kmaodus_zadaca_2.Entiteti
{
    public class StanjeKlubaNaLjestvici : IKomponenta
    {
        public Klub Klub { get; set; }
        public int BrojOdigranihKola
        {
            get { return BrojPobjeda + BrojNeriješenih + BrojPoraza; }
        }
        public int BrojPobjeda { get; set; }
        public int BrojNeriješenih { get; set; }
        public int BrojPoraza { get; set; }
        public int BrojDanihGolova { get; set; }
        public int BrojPrimljenihGolova { get; set; }
        public int RazlikaGolova
        {
            get { return BrojDanihGolova - BrojPrimljenihGolova; }
        }

        // 0-poraz 1-nerijeseno 3-pobjeda
        public int BrojBodova
        {
            get { return BrojPobjeda * 3 + BrojNeriješenih; }
            private set { }
        }


        public int BrojZutihKartona { get; set; }
        public int BrojDrugihZutihKartona { get; set; }
        public int BrojCrvenihKartona { get; set; }
        public int UkupanBrojKartona
        {
            get { return BrojZutihKartona + BrojDrugihZutihKartona + BrojCrvenihKartona; }
        }

        public override void Dodaj(IKomponenta child)
        {
            throw new System.NotImplementedException();
        }

        public override IKomponenta GetChild(int index)
        {
            throw new System.NotImplementedException();
        }

        public override List<IKomponenta> GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public override void Prikazi() { }

        public override void Ukloni(IKomponenta child)
        {
            throw new System.NotImplementedException();
        }
    }
}
