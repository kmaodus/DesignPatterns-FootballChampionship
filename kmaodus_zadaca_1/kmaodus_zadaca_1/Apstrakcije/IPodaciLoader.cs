using System.Collections.Generic;

namespace kmaodus_zadaca_1.Apstrakcije
{
    public interface IPodaciLoader<T>
    {
        List<T> UcitajPodatke(string izvornaDatoteka);
        T IzdvojiPodatak(string red);
    }
}
