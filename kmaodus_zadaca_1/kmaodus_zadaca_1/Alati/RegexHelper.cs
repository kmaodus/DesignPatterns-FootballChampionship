using System.Text.RegularExpressions;


namespace kmaodus_zadaca_1.Alati
{
    static class RegexHelper
    {
        const string KLUBOVI = @"^(\s*)[A-Za-z\u0106-\u01C4]{1,3}\s*(;)\s*([A-Za-z\u0106-\u01C4\-|\d{0,4}]+\s*)+(;)(\s*)([A-Za-z\u0106-\u01C4\-]+\s*){1,3}$";
        const string IGRAC = @"^(\s*)[A-Za-z\u0106-\u01C4]{1,2}\s*(;)\s*([A-Za-z\u0106-\u01C4\-]+\s*)+(;)(\s*)[A-Za-z\u0106-\u01C4]{1,3}\s*(;)\s*((\d{1,2}(\s*.\s*)\d{1,2}(\s*.\s*)\d{4}(\s*)\D *))$";
        const string UTAKMICE = @"^(\s*)\d{1,4}\s*(;)\s*\d{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)((\d{1,2}(\s*.\s*)\d{1,2}(\s*.\s*)\d{4}(\s*)\d{1,2}\s*:\s*\d{1,2} *))$";
        const string SASTAVI_UTAKMICA = @"^(\s*)\d{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*(;)([A-Za-z\u0106-\u01C4\-]+\s*)+(;)\s*[A-Za-z\u0106-\u01C4]{1,4}\s*$";
        const string DOGADAJI = @"";
        const string AKTIVNOST_1 = @"";
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
