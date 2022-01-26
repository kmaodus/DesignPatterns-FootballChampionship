using kmaodus_zadaca_2.Entiteti;

namespace kmaodus_zadaca_2.Observer
{
    public interface IObserverSubject
    {
        void Attach(IObserver iobserver);
        void Dettach(IObserver iobserver);
        void Notify(Dogadaj dogadaj);
    }
}
