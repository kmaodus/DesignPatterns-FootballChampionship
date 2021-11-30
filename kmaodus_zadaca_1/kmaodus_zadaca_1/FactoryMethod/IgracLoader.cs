using kmaodus_zadaca_1.Alati;
using kmaodus_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kmaodus_zadaca_1.FactoryMethod
{
    class IgracLoader : PodaciLoaderBase<Igrac>
    {
        public IgracLoader(string datoteka) : base(datoteka) { }

        public override Igrac IzdvojiPodatak(string izvornaDatoteka)
        {
            string[] podaci = izvornaDatoteka.Split(';');
            var ID_Klub = podaci[0].Trim();
            var imePrezime = podaci[1].Trim();
            var pozicije = podaci[2].ToCharArray().Select(p => p.ToString()).ToList(); //https://stackoverflow.com/questions/27978563/how-to-convert-listchar-to-liststring-in-c


            var roden = DateTime.Parse(podaci[3].Trim());

            return new Igrac(ID_Klub, imePrezime, pozicije, roden);

        }

        public override void UcitajPodatke<TP>()
        {
            if (File.Exists(NazivDatoteke))
            {
                Zapisnik.Ispis(Zapisnik.INFO, "=== Ucitavanje datoteke DZ1_igraci.csv ===");
                List<Igrac> igrac = new List<Igrac>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(NazivDatoteke);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriIgrac(red))
                    {
                        igrac.Add(IzdvojiPodatak(red));
                    }
                    else
                    {
                        Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\t[UPOZORENJE] Preskacem {red} --> neispravan zapis!");
                    }
                }

                _podaci = igrac;
            }
            else
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku --> {NazivDatoteke} ");
                _podaci = null;
            }
        }
    }
}
