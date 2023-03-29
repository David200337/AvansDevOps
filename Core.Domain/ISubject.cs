namespace Core.Domain
{
    public interface ISubject<T>
    {
        void RegisterObserver(IObserver<T> observer);

        void RemoveObserver(IObserver<T> observer);

        void Notify(T subject);
    }
}
