using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Alati
{
    public class ParserArgumenata
    {
        // primjer unosa -i DZ_1_igraci.csv -s DZ_1_sastavi_utakmica.csv -u DZ_1_utakmice.csv -k DZ_1_klubovi.csv -d DZ_1_dogadaji.csv

        public static string DohvatiArgument(IEnumerable<string> args, string opcija)
            => args.SkipWhile(i => i != opcija).Skip(1).Take(1).FirstOrDefault();

        public static bool ProvjeriArgumente(string[] args)
        {
            bool ispravan = true;
            string[] zastavice = {"-i", "-k", "-u", "-s", "-d" };

            foreach (string zastavica in zastavice)
            {
                if (string.IsNullOrEmpty(DohvatiArgument(args, zastavica)))
                {
                    ispravan = false;
                }
                else
                {
                    string datoteka = DohvatiArgument(args, zastavica);

                    if (!File.Exists(datoteka))
                    {
                        Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
                        Zapisnik.Ispis(Zapisnik.GRESKA, $"[GRESKA] Nije moguce pronaci datoteku --> {datoteka}");
                        Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
                        ispravan = false;
                    }
                }
            }

            return ispravan;
        }


        public Dictionary<string, string> Postavke { get; set; }


        public void UcitajPodatke(string kljuc, string vrijednost)
        {
            if (!ProvjeraNazivDatotekaPrazno(vrijednost))
            {
                switch (kljuc.Trim())
                {
                    case "-i":
                        //VrsteVozila = new VozilaLoader(vrijednost).Podaci;
                        break;
                    case "-k":
                        //Lokacije = new LokacijeLoader(vrijednost).Podaci;
                        break;
                    case "-u":
                        break;
                    case "-l":
                        break;
                    default:
                        Zapisnik.Ispis(Zapisnik.GRESKA, $"\t[Greska] U konfiguracijskoj datoteci ne postoji opcija/naredba ---> {kljuc}");
                        break;
                }
            }
        }

        public bool ProvjeraNazivDatotekaPrazno(string naziv) => string.IsNullOrEmpty(naziv);


        //public static bool ProvjeriKljučeve(Dictionary<string, string> postavke)
        //{
        //    string[] zastavice = { "klubovi", "igraci", "utakmice", "sastavi_utakmice", "dogadaji" };

        //    foreach (var z in zastavice)
        //    {
        //        if (!postavke.ContainsKey(z))
        //        {
        //            Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
        //            Zapisnik.Ispis(Zapisnik.GRESKA, $"[GRESKA] Konfiguracija nema kljuc --> {z}");
        //            Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
        //            return false;
        //        }

        //    }
        //    return true;
        //}
    }
}
