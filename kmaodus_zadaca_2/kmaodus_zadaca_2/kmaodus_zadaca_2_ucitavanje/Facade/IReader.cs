using System.Collections.Generic;

namespace kmaodus_zadaca_2_ucitavanje.Facade
{
    public interface IReader
    {
        List<string> DohvatiSve(string datoteka);
    }
}
