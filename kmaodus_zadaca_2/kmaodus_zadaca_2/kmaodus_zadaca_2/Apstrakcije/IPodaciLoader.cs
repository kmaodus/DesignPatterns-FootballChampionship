using System.Collections.Generic;

namespace kmaodus_zadaca_2.Apstrakcije
{
    public interface IPodaciLoader<T>
    {
        List<T> UcitajPodatke(List<string> redoviDatoteke);
        T IzdvojiPodatak(string red);
    }
}
