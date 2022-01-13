using System.Collections.Generic;

namespace kmaodus_zadaca_2_ucitavanje.Facade
{
    public class Posrednik
    {
        private IgracReader IgracReader { get; set; }
        private DogadajReader DogadajReader { get; set; }
        private KlubReader KlubReader { get; set; }
        private SastaviUtakmicaReader SastaviUtakmicaReader { get; set; }
        private UtakmicaReader UtakmicaReader { get; set; }


        public Posrednik() 
        {
            IgracReader = new IgracReader();
            DogadajReader = new DogadajReader();
            KlubReader = new KlubReader();
            SastaviUtakmicaReader = new SastaviUtakmicaReader();
            UtakmicaReader = new UtakmicaReader();
        }


        public List<string> DohvatiIgrace(string izvornaDatoteka)
        {
            return IgracReader.DohvatiSve(izvornaDatoteka);
        }

        public List<string> DohvatiKlubove(string izvornaDatoteka)
        {
            return KlubReader.DohvatiSve(izvornaDatoteka);
        }

        public List<string> DohvatiUtakmice(string izvornaDatoteka)
        {
            return UtakmicaReader.DohvatiSve(izvornaDatoteka);
        }

        public List<string> DohvatiDogadaje(string izvornaDatoteka)
        {
            return DogadajReader.DohvatiSve(izvornaDatoteka);
        }

        public List<string> DohvatiSastaveUtakmica(string izvornaDatoteka)
        {
            return SastaviUtakmicaReader.DohvatiSve(izvornaDatoteka);
        }

        
    }
}
