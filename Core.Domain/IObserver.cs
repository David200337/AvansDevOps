namespace Core.Domain
{
    public interface IObserver<T>
    {
        void Update(T subject);
    }
}
