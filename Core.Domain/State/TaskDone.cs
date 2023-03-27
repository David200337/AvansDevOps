namespace Core.Domain.State
{
    public class TaskDone : TaskState
    {
        public override void SetToDo(Task task) => task.SetState(new TaskTodo());
        public override void SetInProgress(Task task) => task.SetState(new TaskInProgress());
        public override void SetReadyForTesting(Task task) => task.SetState(new TaskReadyForTesting());
        public override void SetTesting(Task task) => task.SetState(new TaskTesting());
        public override void SetTested(Task task) => task.SetState(new TaskTested());
        public override void SetDone(Task task) => InvalidTransition();
        public override string GetName() => "Done";
    }
}
