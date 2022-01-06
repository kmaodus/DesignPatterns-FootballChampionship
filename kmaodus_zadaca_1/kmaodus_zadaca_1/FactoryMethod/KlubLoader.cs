using kmaodus_zadaca_1.Alati;
using kmaodus_zadaca_1.Apstrakcije;
using kmaodus_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.FactoryMethod
{
    public class KlubLoader : IPodaciLoader<Klub>
    {
        public Klub IzdvojiPodatak(string red)
        {
            string[] podaci = red.Split(';');
            var idKlub = podaci[0].Trim();
            var naziv = podaci[1].Trim();
            var trener = podaci[2].Trim();

            // TODO: dodaj provjere
            return new Klub(idKlub, naziv, trener);
        }

        public List<Klub> UcitajPodatke(string izvornaDatoteka)
        {
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, $"=== Ucitavanje datoteke klubova - {izvornaDatoteka} ===");

            if (File.Exists(izvornaDatoteka))
            {
                List<Klub> igraci = new List<Klub>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(izvornaDatoteka);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriKlub(red))
                    {
                        igraci.Add(IzdvojiPodatak(red));
                    }
                    else
                    {
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
    }
}
