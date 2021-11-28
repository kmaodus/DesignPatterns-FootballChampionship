using System.Text.RegularExpressions;


namespace kmaodus_zadaca_1.Alati
{
    static class RegexHelper
    {
        const string IGRAC = @"^(\s*)[A-Za-z\u0106-\u01C4]{1,2}\s*(;)\s*([A-Za-z\u0106-\u01C4\-]+\s*)+(;)(\s*)[A-Za-z\u0106-\u01C4]{1,3}\s*(;)\s*((\d{1,2}(\s*.\s*)\d{1,2}(\s*.\s*)\d{4}(\s*)\D *))$";
        const string DOGADAJI = @"^(\d{1,});\s([A-Za-z\u0106-\u01C4\d\.] ?)+(;\s)([A-Za-z\u0106-\u01C4\d.] ?)+(,\s)(\d{4,})? ?([A-Za-z\u0106-\u01C4.])+(;\s)(\d)+(.)(\d)+(,\s?)(\d)+(.)(\d)+$";
        const string KLUBOVI = @"^([\d]+)(;)(\s*)([\d]+(,|.)\d{1,})(;)(\s*)([\d]+(,|.)\d{1,})(;)(\s*)([\d]+(,|.)\d{1,})$";
        const string SASTAVI_UTAKMICA = @"^(\d+)(;)\s*(\d+)(;)\s*(\d+)(;)\s*(\d+)$";
        const string UTAKMICE = @"^\d{1,}(;)\s{0,1}([A-Za-z\u0106-\u01C4]{2,25})(\s?)([A-Za-z\u0106-\u01C4]{2,25})?(\s?)?([A-Za-z\u0106-\u01C4]{2,25})(;)\s{0,1}(\d+)$";
        const string AKTIVNOST_1 = @"^([1-4]);\s*„?""?\d{4}-\d{2}-\d{2}\s+(\d{2}:){2}\d{2}“?""?\s*(;\s*\d*\s*){3,}(;.*[^;])?$";
        const string AKTIVNOST_2 = @"^(5); *.*$";
        const string AKTIVNOST_3 = @"^([6]);\s*(stanje|struktura)\s*(stanje|struktura)*\s*(\d{1,3})?$";
        const string AKTIVNOST_4 = @"^([7]);( *(najam|struktura|zarada)){1,3}( +(\d{2}.\d{2}.\d{4} *){2})(\d{1,4})?$";

        public static bool ProvjeriIgrac(string unos)
        {
            Match m = Regex.Match(unos, IGRAC);
            return m.Success;
        }

        public static bool ProvjeriDogadaj(string unos)
        {
            Match m = Regex.Match(unos, DOGADAJI);
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

    }
}
