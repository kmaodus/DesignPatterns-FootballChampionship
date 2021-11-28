using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kmaodus_zadaca_1.Alati
{
    public class PodaciReader
    {
        public static List<string> ProcitajDatoteku(string file)
        {
            if (file == null)
            {
                Zapisnik.Ispis(Zapisnik.GRESKA, $"Datoteka {file} nije procitana! Ne moze biti null");
                throw new ArgumentNullException();
            }

            List<string> fileRows = File.ReadAllLines(file)
                .Select(item => item.Trim())
                .Skip(1)
                .ToList();

            return fileRows;
        }
    }
}
