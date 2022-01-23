using System;

namespace kmaodus_zadaca_2_ucitavanje
{
    public class Zapisnik2
    {
        public const string USPJEH = "uspjeh";
        public const string OBAVIJEST = "obavijest";
        public const string INFO = "info";
        public const string GRESKA = "greska";
        public const string UPOZORENJE = "upozorenje";

        public static void Ispis(string type, string text)
        {
            switch (type)
            {
                case USPJEH: PostaviBoju(ConsoleColor.Green); break;
                case OBAVIJEST: PostaviBoju(ConsoleColor.Blue); break;
                case INFO: PostaviBoju(ConsoleColor.White); break;
                case GRESKA: PostaviBoju(ConsoleColor.Red); break;
                case UPOZORENJE: PostaviBoju(ConsoleColor.Yellow); break;
                default: PostaviBoju(ConsoleColor.White); break;
            }

            Console.WriteLine(text);
            VratiPocetnuBoju();
        }

        public static void PostaviBoju(ConsoleColor c)
        {
            Console.ForegroundColor = c;
        }

        protected static void VratiPocetnuBoju()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
