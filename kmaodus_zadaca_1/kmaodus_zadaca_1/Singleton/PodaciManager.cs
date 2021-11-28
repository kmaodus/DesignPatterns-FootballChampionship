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

        string putanjaAktivnosti = "";
        string putanjaKapaciteti = "";
        string putanjaStruktura = "";

        public static int brojacVozila = 0;

        //public void UcitajPodatkeDatoteka(string vozilaTXT, string lokacijeTXT, string cjenikTXT, string LokacijaKapacitetTXT, string osobeTXT)
        //{
        //    PodaciLoader<VrstaVozila> vozilaLoader = new VozilaLoader(vozilaTXT);
        //    VrstaVozila = vozilaLoader.Podaci;

        //    PodaciLoader<Lokacija> lokacijaLoader = new LokacijeLoader(lokacijeTXT);
        //    Lokacije = lokacijaLoader.Podaci;

        //    PodaciLoader<Cjenik> cjenikLoader = new CjenikLoader(cjenikTXT);
        //    Cjenik = cjenikLoader.Podaci;

        //    PodaciLoader<Osoba> osobaLoader = new OsobaLoader(osobeTXT);
        //    Osobe = osobaLoader.Podaci;

        //}

        public void UcitajPodatke(string kljuc, string vrijednost)
        {
            if (!ProvjeraNazivDatotekaPrazno(vrijednost))
            {
                switch (kljuc.Trim())
                {
                    case "vozila":
                        VrsteVozila = new VozilaLoader(vrijednost).Podaci;
                        break;
                    case "lokacije":
                        Lokacije = new LokacijeLoader(vrijednost).Podaci;
                        break;
                    case "cjenik":
                        Cjenik = new CjenikLoader(vrijednost).Podaci;
                        break;
                    case "kapaciteti":
                        putanjaKapaciteti = vrijednost;
                        break;
                    case "osobe":
                        Osobe = new OsobaLoader(vrijednost).Podaci;
                        break;
                    case "vrijeme":
                        PostaviVrijeme(vrijednost);
                        break;
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

        public void UcitajPreostaleDatoteke()
        {
            if (!string.IsNullOrEmpty(putanjaKapaciteti))
            {
                LokacijaKapaciteti = new LokacijaKapacitetLoader(putanjaKapaciteti).Podaci;
            }

            if (!string.IsNullOrEmpty(putanjaStruktura))
            {
                new StrukturaOrgJedinicaLoader(putanjaStruktura);
            }

            if (!string.IsNullOrEmpty(putanjaAktivnosti))
            {
                Aktivnosti = new AktivnostLoader(putanjaAktivnosti).Podaci;
                foreach (var item in Aktivnosti)
                {
                    IzvrsiAktivnost.Izvrsi(item);
                }
            }
        }

        private void PostaviVrijeme(string vrijednost)
        {
            if (!VirtualnoVrijeme.GetInstance().PostaviTrenutnoVrijeme(vrijednost))
                Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] Vrijeme {vrijednost} nije upisano");
        }

        public bool ProvjeraNazivDatotekaPrazno(string naziv) => string.IsNullOrEmpty(naziv);

        public int PronadiMjestaKapaciteti(int lokacijaId, int vrstaVozilaId)
        {
            foreach (var lokacijaKapacitet in LokacijaKapaciteti)
                if (lokacijaKapacitet.LokacijaId == lokacijaId && lokacijaKapacitet.VrstaVozilaId == vrstaVozilaId)
                {
                    return lokacijaKapacitet.BrojMjestaZaVrstuVozila;
                }

            return 0;
        }

        //public Lokacija PronadiLokaciju(int lokacijaId)
        //{
        //    foreach (Lokacija lokacija in Lokacije)
        //        if (lokacija.Id == lokacijaId)
        //        {
        //            return lokacija;
        //        }

        //    return null;
        //}

        //public VrstaVozila PronadiVrstuVozila(int vrstaVozilaId)
        //{
        //    foreach (var vrstaVozila in VrsteVozila)
        //    {
        //        if (vrstaVozila.Id == vrstaVozilaId)
        //        {
        //            return vrstaVozila;
        //        }
        //    }

        //    return null;
        //}

        //public Vozilo PronadiVozilo(int voziloId)
        //{
        //    foreach (var vozilo in ListaVozila)
        //    {
        //        if (vozilo.GetId() == voziloId)
        //            return vozilo;
        //    }
        //    return null;
        //}

        //public Osoba PronadiOsobu(int osobaId)
        //{
        //    foreach (var osoba in Osobe)
        //    {
        //        if (osoba.Id == osobaId)
        //        {
        //            return osoba;
        //        }
        //    }

        //    return null;
        //}

        //public Cjenik PronadiCjenik(int vrstaVozilaId)
        //{
        //    foreach (var cjenik in Cjenik)
        //    {
        //        if (cjenik.VrstaVozilaId == vrstaVozilaId)
        //        {
        //            return cjenik;
        //        }
        //    }
        //    return null;
        //}

        public bool PostojiIzlaznaDatoteka() => Izlaz != "";
        public void ZapisiUnutarIzlazneDatoteke()
        {
            if (PostojiIzlaznaDatoteka())
            {
                StreamWriter datoteka = File.CreateText(Izlaz);
                datoteka.WriteLine("testing");
            }
        }
    }
}
