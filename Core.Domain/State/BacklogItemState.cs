namespace Core.Domain.States
{
    public abstract class BacklogItemState
    {
        public abstract void SetToDo(BacklogItem item);

        public abstract void SetInProgress(BacklogItem item);

        public abstract void SetReadyForTesting(BacklogItem item);

        public abstract void SetTesting(BacklogItem item);

        public abstract void SetTested(BacklogItem item);

        public abstract void SetDone(BacklogItem item);

        public abstract string GetName();

        internal static void InvalidTransition() => throw new InvalidOperationException("Invalid state transition.");
    }
}
