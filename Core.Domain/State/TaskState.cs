namespace Core.Domain.State
{
    public abstract class TaskState
    {
        public abstract void SetToDo(Task task);

        public abstract void SetInProgress(Task task);

        public abstract void SetReadyForTesting(Task task);

        public abstract void SetTesting(Task task);

        public abstract void SetTested(Task task);

        public abstract void SetDone(Task task);

        public abstract string GetName();

        internal static void InvalidTransition() => throw new InvalidOperationException("Invalid state transition.");
    }
}