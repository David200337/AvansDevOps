namespace Core.Domain
{
    public interface IObserver<in T>
    {
        public void Update(T subject) { }

        public void UpdateWithPreviousState(T previous, T current) { }
    }
}
