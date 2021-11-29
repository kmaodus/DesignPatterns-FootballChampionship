using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Alati
{
    static class ParserArgumenata
    {
        public static string DohvatiArgument(IEnumerable<string> args, string opcija)
            => args.SkipWhile(i => i != opcija).Skip(1).Take(1).FirstOrDefault();

        public static bool ProvjeriArgumente(string[] args)
        {
            bool ispravan = true;
            string[] zastavice = { "-k", "-i", "-u", "-s", "-d" };

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

        public static bool ProvjeriKljučeve(Dictionary<string, string> postavke)
        {
            string[] zastavice = { "klubovi", "igraci", "utakmice", "sastavi_utakmice", "dogadaji" };

            foreach (var z in zastavice)
            {
                if (!postavke.ContainsKey(z))
                {
                    Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
                    Zapisnik.Ispis(Zapisnik.GRESKA, $"[GRESKA] Konfiguracija nema kljuc --> {z}");
                    Zapisnik.Ispis(Zapisnik.GRESKA, new string('=', 100));
                    return false;
                }

            }
            return true;
        }
    }
}
