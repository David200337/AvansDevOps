namespace Core.Domain.State
{
    public abstract class Stateful<T>
    {
        private T _state;

        protected Stateful(T initialState) => _state = initialState;

        public T State => _state;

        internal virtual void SetState(T state) => _state = state;
    }
}