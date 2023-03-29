﻿namespace Core.Domain.State
{
    public class SprintCreated : SprintState
    {
        public override void SetCreated(Sprint sprint) => InvalidTransition();

        public override void SetInProgress(Sprint sprint) => sprint.SetState(new SprintInProgress());

        public override void SetFinished(Sprint sprint) => sprint.SetState(new SprintFinished());

        public override void SetInRelease(Sprint sprint) => sprint.SetState(new SprintInRelease());

        public override void SetReleaseCancelled(Sprint sprint) => sprint.SetState(new SprintReleaseCancelled());

        public override void SetReleased(Sprint sprint) => sprint.SetState(new SprintReleased());

        public override string GetName() => "Created";
    }
}
