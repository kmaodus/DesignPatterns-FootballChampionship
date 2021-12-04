﻿using kmaodus_zadaca_1.Entiteti;
using kmaodus_zadaca_1.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kmaodus_zadaca_1.Builder
{
    public class UtakmicaPotpunoBuilder
    {
        public UtakmicaPotpuno KreirajUtakmicaPotpuno(BazaPodataka bazaPodataka, int brojUtakmice)
        {
            UtakmicaPotpuno utakmicaPotpuno = new UtakmicaPotpuno();
            utakmicaPotpuno.Utakmica = (Utakmica)bazaPodataka.Utakmice.Where(x => x.Broj == brojUtakmice);

            Sastav sastavDomacin = new Sastav();
            Sastav sastavGost = new Sastav();

            sastavDomacin.Klub = (Klub)bazaPodataka.Klubovi.Where(x => x.ID_Klub == utakmicaPotpuno.Utakmica.ID_Domacin);
            sastavGost.Klub = (Klub)bazaPodataka.Klubovi.Where(x => x.ID_Klub == utakmicaPotpuno.Utakmica.ID_Gost);


            foreach (var zapis in bazaPodataka.SastaviUtakmica)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubDomacin.Klub.ID_Klub)
                {
                    sastavDomacin.Igraci.Add((Igrac)bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac));
                }
            }

            foreach (var zapis in bazaPodataka.SastaviUtakmica)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubDomacin.Klub.ID_Klub)
                {
                    sastavGost.Igraci.Add((Igrac)bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac));
                }
            }

            return null;
        }


        // metoda za postavljanje - bez duplciiranja koda
        //public KreirajSastavKluba(BazaPodataka bazaPodataka, Sastav sastavKluba)
        //{
        //    foreach (var zapis in bazaPodataka.SastaviUtakmica)
        //    {
        //        if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubDomacin.Klub.ID_Klub)
        //        {
        //            sastavKluba.Igraci.Add((Igrac)bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac));
        //        }
        //    }
        //}

    }
}