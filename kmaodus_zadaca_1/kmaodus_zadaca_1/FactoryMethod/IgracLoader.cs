using kmaodus_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.FactoryMethod
{
    class IgracLoader : PodaciLoaderBase<Igrac>
    {
        public IgracLoader(string datoteka) : base(datoteka) { }

        public override Igrac IzdvojiPodatak(string izvornaDatoteka)
        {
            string[] podaci = izvornaDatoteka.Split(";");
            var ID_Klub = int.Parse(podaci[0].Trim());
            var imePrezime = float.Parse(podaci[1].Trim());
            var pozicije = podaci[2].Trim().ToList();
            var roden = DateTime.Parse(podaci[3].Trim());

            return new Igrac(ID_Klub, imePrezime, pozicije, roden);

        }

        public override void UcitajPodatke<TP>()
        {
            if (File.Exists(NazivDatoteke))
            {
                Zapisnik.Ispis(Zapisnik.INFO, "=== Ucitavanje datoteke DZ_3_osobe.txt ===");
                List<Osoba> osobe = new List<Osoba>();
                List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(NazivDatoteke);

                foreach (string red in redoviDatoteke)
                {
                    if (RegexHelper.ProvjeriOsobe(red))
                    {
                        osobe.Add(IzdvojiPodatak(red));
                    }
                    else
                    {
                        Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\t[UPOZORENJE] Preskacem {red} --> neispravan zapis!");
                    }
                }

                _podaci = osobe;
            }
            else
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku --> {NazivDatoteke} ");
                _podaci = null;
            }
        }
    }
}
