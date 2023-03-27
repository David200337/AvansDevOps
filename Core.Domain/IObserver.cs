namespace Core.Domain
{
    public interface IObserver<T>
    {
        // TODO: Consider if the role is required to pass.
        void Update(Role role, ISubject<T> subject);
    }
}
