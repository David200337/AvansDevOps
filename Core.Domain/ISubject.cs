namespace Core.Domain
{
    public interface ISubject<T>
    {
        void RegisterObserver(Role role, IObserver<T> observer);

        void RemoveObserver(Role role, IObserver<T> observer);

        void Notify(Role role, T subject);
    }
}
