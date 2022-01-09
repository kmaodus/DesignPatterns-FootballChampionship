using kmaodus_zadaca_1.Builder;
using kmaodus_zadaca_1.Entiteti;
using kmaodus_zadaca_1.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Alati
{
    public class AktivnostManager
    {
        private static AktivnostManager _instanca;
        private List<UtakmicaPotpuno> utakmicePotpuno { get; set; }
        public Prvenstvo Prvenstvo { get; set; }


        public AktivnostManager() { }
        public static AktivnostManager DajInstancu(BazaPodataka bp)
        {
            if (_instanca == null)
            {
                _instanca = new AktivnostManager(bp);
            }
            return _instanca;
        }
        private BazaPodataka _bazaPodataka { get; set; }
        public AktivnostManager(BazaPodataka baza)
        {
            _bazaPodataka = baza;
            utakmicePotpuno = new List<UtakmicaPotpuno>();

            UtakmicaPotpunoBuilder utakmicaPotpunoBuilder = new UtakmicaPotpunoBuilder();

            foreach (var utakmica in _bazaPodataka.Utakmice)
            {
                var temp = utakmicaPotpunoBuilder.KreirajUtakmicaPotpuno(_bazaPodataka, utakmica.Broj);
                utakmicePotpuno.Add(temp);
            }

            Prvenstvo = Prvenstvo.DajInstancu(utakmicePotpuno, _bazaPodataka.Klubovi, _bazaPodataka.Igraci);
        }




        #region Aktivnosti
        public void Aktivnost1(int kolo)
        {
            Prvenstvo.PregledLjestviceKlubovaNakonKola(kolo);
        }
        public void Aktivnost2(int kolo)
        {
            Prvenstvo.PregledStrijelacaNakonKola(kolo);
        }
        public void Aktivnost3(int kolo)
        {
            Prvenstvo.PregledKartonaKlubovaNakonKola(kolo);
        }
        public void Aktivnost4(char klub, int kolo)
        {
        }
        #endregion

        public void IzvrsiAktivnosti(string unos)
        {
            var poljeZnakova = unos.Trim().ToCharArray();
            var oznaka = poljeZnakova[0];
            //var broj = poljeZnakova[0];

            //string parametar1;
            //string parametar2;

            switch (oznaka)
            {
                case 'T':
                    Aktivnost1(int.Parse(poljeZnakova[1].ToString()));
                    break;
                case 'S':
                    Aktivnost2(int.Parse(poljeZnakova[1].ToString()));
                    break;
                case 'K':
                    Aktivnost3(int.Parse(poljeZnakova[1].ToString()));
                    break;
                case 'R':
                    Aktivnost4(poljeZnakova[1], poljeZnakova[2]);
                    break;
                default:
                    Zapisnik.Ispis(Zapisnik.GRESKA, $"\n[GRESKA] Neispravan unos, provjerite upisanu oznaku!");
                    break;
            }
        }
    }
}
