using kmaodus_zadaca_1.Entiteti;
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
        public UtakmicaPotpunoBuilder() { }

        public UtakmicaPotpuno KreirajUtakmicaPotpuno(BazaPodataka bazaPodataka, int brojUtakmice)
        {
            UtakmicaPotpuno utakmicaPotpuno = new UtakmicaPotpuno();
            utakmicaPotpuno.Utakmica = bazaPodataka.Utakmice.Where(x => x.Broj == brojUtakmice).FirstOrDefault();

            Sastav sastavDomacin = new Sastav();
            Sastav sastavGost = new Sastav();

            sastavDomacin.Klub = bazaPodataka.Klubovi.Where(x => x.ID_Klub == utakmicaPotpuno.Utakmica.ID_Domacin).FirstOrDefault();
            sastavGost.Klub = bazaPodataka.Klubovi.Where(x => x.ID_Klub == utakmicaPotpuno.Utakmica.ID_Gost).FirstOrDefault();

            utakmicaPotpuno.KlubDomacin = sastavDomacin;
            utakmicaPotpuno.KlubGost = sastavGost;

            foreach (var zapis in bazaPodataka.SastaviUtakmica)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubDomacin.Klub.ID_Klub)
                {
                    sastavDomacin.Igraci.Add(bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac).FirstOrDefault());
                }
            }

            foreach (var zapis in bazaPodataka.SastaviUtakmica)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj && zapis.Klub == utakmicaPotpuno.KlubGost.Klub.ID_Klub)
                {
                    sastavGost.Igraci.Add(bazaPodataka.Igraci.Where(x => x.ID_Klub == zapis.Klub && x.ImePrezime == zapis.Igrac).FirstOrDefault());
                }
            }

            // dogadaji
            foreach (var zapis in bazaPodataka.Dogadaji)
            {
                if (zapis.Broj == utakmicaPotpuno.Utakmica.Broj)
                {
                    utakmicaPotpuno.Dogadaji.Add(zapis);
                }
            }

            return utakmicaPotpuno;
        }


        //metoda za postavljanje - bez dupliciranja koda
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
