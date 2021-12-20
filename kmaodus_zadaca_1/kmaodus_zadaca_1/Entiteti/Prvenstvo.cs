using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Entiteti
{
    public class Prvenstvo
    {
        private static Prvenstvo _instanca;

        public List<UtakmicaPotpuno> UtakmicePotpuno { get; set; }
        private List<StanjeKlubaNaLjestvici> ListaStanjeKlubaNaLjestvici { get; set; }
        private List<StanjeStrijelacaNaLjestvici> ListaStanjeStrijelacaNaLjestvici { get; set; }
        private List<StanjeKartonaNaLjestvici> ListaStanjaNaLjestvici { get; set; }




        private Prvenstvo(List<UtakmicaPotpuno> utakmicePotpuno)
        {
            UtakmicePotpuno = utakmicePotpuno;
        }
        public static Prvenstvo DajInstancu()
        {
            if (_instanca == null)
            {
                _instanca = new Prvenstvo();
            }
            return _instanca;
        }


        //metoda za brisanje stijelaca
        //public void blabla(){}

        //metoda za dohvat lista
        public List<StanjeKlubaNaLjestvici> DohvatiStanjeKlubovaNakonKola(List<Klub> listaKlubova)
        {
            List<StanjeKlubaNaLjestvici> stanjeKlubovaNaLjestvici;
            
            foreach (var klub in listaKlubova)
            {
                StanjeKlubaNaLjestvici stanjeKlubaNaLjestvici = new StanjeKlubaNaLjestvici();

                foreach (var utakmica in UtakmicePotpuno)
                {
                    if (utakmica.KlubDomacin == klub || utakmica.KlubGost == klub)
                    {
                        // utakmicaPotpuno - iz nje sve


                    }
                }
            }
        }
    }
}
