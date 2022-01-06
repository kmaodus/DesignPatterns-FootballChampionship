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
        //public IgracLoader(string datoteka) : base(datoteka) { }

        //public override Igrac IzdvojiPodatak(string izvornaDatoteka)
        //{
        //    string[] podaci = izvornaDatoteka.Split(';');
        //    var ID_Klub = podaci[0].Trim();
        //    var imePrezime = podaci[1].Trim();
        //    var pozicije = podaci[2].ToCharArray().Select(p => p.ToString()).ToList(); //https://stackoverflow.com/questions/27978563/how-to-convert-listchar-to-liststring-in-c


        //    var roden = DateTime.Parse(podaci[3].Trim());

        //    return new Igrac(ID_Klub, imePrezime, pozicije, roden);

        //}

        //public override void UcitajPodatke<TP>()
        //{
        //    if (File.Exists(NazivDatoteke))
        //    {
        //        Zapisnik.Ispis(Zapisnik.INFO, "=== Ucitavanje datoteke DZ1_igraci.csv ===");
        //        List<Igrac> igrac = new List<Igrac>();
        //        List<string> redoviDatoteke = PodaciReader.ProcitajDatoteku(NazivDatoteke);

        //        foreach (string red in redoviDatoteke)
        //        {
        //            if (RegexHelper.ProvjeriIgrac(red))
        //            {
        //                igrac.Add(IzdvojiPodatak(red));
        //            }
        //            else
        //            {
        //                Zapisnik.Ispis(Zapisnik.UPOZORENJE, $"\t[UPOZORENJE] Preskacem {red} --> neispravan zapis!");
        //            }
        //        }

        //        _podaci = igrac;
        //    }
        //    else
        //    {
        //        Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] Ne mogu otvoriti datoteku --> {NazivDatoteke} ");
        //        _podaci = null;
        //    }
        //}



        public Igrac IzdvojiPodatak(string red)
        {
            string[] podaci = red.Split(';');
            var klub = podaci[0].Trim();
            var igrac = podaci[1].Trim();
            var pozicije = new List<string>(podaci[2].Trim().Split(','));
            DateTime.TryParse(podaci[3].Trim().ToString(), out DateTime datumRodena);

            // TODO: dodaj provjere
            return new Igrac(klub, igrac, pozicije, datumRodena);

        }

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
