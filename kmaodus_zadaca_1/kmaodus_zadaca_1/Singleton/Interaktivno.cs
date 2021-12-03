using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Singleton
{
    public sealed class Interaktivno
    {
        private static readonly Interaktivno _singleton = new Interaktivno();
        private Interaktivno() { }
        public static Interaktivno GetInstance() => _singleton;

        static bool kraj = false;
        public void UcitajLinije()
        {
            kraj = false;
            while (!kraj)
            {
                string unosKorisnika = Console.ReadLine();
                ObradiUnos(unosKorisnika);
            }
        }

        private void ObradiUnos(string unos)
        {
            unos = unos.Replace("„", "").Replace("“", "").Replace(",", "").Replace("\"", "");
            Console.WriteLine($"Upisali ste --> {unos}");

            Aktivnost aktivnost = NapraviAktivnost(unos);
            IzvrsiAktivnost.Izvrsi(aktivnost);
        }


        private Aktivnost NapraviAktivnost(string unos)
        {

        }

    }
}
