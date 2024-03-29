﻿namespace Core.Domain.State
{
    public class BacklogItemInProgress : BacklogItemState
    {
        public override void SetToDo(BacklogItem item) => item.SetState(new BacklogItemToDo());

        public override void SetInProgress(BacklogItem item) => InvalidTransition();

        public override void SetReadyForTesting(BacklogItem item) => item.SetState(new BacklogItemReadyForTesting());

        public override void SetTesting(BacklogItem item) => item.SetState(new BacklogItemTesting());

        public override void SetTested(BacklogItem item) => item.SetState(new BacklogItemTested());

        public override void SetDone(BacklogItem item) => item.SetState(new BacklogItemDone());

        public override string GetName() => "In Progress";
    }
}
