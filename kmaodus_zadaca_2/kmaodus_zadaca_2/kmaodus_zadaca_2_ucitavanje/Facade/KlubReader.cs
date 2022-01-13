using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kmaodus_zadaca_2_ucitavanje.Facade
{
    public class KlubReader : IReader
    {
        public List<string> DohvatiSve(string izvornaDatoteka)
        {
            if (File.Exists(izvornaDatoteka))
            {
                List<string> fileRows = File.ReadAllLines(izvornaDatoteka)
                    .Select(item => item.Trim())
                    .Skip(1)
                    .ToList();

                return fileRows;
            }
            else
            {
                Console.WriteLine($"\t[Greska] Ne mogu otvoriti datoteku / datoteka ne postoji --> {izvornaDatoteka} ");
                return new List<string>();
            }
        }
    }
}
