using Core.Domain.Sprints;

namespace Core.Domain.State
{
    public abstract class SprintState
    {
        public abstract void SetCreated(Sprint sprint);

        public abstract void SetInProgress(Sprint sprint);

        public abstract void SetFinished(Sprint sprint);

        public abstract void SetInRelease(Sprint sprint);

        public abstract void SetReleased(Sprint sprint);

        public abstract void SetReleaseCancelled(Sprint sprint);

        public abstract string GetName();

        internal static void InvalidTransition() => throw new InvalidOperationException("Invalid state transition.");
    }
}
