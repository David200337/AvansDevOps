﻿using Core.Domain.Sprints;

namespace Core.Domain.State
{
    public class SprintInProgress : SprintState
    {
        public override void SetCreated(Sprint sprint) => sprint.SetState(new SprintCreated());

        public override void SetInProgress(Sprint sprint) => InvalidTransition();

        public override void SetFinished(Sprint sprint) => sprint.SetState(new SprintFinished());

        public override void SetInRelease(Sprint sprint) => sprint.SetState(new SprintInRelease());

        public override void SetReleaseCancelled(Sprint sprint) => sprint.SetState(new SprintReleaseCancelled());

        public override void SetReleased(Sprint sprint) => sprint.SetState(new SprintReleased());

        public override string GetName() => "InProgress";
    }
}
