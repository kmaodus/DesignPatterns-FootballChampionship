using kmaodus_zadaca_2.Alati;
using kmaodus_zadaca_2.FactoryMethod;
using kmaodus_zadaca_2.Singleton;
using kmaodus_zadaca_2_ucitavanje.Facade;
using System;
using System.Collections.Generic;
using System.Threading;

namespace kmaodus_zadaca_2
{
    class Program
    {
        static void Main(string[] args)
        {
            #if DEBUG
            // args za debug
            //args = new[] {
            //                "-i", "../../TestneDatoteke/DZ2_igraci.csv",
            //                "-s", "../../TestneDatoteke/DZ2_sastavi_utakmica.csv",
            //                "-u", "../../TestneDatoteke/DZ2_utakmice.csv",
            //                "-k", "../../TestneDatoteke/DZ2_klubovi.csv",
            //                "-d", "../../TestneDatoteke/DZ2_dogadaji.csv"
            //            };
            #endif

            Console.SetWindowSize(150, 45);

            if (ParserArgumenata.ProvjeriArgumente(args))
            {
                var datIgraci = ParserArgumenata.DohvatiArgument(args, "-i");
                var datKlubovi = ParserArgumenata.DohvatiArgument(args, "-k");
                var datUtakmice = ParserArgumenata.DohvatiArgument(args, "-u");
                var datSastaviUtakmica = ParserArgumenata.DohvatiArgument(args, "-s");
                var datDogadaji = ParserArgumenata.DohvatiArgument(args, "-d");

                BazaPodataka bazaPodataka = BazaPodataka.DajInstancu();
                PodaciLoaderFactory podaciLoaderFactory = new PodaciLoaderFactory();

                Zapisnik.Ispis(Zapisnik.OBAVIJEST, new string('=', 120));
                Zapisnik.Ispis(Zapisnik.OBAVIJEST, "Ucitavanje datoteka:");
                Zapisnik.Ispis(Zapisnik.OBAVIJEST, new string('=', 120));
                Console.WriteLine();

                Posrednik posrednik = new Posrednik();

                List<string> redoviIgraci =  posrednik.DohvatiIgrace(datIgraci);
                var loaderIgraca = podaciLoaderFactory.DohvatiIgracLoader();
                bazaPodataka.Igraci = loaderIgraca.UcitajPodatke(redoviIgraci);

                List<string> redoviKlubovi =  posrednik.DohvatiKlubove(datKlubovi);
                var loaderKlubova = podaciLoaderFactory.DohvatiKlubLoader();
                bazaPodataka.Klubovi = loaderKlubova.UcitajPodatke(redoviKlubovi);

                List<string> redoviUtakmice = posrednik.DohvatiKlubove(datUtakmice);
                var loaderUtakmica = podaciLoaderFactory.DohvatiUtakmiceLoader();
                bazaPodataka.Utakmice = loaderUtakmica.UcitajPodatke(redoviUtakmice);

                List<string> redoviSastaviUtakmice = posrednik.DohvatiKlubove(datUtakmice);
                var loaderSastaviUtakmica = podaciLoaderFactory.DohvatiSastavUtakmicaLoader();
                bazaPodataka.SastaviUtakmica = loaderSastaviUtakmica.UcitajPodatke(redoviSastaviUtakmice);

                List<string> redoviDogadaja = posrednik.DohvatiKlubove(datUtakmice);
                var loaderDogadaja = podaciLoaderFactory.DohvatiDogadajLoader();
                bazaPodataka.Dogadaji = loaderDogadaja.UcitajPodatke(redoviDogadaja);

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
                Zapisnik.Ispis(Zapisnik.INFO, new string('=', 120));
                Console.WriteLine("DOSTUPNE OPCIJE: ");
                Console.WriteLine($"\t Pregled ljestvice nakon određenog kola prvenstva ili za sva odigrana kola u prvenstvu, npr. T5 ");
                Console.WriteLine($"\t Pregled ljestvice strijelaca nakon određenog kola prvenstva ili za sva odigrana kola u prvenstvu, npr. S3 ");
                Console.WriteLine($"\t Pregled ljestvice kartona po klubovima nakon određenog kola prvenstva ili za odigrana kola u prvenstvu, npr. K2 ");
                Console.WriteLine($"\t Pregled rezultata utakmica za klub nakon određenog kola prvenstva ili za odigrana kola u prvenstvu, npr. RD4 ");
                Console.WriteLine("0 - Izlaz ");
                Zapisnik.Ispis(Zapisnik.INFO, new string('=', 120));
                Console.WriteLine("Odaberite opciju unosa ili ugasite program: ");

                odabir = Console.ReadLine().ToString().ToUpper();
                if (String.IsNullOrEmpty(odabir))
                {
                    Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\n[UPOZORENJE] Kriva naredba! Pokušajte ponovno..");
                    continue;
                }
                if (odabir == "0") break;

                var aktivnostManager = AktivnostManager.DajInstancu(BazaPodataka.DajInstancu());
                aktivnostManager.IzvrsiAktivnosti(odabir);

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
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}


