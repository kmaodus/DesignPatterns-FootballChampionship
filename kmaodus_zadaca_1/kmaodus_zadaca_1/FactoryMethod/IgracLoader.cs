using kmaodus_zadaca_1.Alati;
using kmaodus_zadaca_1.Apstrakcije;
using kmaodus_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.IO;

namespace kmaodus_zadaca_1.FactoryMethod
{
    public class IgracLoader : IPodaciLoader<Igrac>
    {
        public List<Igrac> UcitajPodatke(string izvornaDatoteka)
        {
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, $"=== Ucitavanje datoteke igraca - {izvornaDatoteka} ===");

            if (File.Exists(izvornaDatoteka))
            {
                List<Igrac> igraci = new List<Igrac>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(izvornaDatoteka);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriIgrac(red))
                    {
                        igraci.Add(IzdvojiPodatak(red));
                    }
                    else
                    {
                        // TODO: dodaj provjere
                        Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\t[UPOZORENJE] Preskacem red {red} --> neispravan zapis!");
                    }
                }
                return igraci;
            }
            else
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return null;
            }
        }

        public Igrac IzdvojiPodatak(string red)
        {
            string[] podaci = red.Split(';');
            var klub = podaci[0].Trim();
            var igrac = podaci[1].Trim();
            var pozicije = new List<string>(podaci[2].Trim().Split(','));
            DateTime.TryParse(podaci[3].Trim().ToString(), out DateTime datumRodena);

            return new Igrac(klub, igrac, pozicije, datumRodena);
        }
    }
}
