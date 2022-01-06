namespace kmaodus_zadaca_1.Entiteti
{
    public class StanjeKlubaNaLjestvici
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

        // 0-loss 1-tie 3-win
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


    }
}
