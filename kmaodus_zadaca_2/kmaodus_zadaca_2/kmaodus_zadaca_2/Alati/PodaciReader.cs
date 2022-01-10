using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kmaodus_zadaca_2.Alati
{
    public class PodaciReader
    {
        public static List<string> ProcitajDatoteku(string datoteka)
        {
            if (datoteka == null)
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"Datoteka {datoteka} nije procitana! Ne moze biti null");
                throw new ArgumentNullException();
            }

            List<string> fileRows = File.ReadAllLines(datoteka)
                .Select(item => item.Trim())
                .Skip(1)
                .ToList();

            return fileRows;
        }
    }
}
