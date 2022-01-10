using System.ComponentModel;

namespace kmaodus_zadaca_2.Entiteti.Enums
{
    public enum OznakeDogadaja
    {
        [Description("PočetakUtakmice")]
        PočetakUtakmice = 0,

        [Description("Gol_Iz_Igre")]
        Gol_Iz_Igre = 1,

        [Description("Gol_Iz_KaznenogUdarca")]
        Gol_Iz_KaznenogUdarca = 2,

        [Description("Autogol")]
        Autogol = 3,

        [Description("ZutiKarton")]
        ZutiKarton = 10,

        [Description("CrveniKarton")]
        CrveniKarton = 11,

        [Description("ZamjenaIgraca")]
        ZamjenaIgraca = 20,

        [Description("KrajUtakmice")]
        KrajUtakmice = 99,

    }
}
