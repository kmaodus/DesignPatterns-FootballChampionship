using System.ComponentModel;

namespace kmaodus_zadaca_2.Entiteti.Enums
{
    public enum PozicijeIgraca
    {
        [Description("G")]
        Golman = 1,

        [Description("B")]
        Branic = 2,

        [Description("V")]
        Vezni = 3,

        [Description("N")]
        Napadac = 4,

        [Description("LB")]
        LijeviBranic = 5,

        [Description("DB")]
        DesniBranic = 6,

        [Description("CB")]
        CentralniBranic = 7,

        [Description("LDV")]
        LijeviDefanzivniVezni = 7,

        [Description("DDV")]
        DesniDefanzivniVezni = 9,

        [Description("CDV")]
        CentralniDefanzivniVezni = 10,

        [Description("LV")]
        LijeviVezni = 11,

        [Description("CV")]
        CentralniVezni = 12,

        [Description("DV")]
        DesniVezni = 13,

        [Description("LOV")]
        LijeviOfenzivniVezni = 14,

        [Description("COV")]
        CentralniOfenzivniVezni = 15,

        [Description("DOV")]
        DesniOfenzivniVezni = 16,

        [Description("LN")]
        LijeviNapadac = 17,

        [Description("CN")]
        CentralniNapadac = 18,

        [Description("DN")]
        DesniNapadac = 19,
    }
}
