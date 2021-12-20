using kmaodus_zadaca_1.Alati;
using kmaodus_zadaca_1.Entiteti;
using kmaodus_zadaca_1.FactoryMethod;
using kmaodus_zadaca_1.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            // args za debug
            args = new[] {
                            "-i", "../../TestneDatoteke/DZ1_igraci.csv",
                            "-s", "../../TestneDatoteke/DZ1_sastavi_utakmica.csv",
                            "-u", "../../TestneDatoteke/DZ1_utakmice.csv",
                            "-k", "../../TestneDatoteke/DZ1_klubovi.csv",
                            "-d", "../../TestneDatoteke/DZ1_dogadaji.csv"
                        };
#endif



            //subota
            BazaPodataka bazaPodataka = BazaPodataka.DajInstancu();
            PodaciLoaderFactory podaciLoaderFactory = new PodaciLoaderFactory();

            Zapisnik.Ispis(Zapisnik.OBAVIJEST, new string('=', 100));
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, "Ucitavanje datoteka:");
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, new string('=', 100));

            var loaderIgraca = podaciLoaderFactory.DohvatiIgracLoader();
            bazaPodataka.Igraci = loaderIgraca.UcitajPodatke(@"C:\FAX\9 semestar\UzDiz\2021\zadace\UzDiz_Nogometno_Prvenstvo\kmaodus_zadaca_1\kmaodus_zadaca_1\TestneDatoteke\DZ1_igraci.csv");

            var loaderKlubova = podaciLoaderFactory.DohvatiKlubLoader();
            bazaPodataka.Klubovi = loaderKlubova.UcitajPodatke(@"C:\FAX\9 semestar\UzDiz\2021\zadace\UzDiz_Nogometno_Prvenstvo\kmaodus_zadaca_1\kmaodus_zadaca_1\TestneDatoteke\DZ1_klubovi.csv");

            var loaderUtakmica = podaciLoaderFactory.DohvatiUtakmiceLoader();
            bazaPodataka.Utakmice = loaderUtakmica.UcitajPodatke(@"C:\FAX\9 semestar\UzDiz\2021\zadace\UzDiz_Nogometno_Prvenstvo\kmaodus_zadaca_1\kmaodus_zadaca_1\TestneDatoteke\DZ1_utakmice.csv");

            var loaderSastaviUtakmica = podaciLoaderFactory.DohvatiSastavUtakmicaLoader();
            bazaPodataka.SastaviUtakmica = loaderSastaviUtakmica.UcitajPodatke(@"C:\FAX\9 semestar\UzDiz\2021\zadace\UzDiz_Nogometno_Prvenstvo\kmaodus_zadaca_1\kmaodus_zadaca_1\TestneDatoteke\DZ1_sastavi_utakmica.csv");

            var loaderDogadaja = podaciLoaderFactory.DohvatiDogadajLoader();
            bazaPodataka.Dogadaji = loaderDogadaja.UcitajPodatke(@"C:\FAX\9 semestar\UzDiz\2021\zadace\UzDiz_Nogometno_Prvenstvo\kmaodus_zadaca_1\kmaodus_zadaca_1\TestneDatoteke\DZ1_dogadaji.csv");


            Zapisnik.Ispis(Zapisnik.INFO, $"Pritisnite bilo koju tipku za kraj rada...");
            Console.ReadLine();
        }



        private static void IzlaznaPoruka(string poruka)
        {
            Zapisnik.Ispis(Zapisnik.GRESKA, $"\n[GRESKA] Dogodila se greska --> \t{poruka}");
            Zapisnik.Ispis(Zapisnik.GRESKA, $"Pritisnite bilo koju tipku za kraj rada...");
            Console.WriteLine();
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
