namespace Core.Domain
{
    public interface IObserver<T>
    {
        public void Update(T subject) { }

        public void UpdateWithPreviousState(T previous, T current) { }
    }
}
