using kmaodus_zadaca_2.Builder;
using kmaodus_zadaca_2.Entiteti;
using kmaodus_zadaca_2.FactoryMethod;
using kmaodus_zadaca_2.Singleton;
using kmaodus_zadaca_2_ucitavanje.Facade;
using System.Collections.Generic;
using System.Linq;

namespace kmaodus_zadaca_2.Alati
{
    public class AktivnostManager
    {
        private static AktivnostManager _instanca;

        //private List<UtakmicaPotpuno> utakmicePotpuno { get; set; } = new List<UtakmicaPotpuno>();
        public Prvenstvo Prvenstvo { get; set; }


        public AktivnostManager() { }
        public static AktivnostManager DajInstancu(BazaPodataka bp)
        {
            if (_instanca == null)
            {
                _instanca = new AktivnostManager(bp);
            }
            return _instanca;
        }
        private BazaPodataka _bazaPodataka { get; set; }
        public AktivnostManager(BazaPodataka baza)
        {
            _bazaPodataka = baza;
            //utakmicePotpuno = new List<UtakmicaPotpuno>();

            Prvenstvo = Prvenstvo.DajInstancu(_bazaPodataka.Klubovi, _bazaPodataka.Igraci);

            RekreirajUtakmicePotpuno();
        }




        #region Aktivnosti
        public void Aktivnost1(int kolo)
        {
            Prvenstvo.PregledLjestviceKlubovaNakonKola(kolo);
        }
        public void Aktivnost2(int kolo)
        {
            Prvenstvo.PregledStrijelacaNakonKola(kolo);
        }
        public void Aktivnost3(int kolo)
        {
            Prvenstvo.PregledKartonaKlubovaNakonKola(kolo);
        }
        public void Aktivnost4(string klub, int kolo)
        {
            Prvenstvo.PregledRezultataUtakmicaZaKlubNakonKola(klub, kolo);
        }
        public void Aktivnost5(int kolo, string klubDomacin, string klubGost, int sekunde) 
        {
            Prvenstvo.PrikaziSemaforUtakmice();
        }


        public void AktivnostDodavanjeUtakmica(string unos)
        {
            string[] rijeci = unos.Split(' ');

            PodaciLoaderFactory podaciLoaderFactory = new PodaciLoaderFactory();
            Posrednik posrednik = new Posrednik();

            List<string> redoviUtakmice = posrednik.DohvatiUtakmice(rijeci[1]);
            var loaderUtakmica = podaciLoaderFactory.DohvatiUtakmiceLoader();
            _bazaPodataka.Utakmice = loaderUtakmica.UcitajPodatke(redoviUtakmice);

            RekreirajUtakmicePotpuno();
            //Prvenstvo.UtakmicePotpuno = utakmicePotpuno;

        }

        public void AktivnostDodavanjeSastava(string unos)
        {
            string[] rijeci = unos.Split(' ');

            PodaciLoaderFactory podaciLoaderFactory = new PodaciLoaderFactory();
            Posrednik posrednik = new Posrednik();

            List<string> redoviSastaviUtakmice = posrednik.DohvatiSastaveUtakmica(rijeci[1]);
            var loaderSastaviUtakmica = podaciLoaderFactory.DohvatiSastavUtakmicaLoader();
            _bazaPodataka.SastaviUtakmica = loaderSastaviUtakmica.UcitajPodatke(redoviSastaviUtakmice);

            RekreirajUtakmicePotpuno();
            //Prvenstvo.UtakmicePotpuno = utakmicePotpuno;
        }

        public void AktivnostDodavanjeDogađaja(string unos)
        {
            string[] rijeci = unos.Split(' ');

            PodaciLoaderFactory podaciLoaderFactory = new PodaciLoaderFactory();
            Posrednik posrednik = new Posrednik();

            List<string> redoviDogadaja = posrednik.DohvatiDogadaje(rijeci[1]);
            var loaderDogadaja = podaciLoaderFactory.DohvatiDogadajLoader();
            _bazaPodataka.Dogadaji = loaderDogadaja.UcitajPodatke(redoviDogadaja);

            RekreirajUtakmicePotpuno();

            //Prvenstvo.UtakmicePotpuno = utakmicePotpuno;
        }

        public void RekreirajUtakmicePotpuno()
        {
            //utakmicePotpuno.Clear();

            UtakmicaPotpunoBuilder utakmicaPotpunoBuilder = new UtakmicaPotpunoBuilder();

            foreach (var utakmica in _bazaPodataka.Utakmice)
            {
                var temp = utakmicaPotpunoBuilder.KreirajUtakmicaPotpuno(_bazaPodataka, utakmica.Broj);
                //utakmicePotpuno.Add(temp);

                //composite metoda
                Prvenstvo.DodajUtakmicuPotpuno(temp);
            }
        }


        #endregion

        public void IzvrsiAktivnosti(string unos)
        {
            //int maxKolo = utakmicePotpuno.Max(x => x.Utakmica.Kolo);
            int maxKolo = Prvenstvo.DohvatiUtakmicePotpuno().Max(x => x.Utakmica.Kolo);


            char oznaka;
            string uneseniKlub = "";
            int brojKola;

            var poljeZnakova = unos.Trim().ToCharArray();
            var splitZnakova = unos.Split(' ');
            // R SP [kolo]
            // R D [kolo]

            //if (true)
            //{

            //}else

            if (splitZnakova.Length == 2)
            {
                oznaka = poljeZnakova[0];
                uneseniKlub = splitZnakova[1];
                brojKola = maxKolo;
            }
            else if (splitZnakova.Length == 3)
            {
                oznaka = poljeZnakova[0];
                uneseniKlub = splitZnakova[1];
                brojKola = int.Parse(splitZnakova[2]);
            }
            else if (poljeZnakova.Length == 2 && int.TryParse(poljeZnakova[1].ToString(), out brojKola))
            {
                oznaka = poljeZnakova[0];
                brojKola = int.Parse(poljeZnakova[1].ToString());
            }
            else if (poljeZnakova.Length == 2 && !int.TryParse(poljeZnakova[1].ToString(), out brojKola))
            {
                oznaka = poljeZnakova[0];
                uneseniKlub = poljeZnakova[1].ToString();
                brojKola = maxKolo;
            }
            else
            {
                oznaka = poljeZnakova[0];
                brojKola = maxKolo;
            }


            switch (oznaka)
            {
                // TODO: parametar za kolo je opcionalan! 
                case 'T':
                    Aktivnost1(brojKola);
                    break;
                case 'S':
                    Aktivnost2(brojKola);
                    break;
                case 'K':
                    Aktivnost3(brojKola);
                    break;
                case 'R': //R D 4 
                    Aktivnost4(uneseniKlub, brojKola);
                    break;
                case 'D': // D 3 O H 2 
                    //Aktivnost5();
                    break;
                default:
                    Zapisnik.Ispis(Zapisnik.GRESKA, $"\n[GRESKA] Neispravan unos, provjerite upisanu oznaku!");
                    break;
            }
        }

    }
}
