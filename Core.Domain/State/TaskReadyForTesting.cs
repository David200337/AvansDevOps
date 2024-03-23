﻿namespace Core.Domain.State
{
    public class TaskReadyForTesting : TaskState
    {
        public override void SetToDo(Task task) => task.SetState(new TaskToDo());

        public override void SetInProgress(Task task) => task.SetState(new TaskInProgress());

        public override void SetReadyForTesting(Task task) => InvalidTransition();

        public override void SetTesting(Task task) => task.SetState(new TaskTesting());

        public override void SetTested(Task task) => task.SetState(new TaskTested());

        public override void SetDone(Task task) => task.SetState(new TaskDone());

        public override string GetName() => "Ready for Testing";
    }
}
