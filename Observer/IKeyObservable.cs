using System;
namespace Observer
{
    public interface IKeyObservable<Key, out T>
    {
        IDisposable Subscribe(Key key, IObserver<T> observer);
    }
}