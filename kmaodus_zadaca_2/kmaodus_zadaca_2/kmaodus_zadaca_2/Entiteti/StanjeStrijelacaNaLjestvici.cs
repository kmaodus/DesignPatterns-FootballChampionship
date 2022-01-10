namespace kmaodus_zadaca_2.Entiteti
{
    public class StanjeStrijelacaNaLjestvici
    {
        public int BrojGolova { get; set; }
        public Igrac Igrac { get; set; }
        public Klub Klub { get; set; }

        public StanjeStrijelacaNaLjestvici()
        {
            BrojGolova = 0;
        }
    }
}
