using kmaodus_zadaca_2.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_2.Decorator
{
    class PregledLjestviceDecorator : Decorator
    {
        public PregledLjestviceDecorator(IKomponenta c) : base(c) { }

        public override void Prikazi()
        {
            //TODO sutra: provjeri kako castati listu  
            //if (this.listaKomponenata.GetType() == typeof(List<StanjeKlubaNaLjestvici>))
            //{
            //    List<StanjeKlubaNaLjestvici> t = (List<StanjeKlubaNaLjestvici>)listaKomponenata;
            //    DecorateStanjeKlubaNaLjestvici(t);
            //}

            base.Prikazi();
        }

        private void DecorateStanjeKlubaNaLjestvici(List<StanjeKlubaNaLjestvici> t)
        {
            foreach (var klub in t)
            {
                Console.WriteLine(String.Format("| {0, -20} | {1, -19} | {2, -8} | {3, -10} | {4, -5} | {5, -11} | {6, -16} | {7, -14} | {8, -19} |",
                    klub.Klub.Naziv, klub.BrojOdigranihKola, klub.BrojPobjeda, klub.BrojNeriješenih, klub.BrojPoraza, klub.BrojDanihGolova,
                    klub.BrojPrimljenihGolova, klub.RazlikaGolova, klub.BrojBodova));
                Console.WriteLine(new string('-', SIRINA_TABLICE));
            }

        }
    }
}
