using Core.Domain.State;

namespace Core.Domain
{
    public class BacklogItem : Stateful<BacklogItemState>, ISubject<BacklogItem>
    {
        private string _id;

        private string _title;

        private string _description;

        private User? _assignee;

        private List<Task> _tasks;

        private UserRoleManager _userRoleManager;

        private List<IObserver<BacklogItem>> _observers;

        public BacklogItem(string id, string title, string description, User assignee) : base(new BacklogItemToDo())
        {
            _id = id;
            _title = title;
            _description = description;
            _assignee = assignee;
            _tasks = new List<Task>();
            _userRoleManager = new UserRoleManager();
            _observers = new List<IObserver<BacklogItem>>();
        }

        // Properties
        public string Id => _id;

        public string Title => _title;

        public string Description => _description;

        public User? Assignee => _assignee;

        public List<Task> Tasks => _tasks;

        // State transitions
        public void SetToDo() => State.SetToDo(this);

        public void SetInProgress() => State.SetInProgress(this);

        public void SetReadyForTesting()
        {
            State.SetReadyForTesting(this);

            // Notify the testers that the item is ready for testing.
            Notify(this);
        }

        public void SetTesting() => State.SetTesting(this);

        public void SetTested() => State.SetTested(this);

        public void SetDone()
        {
            // A backlog item's state should only be allowed to be set to done
            // when its correspoding tasks are done.
            if (!AreTasksDone()) return;

            State.SetDone(this);
        }

        // Observer pattern
        public void RegisterObserver(IObserver<BacklogItem> observer) => _observers.Add(observer);

        public void RemoveObserver(IObserver<BacklogItem> observer) => _observers.Remove(observer);

        public void Notify(BacklogItem backlogItem) => _observers.ForEach(o => o.Update(backlogItem));

        // Methods
        public void AddAssignee(User assignee) => _assignee = assignee;

        public void RemoveAssignee() => _assignee = null;

        public void AddTask(Task task) => _tasks.Add(task);

        public void RemoveTask(Task task) => _tasks.Remove(task);

        public void AddTester(User tester) => _userRoleManager.AddUserToRole(tester, Role.Tester);

        public void RemoveTester(User tester) => _userRoleManager.RemoveUserFromRole(tester, Role.Tester);

        public List<User> GetTesters() => _userRoleManager.GetUsersByRole(Role.Tester);

        public bool AreTasksDone() => _tasks.All(t => t.State is TaskDone);
    }
}
