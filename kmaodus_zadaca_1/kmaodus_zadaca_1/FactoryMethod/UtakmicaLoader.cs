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
    public class UtakmicaLoader : IPodaciLoader<Utakmica>
    {
        public Utakmica IzdvojiPodatak(string red)
        {
            string[] podaci = red.Split(';');
            int broj = int.Parse(podaci[0].Trim());
            int kolo = int.Parse(podaci[1].Trim());
            string id_domacin = podaci[2].Trim();
            string id_gost = podaci[3].Trim();
            DateTime.TryParse(podaci[4].Trim().ToString(), out DateTime pocetak);

            // TODO: dodaj provjere
            return new Utakmica(broj, kolo, id_domacin, id_gost, pocetak);
        }

        public List<Utakmica> UcitajPodatke(string izvornaDatoteka)
        {
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, "=== Ucitavanje datoteke DZ1_utakmice.csv ===");

            if (File.Exists(izvornaDatoteka))
            {
                List<Utakmica> igraci = new List<Utakmica>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(izvornaDatoteka);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriIgrac(red))
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
