using kmaodus_zadaca_1.Alati;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Singleton
{
    public sealed class PodaciManager
    {
        private static readonly PodaciManager _singletonInstanca = new PodaciManager();
        private PodaciManager()
        {
            //VrsteVozila = new List<VrstaVozila>();
            //Lokacije = new List<OrganizacijskaJedinicaKomponentaBase>();
            //Cjenik = new List<Cjenik>();
            //LokacijaKapaciteti = new List<LokacijaKapacitet>();
            //Aktivnosti = new List<Aktivnost>();
            //Osobe = new List<Osoba>();
            //ListaVozila = new List<Vozilo>();
            //ListaRacuna = new List<Racun>();
        }

        public static PodaciManager GetInstance() => _singletonInstanca;

        //public OrganizacijskaJedinica Tvrtka { get; set; }
        //public List<VrstaVozila> VrsteVozila { get; set; }
        //public List<OrganizacijskaJedinicaKomponentaBase> Lokacije { get; set; }
        //public List<Cjenik> Cjenik { get; set; }
        //public List<LokacijaKapacitet> LokacijaKapaciteti { get; set; }
        //public List<Aktivnost> Aktivnosti { get; set; }
        //public List<Osoba> Osobe { get; set; }
        //public List<Vozilo> ListaVozila { get; set; }
        //public List<Racun> ListaRacuna { get; set; }

        public int Tekst { get; set; }
        public int Cijeli { get; set; }
        public int Decimala { get; set; }
        public float Dugovanje { get; set; }
        public string Izlaz { get; set; }

        public static int BrojacRacuna = 1;

               

        public void UcitajPodatke(string kljuc, string vrijednost)
        {
            if (!ProvjeraNazivDatotekaPrazno(vrijednost))
            {
                switch (kljuc.Trim())
                {
                    case "struktura":
                        putanjaStruktura = vrijednost;
                        break;
                    case "aktivnosti":
                        putanjaAktivnosti = vrijednost;
                        break;
                    case "tekst":
                        Tekst = int.Parse(vrijednost.Trim());
                        break;
                    case "cijeli":
                        Cijeli = int.Parse(vrijednost.Trim());
                        break;
                    case "decimala":
                        Decimala = int.Parse(vrijednost.Trim());
                        break;
                    case "dugovanje":
                        Dugovanje = float.Parse(vrijednost.Trim());
                        break;
                    case "izlaz":
                        Izlaz = vrijednost.Trim();
                        break;
                    default:
                        Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] U konfiguracijskoj datoteci ne postoji opcija/naredba ---> {kljuc}");
                        break;
                }
            }
        }



        public bool ProvjeraNazivDatotekaPrazno(string naziv) => string.IsNullOrEmpty(naziv);


    }
}
