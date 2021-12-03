using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class Aktivnost
    {
        //npr. T5, S5
        public string KodAktivnosti { get; set; }
        public Aktivnost() { }

        public Aktivnost(string naredba)
        {
            string[] argumenti = naredba.Split(' ').First();

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
