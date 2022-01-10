﻿using kmaodus_zadaca_2.Builder;
using kmaodus_zadaca_2.Entiteti;
using kmaodus_zadaca_2.Singleton;
using System.Collections.Generic;
using System.Linq;

namespace kmaodus_zadaca_2.Alati
{
    public class AktivnostManager
    {
        private static AktivnostManager _instanca;

        private List<UtakmicaPotpuno> utakmicePotpuno { get; set; } = new List<UtakmicaPotpuno>();
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
        public void Aktivnost4(string klub, int kolo)
        {
            Prvenstvo.PregledRezultataUtakmicaZaKlubNakonKola(klub, kolo);
        }
        #endregion

        public void IzvrsiAktivnosti(string unos)
        {
            int maxKolo = utakmicePotpuno.Max(x => x.Utakmica.Kolo);

            char oznaka;
            string uneseniKlub = "";
            int brojKola;

            var poljeZnakova = unos.Trim().ToCharArray();

            if (poljeZnakova.Length == 3)
            {
                oznaka = poljeZnakova[0];
                uneseniKlub = poljeZnakova[1].ToString();
                brojKola = int.Parse(poljeZnakova[2].ToString());
            }
            else if (poljeZnakova.Length == 2 && int.TryParse(poljeZnakova[1].ToString(), out brojKola))
            {
                oznaka = poljeZnakova[0];
                brojKola = int.Parse(poljeZnakova[1].ToString());
            }
            else
            {
                oznaka = poljeZnakova[0];
                //uneseniKlub = poljeZnakova[1].ToString();
                brojKola = maxKolo;
            }


            switch (oznaka)
            {
                // TODO: parametar za kolo je opcionalan! 
                case 'T':
                    Aktivnost1(brojKola);
                    break;
                case 'S':
                    Aktivnost2(brojKola);
                    break;
                case 'K':
                    Aktivnost3(brojKola);
                    break;
                case 'R': //R D 4 
                    Aktivnost4(uneseniKlub, brojKola);
                    break;
                default:
                    Zapisnik.Ispis(Zapisnik.GRESKA, $"\n[GRESKA] Neispravan unos, provjerite upisanu oznaku!");
                    break;
            }
        }
    }
}
