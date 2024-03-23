using Core.Domain.Roles;
using Core.Domain.State;

namespace Core.Domain
{
    public class BacklogItem : Stateful<BacklogItemState>, ISubject<BacklogItem>
    {
        private readonly string _id;

        private readonly string _title;

        private readonly string _description;

        private User? _assignee;

        private readonly List<Task> _tasks;

        private readonly List<Tester> _testers;

        private readonly List<IObserver<BacklogItem>> _observers;

        public BacklogItem(string id, string title, string description) : base(new BacklogItemToDo())
        {
            _id = id;
            _title = title;
            _description = description;
            _tasks = new List<Task>();
            _testers = new List<Tester>();
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

        public void SetInProgress()
        {
            var previous = ShallowCopy();
            State.SetInProgress(this);
            NotifyWithPreviousState(previous, this);
        }

        public void SetReadyForTesting()
        {
            var previous = ShallowCopy();
            State.SetReadyForTesting(this);
            NotifyWithPreviousState(previous, this);
        }

        public void SetTesting()
        {
            var previous = ShallowCopy();
            State.SetTesting(this);
            NotifyWithPreviousState(previous, this);
        }

        public void SetTested()
        {
            var previous = ShallowCopy();
            State.SetTested(this);
            NotifyWithPreviousState(previous, this);
        }

        public void SetDone()
        {
            // A backlog item's state should only be allowed to be set to done
            // when its corresponding tasks are done.
            if (!AreTasksDone()) throw new InvalidOperationException("Associated tasks are not done.");

            var previous = ShallowCopy();
            State.SetDone(this);
            NotifyWithPreviousState(previous, this);
        }

        // Observer pattern
        public void RegisterObserver(IObserver<BacklogItem> observer) => _observers.Add(observer);

        public void RemoveObserver(IObserver<BacklogItem> observer) => _observers.Remove(observer);

        public void NotifyWithPreviousState(BacklogItem previous, BacklogItem current) => _observers.ForEach(o => o.UpdateWithPreviousState(previous, current));

        // Methods
        public void AddAssignee(User assignee) => _assignee = assignee;

        public void RemoveAssignee() => _assignee = null;

        public void AddTask(Task task) => _tasks.Add(task);

        public void RemoveTask(Task task) => _tasks.Remove(task);

        public void AddTester(Tester tester) => _testers.Add(tester);

        public void RemoveTester(Tester tester) => _testers.Remove(tester);

        public List<Tester> GetTesters() => _testers;

        public bool AreTasksDone() => _tasks.TrueForAll(t => t.State is TaskDone);

        public BacklogItem ShallowCopy() => (BacklogItem)MemberwiseClone();
    }
}
