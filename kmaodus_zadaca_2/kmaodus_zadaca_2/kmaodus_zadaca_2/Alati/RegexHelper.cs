using System.Text.RegularExpressions;

namespace kmaodus_zadaca_2.Alati
{
    static class RegexHelper
    {
        const string KLUBOVI = @"^(\s*)[A-Za-z\u0106-\u01C4]{1,3}\s*(;)\s*([A-Za-z\u0106-\u01C4\-|\d{0,4}]+\s*)+(;)(\s*)([A-Za-zäëöüÄÖÜß\u0106-\u01C4\-]+\s*){1,3}$";
        const string IGRAC = @"^(\s*)[A-Za-z\u0106-\u01C4]{1,2}\s*(;)\s*([A-Za-zäëöüÄÖÜß\u0106-\u01C4\-]+\s*)+(;)(\s*)[A-Za-z\u0106-\u01C4]{1,3}\s*(;)\s*((\d{1,2}(\s*\.\s*)\d{1,2}(\s*.\s*)\d{4}.?(\s*)))$";
        const string UTAKMICE = @"^(\s*)\d{1,4}\s*(;)\s*\d{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)((\d{1,2}(\s*.\s*)\d{1,2}(\s*.\s*)\d{4}(\s*)\d{1,2}\s*:\s*\d{1,2} *))$";
        const string SASTAVI_UTAKMICA = @"^(\s*)\d{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)([A-Za-zäëöüÄÖÜß\u0106-\u01C4\-]+\s*)+(;)\s*[A-Za-zäëöüÄÖÜß\u0106-\u01C4]{1,4}\s*$";
        const string DOGADAJI_POCETAK_KRAJ_UTAKMICE = @"^(\s*)\d{1,4}\s*(;)(\s*)\d{1,4}(\+\d{1,2})?\s*(;)(\s*)[0-99]{1,2}\s*(;)(\s|;)*$";
        const string DOGADAJI_GOL_KARTONI = @"^(\s*)\d{1,4}(\s*)(;)(\s*)\d{1,4}(\+\d{1,2})?(\s*)(;)(\s*)(1|2|3|10|11)(\s*)(;)(\s*)[A-Za-z\u0106-\u01C4]{1,2}(\s*)(;)\s*([A-Za-zäëöüÄÖÜß\u0106-\u01C4\-]+\s*)+(\s|;)*$";
        const string DOGADAJI_ZAMJENA_IGRACA = @"^(\s*)\d{1,4}(\s*)(;)(\s*)\d{1,4}(\+\d{1,2})?(\s*)(;)(\s*)\d[20](\s*)(;)(\s*)[A-Za-z\u0106-\u01C4]{1,2}(\s*)(;)\s*([A-Za-zäëöüÄÖÜß\u0106-\u01C4\-]+\s*)+(;)\s*([A-Za-zäëöüÄÖÜß\u0106-\u01C4\-]+\s*)+(\s|;)*$";
        const string AKTIVNOST_1 = @"^(\s*)[tT]{1}(\s*)\d+(\s*)$";
        const string AKTIVNOST_2 = @"^(\s*)[sS]{1}(\s*)\d+(\s*)$";
        const string AKTIVNOST_3 = @"^(\s*)[kK]{1}(\s*)\d+(\s*)$";
        const string AKTIVNOST_4 = @"^(\s*)[rR]{1}(\s*)[A-Za-z\u0106-\u01C4]{1,3}(\s*)\d+(\s*)$";
        const string AKTIVNOST_5 = @"";
        const string AKTIVNOST_NU = @"";
        const string AKTIVNOST_NS = @"";
        const string AKTIVNOST_ND = @"";

        public static bool ProvjeriAktivnost_NU(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_NU);
            return m.Success;
        }
        public static bool ProvjeriAktivnost_NS(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_NS);
            return m.Success;
        }
        public static bool ProvjeriAktivnost_ND(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_ND);
            return m.Success;
        }
        public static bool ProvjeriIgrac(string unos)
        {
            Match m = Regex.Match(unos, IGRAC);
            return m.Success;
        }
        public static bool ProvjeriDogadaj_DOGADAJI_POCETAK_KRAJ_UTAKMICE(string unos)
        {
            Match m = Regex.Match(unos, DOGADAJI_POCETAK_KRAJ_UTAKMICE);
            return m.Success;
        }
        public static bool ProvjeriDogadaj_DOGADAJI_GOL_KARTONI(string unos)
        {
            Match m = Regex.Match(unos, DOGADAJI_GOL_KARTONI);
            return m.Success;
        }
        public static bool ProvjeriDogadaj_DOGADAJI_ZAMJENA_IGRACA(string unos)
        {
            Match m = Regex.Match(unos, DOGADAJI_ZAMJENA_IGRACA);
            return m.Success;
        }
        public static bool ProvjeriKlub(string unos)
        {
            Match m = Regex.Match(unos, KLUBOVI);
            return m.Success;
        }
        public static bool ProvjeriSastavUtakmice(string unos)
        {
            Match m = Regex.Match(unos, SASTAVI_UTAKMICA);
            return m.Success;
        }
        public static bool ProvjeriUtakmicu(string unos)
        {
            Match m = Regex.Match(unos, UTAKMICE);
            return m.Success;
        }
        public static bool ProvjeriAktivnost1(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_1);
            return m.Success;
        }
        public static bool ProvjeriAktivnost2(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_2);
            return m.Success;
        }
        public static bool ProvjeriAktivnost3(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_3);
            return m.Success;
        }
        public static bool ProvjeriAktivnost4(string unos)
        {
            Match m = Regex.Match(unos, AKTIVNOST_4);
            return m.Success;
        }
    }
}
