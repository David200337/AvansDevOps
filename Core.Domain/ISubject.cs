namespace Core.Domain
{
    public interface ISubject<T>
    {
        public void RegisterObserver(IObserver<T> observer);

        public void RemoveObserver(IObserver<T> observer);

        public void Notify(T subject) { }

        public void NotifyWithPreviousState(T previous, T current) { }
    }
}
