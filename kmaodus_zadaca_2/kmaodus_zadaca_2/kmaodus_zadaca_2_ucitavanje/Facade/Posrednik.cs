using System.Collections.Generic;
using System.IO;

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
            if (File.Exists(izvornaDatoteka))
            {
                Zapisnik2.Ispis(Zapisnik2.OBAVIJEST, $"=== Ucitavanje datoteke igraca - {izvornaDatoteka} ===");
                return IgracReader.DohvatiSve(izvornaDatoteka);
            }
            else
            {
                Zapisnik2.Ispis(Zapisnik2.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }

        public List<string> DohvatiKlubove(string izvornaDatoteka)
        {
            if (File.Exists(izvornaDatoteka))
            {
                Zapisnik2.Ispis(Zapisnik2.OBAVIJEST, $"=== Ucitavanje datoteke klubova - {izvornaDatoteka} ===");
                return KlubReader.DohvatiSve(izvornaDatoteka);
            }
            else
            {
                Zapisnik2.Ispis(Zapisnik2.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }

        public List<string> DohvatiUtakmice(string izvornaDatoteka)
        {
            if (File.Exists(izvornaDatoteka))
            {
                Zapisnik2.Ispis(Zapisnik2.OBAVIJEST, $"=== Ucitavanje datoteke utakmica - {izvornaDatoteka} ===");
                return UtakmicaReader.DohvatiSve(izvornaDatoteka);
            }
            else
            {
                Zapisnik2.Ispis(Zapisnik2.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }

        public List<string> DohvatiDogadaje(string izvornaDatoteka)
        {
            if (File.Exists(izvornaDatoteka))
            {
                Zapisnik2.Ispis(Zapisnik2.OBAVIJEST, $"=== Ucitavanje datoteke dogadaja - {izvornaDatoteka} ===");
                return DogadajReader.DohvatiSve(izvornaDatoteka);
            }
            else
            {
                Zapisnik2.Ispis(Zapisnik2.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }

        public List<string> DohvatiSastaveUtakmica(string izvornaDatoteka)
        {
            if (File.Exists(izvornaDatoteka))
            {
                Zapisnik2.Ispis(Zapisnik2.OBAVIJEST, $"=== Ucitavanje datoteke sastava utakmica - {izvornaDatoteka} ===");
                return SastaviUtakmicaReader.DohvatiSve(izvornaDatoteka);
            }
            else
            {
                Zapisnik2.Ispis(Zapisnik2.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }


    }
}
