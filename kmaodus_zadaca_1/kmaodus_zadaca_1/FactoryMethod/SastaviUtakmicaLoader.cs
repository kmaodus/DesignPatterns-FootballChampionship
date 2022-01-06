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
    public class SastaviUtakmicaLoader : IPodaciLoader<SastaviUtakmica>
    {
        public SastaviUtakmica IzdvojiPodatak(string red)
        {
            string[] podaci = red.Split(';');
            var broj = int.Parse(podaci[0].Trim());
            var klub = podaci[1].Trim();
            var vrsta = podaci[2].Trim();
            var igrac = podaci[3].Trim();
            var pozicija = podaci[4].Trim();

            // TODO: dodaj provjere
            return new SastaviUtakmica(broj, klub, vrsta, igrac, pozicija);
        }

        public List<SastaviUtakmica> UcitajPodatke(string izvornaDatoteka)
        {
            Zapisnik.Ispis(Zapisnik.OBAVIJEST, $"=== Ucitavanje datoteke sastava utakmica - {izvornaDatoteka} ===");

            if (File.Exists(izvornaDatoteka))
            {
                List<SastaviUtakmica> igraci = new List<SastaviUtakmica>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(izvornaDatoteka);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriSastavUtakmice(red))
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
