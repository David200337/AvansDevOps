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

        private Dictionary<Role, List<IObserver<BacklogItem>>> _observers;

        public BacklogItem(string id, string title, string description, User assignee) : base(new BacklogItemToDo())
        {
            _id = id;
            _title = title;
            _description = description;
            _assignee = assignee;
            _tasks = new List<Task>();
            _observers = new Dictionary<Role, List<IObserver<BacklogItem>>>();
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
            Notify(Role.Tester, this);
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
        public void RegisterObserver(Role role, IObserver<BacklogItem> observer)
        {
            var observers = _observers.GetValueOrDefault(role);

            if (observers == null)
            {
                // Observers for this role do not exist.
                // Create a new list with the specified observer.
                observers = new List<IObserver<BacklogItem>>
                {
                    observer
                };

                // Pass the new list of observers with corresponding role to the dictionary.
                _observers.Add(role, observers);
                return;
            }
            else if (observers.Contains(observer))
            {
                // The observer is already registered for this role.
                return;
            }

            // There are existing observers for this role.
            // Add the specified observer to the list.
            _observers[role].Add(observer);
        }

        public void RemoveObserver(Role role, IObserver<BacklogItem> observer)
        {
            var observers = _observers[role];

            // No observers for this role.
            if (observers == null) return;

            // Remove the specified observer from the list.
            _observers[role].Remove(observer);
        }

        public void Notify(Role role, BacklogItem subject)
        {
            var observers = _observers[role];

            // No observers for this role.
            if (observers == null) return;

            // Loop through all observers of the specified role and notify them.
            foreach (var observer in observers)
            {
                observer.Update(role, subject);
            }
        }

        // Methods
        public void AddAssignee(User assignee) => _assignee = assignee;

        public void RemoveAssignee() => _assignee = null;

        public void AddTask(Task task) => _tasks.Add(task);

        public void RemoveTask(Task task) => _tasks.Remove(task);

        public void AddTester(User tester) => RegisterObserver(Role.Tester, tester);

        public void RemoveTester(User tester) => RemoveObserver(Role.Tester, tester);

        public bool AreTasksDone() => _tasks.All(t => t.State is TaskDone);
    }
}
