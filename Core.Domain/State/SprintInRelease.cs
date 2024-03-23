using Core.Domain.Sprints;

namespace Core.Domain.State
{
    public class SprintInRelease : SprintState
    {
        public override void SetCreated(Sprint sprint) => sprint.SetState(new SprintCreated());

        public override void SetInProgress(Sprint sprint) => sprint.SetState(new SprintInProgress());

        public override void SetFinished(Sprint sprint) => sprint.SetState(new SprintFinished());

        public override void SetInRelease(Sprint sprint) => InvalidTransition();

        public override void SetReleaseCancelled(Sprint sprint) => sprint.SetState(new SprintReleaseCancelled());

        public override void SetReleased(Sprint sprint) => sprint.SetState(new SprintReleased());

        public override string GetName() => "In Release";
    }
}
