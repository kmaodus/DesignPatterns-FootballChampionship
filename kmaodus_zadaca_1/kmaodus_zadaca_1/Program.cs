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
            //args = new[] {
            //                "-i", "../../TestneDatoteke/DZ1_igraci.csv",
            //                "-s", "../../TestneDatoteke/DZ1_sastavi_utakmica.csv",
            //                "-u", "../../TestneDatoteke/DZ1_utakmice.csv",
            //                "-k", "../../TestneDatoteke/DZ1_klubovi.csv",
            //                "-d", "../../TestneDatoteke/DZ1_dogadaji.csv"
            //            };
#endif

            //..//

            //cetvrtak
            if (ParserArgumenata.ProvjeriArgumente(args))
            {
                var datIgraci = ParserArgumenata.DohvatiArgument(args, "-i");
                var datKlubovi = ParserArgumenata.DohvatiArgument(args, "-k");
                var datUtakmice = ParserArgumenata.DohvatiArgument(args, "-u");
                var datSastaviUtakmica = ParserArgumenata.DohvatiArgument(args, "-s");
                var datDogadaji = ParserArgumenata.DohvatiArgument(args, "-d");


                BazaPodataka bazaPodataka = BazaPodataka.DajInstancu();
                PodaciLoaderFactory podaciLoaderFactory = new PodaciLoaderFactory();

                Zapisnik.Ispis(Zapisnik.OBAVIJEST, new string('=', 100));
                Zapisnik.Ispis(Zapisnik.OBAVIJEST, "Ucitavanje datoteka:");
                Zapisnik.Ispis(Zapisnik.OBAVIJEST, new string('=', 100));
                Console.WriteLine();

                var loaderIgraca = podaciLoaderFactory.DohvatiIgracLoader();
                bazaPodataka.Igraci = loaderIgraca.UcitajPodatke(datIgraci);


                var loaderKlubova = podaciLoaderFactory.DohvatiKlubLoader();
                bazaPodataka.Klubovi = loaderKlubova.UcitajPodatke(datKlubovi);

                var loaderUtakmica = podaciLoaderFactory.DohvatiUtakmiceLoader();
                bazaPodataka.Utakmice = loaderUtakmica.UcitajPodatke(datUtakmice);

                var loaderSastaviUtakmica = podaciLoaderFactory.DohvatiSastavUtakmicaLoader();
                bazaPodataka.SastaviUtakmica = loaderSastaviUtakmica.UcitajPodatke(datSastaviUtakmica);

                var loaderDogadaja = podaciLoaderFactory.DohvatiDogadajLoader();
                bazaPodataka.Dogadaji = loaderDogadaja.UcitajPodatke(datDogadaji);

                Zapisnik.Ispis(Zapisnik.USPJEH, $"\n[USPJEH] Datoteke učitane");
                PrikaziMenu();

                Zapisnik.Ispis(Zapisnik.INFO, $"Pritisnite bilo koju tipku za kraj rada...");
                Console.ReadLine();

            }
            else
            {
                IzlaznaPoruka("Neispravni argumenti!");
            }
        }

        private static void PrikaziMenu()
        {
            string odabir;

            do
            {
                Zapisnik.Ispis(Zapisnik.INFO, new string('=', 100));
                Console.WriteLine("DOSTUPNE OPCIJE: ");
                Console.WriteLine($"\t Pregled ljestvice nakon određenog kola prvenstva ili za sva odigrana kola u prvenstvu, npr. T5 ");
                Console.WriteLine($"\t Pregled ljestvice strijelaca nakon određenog kola prvenstva ili za sva odigrana kola u prvenstvu, npr. S3 ");
                Console.WriteLine($"\t Pregled ljestvice kartona po klubovima nakon određenog kola prvenstva ili za odigrana kola u prvenstvu, npr. K2 ");
                Console.WriteLine($"\t Pregled rezultata utakmica za klub nakon određenog kola prvenstva ili za odigrana kola u prvenstvu, npr. RD4 ");
                Console.WriteLine("0 - Izlaz ");
                Zapisnik.Ispis(Zapisnik.INFO, new string('=', 100));
                Console.WriteLine("Odaberite opciju unosa ili ugasite program: ");

                odabir = Console.ReadLine().ToString();
                if (String.IsNullOrEmpty(odabir))
                {
                    Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\n[UPOZORENJE] Kriva naredba! Pokušajte ponovno..");
                    continue;
                }
                if (odabir == "0") break ;

                var aktivnostManager = AktivnostManager.DajInstancu(BazaPodataka.DajInstancu());
                aktivnostManager.IzvrsiAktivnosti(odabir);
                // aktivnost.izvrsiAktivnost(odabir);


            } while (true);

            UgasiProgram();
        }

        private static void IzlaznaPoruka(string poruka)
        {
            Zapisnik.Ispis(Zapisnik.GRESKA, $"\n[GRESKA] Dogodila se greska --> {poruka}");
            Zapisnik.Ispis(Zapisnik.INFO, $"Pritisnite bilo koju tipku za kraj rada...");
            Console.WriteLine();
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void UgasiProgram()
        {
            Zapisnik.Ispis(Zapisnik.INFO, $"Odabrali ste izlaz, gasim program...");
            Environment.Exit(0);
        }
    }
}
