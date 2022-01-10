using kmaodus_zadaca_2.Alati;
using kmaodus_zadaca_2.Apstrakcije;
using kmaodus_zadaca_2.Entiteti;
using System;
using System.Collections.Generic;
using System.IO;

namespace kmaodus_zadaca_2.FactoryMethod
{
    public class DogadajLoader : IPodaciLoader<Dogadaj>
    {
        public Dogadaj IzdvojiPodatak(string red)
        {
            string[] podaci = red.Split(';');
            int broj;
            var minuta = podaci[1].Trim();
            int vrsta;
            var klub = podaci[3].Trim();
            var igrac = podaci[4].Trim();
            var zamjena = podaci[5].Trim();

            // TODO: dodaj provjere
            try
            {
                broj = int.Parse(podaci[0].Trim());
                vrsta = int.Parse(podaci[2].Trim());
            }
            catch (Exception)
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"Zapis sadrži neispravan tip za broj/vrstu");
                return null;
            }

            return new Dogadaj(broj, minuta, vrsta, klub, igrac, zamjena);
        }

        public List<Dogadaj> UcitajPodatke(string izvornaDatoteka)
        {
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, $"=== Ucitavanje datoteke dogadaja - {izvornaDatoteka}  ===");

            if (File.Exists(izvornaDatoteka))
            {
                List<Dogadaj> dogadaji = new List<Dogadaj>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(izvornaDatoteka);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriDogadaj_DOGADAJI_POCETAK_KRAJ_UTAKMICE(red) |
                        RegexHelper.ProvjeriDogadaj_DOGADAJI_GOL_KARTONI(red) |
                        RegexHelper.ProvjeriDogadaj_DOGADAJI_ZAMJENA_IGRACA(red))
                    {
                        dogadaji.Add(IzdvojiPodatak(red));
                    }
                    else
                    {
                        Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\t[UPOZORENJE] Preskacem red {red} --> neispravan zapis!");
                    }
                }
                return dogadaji;
            }
            else
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }
    }
}
