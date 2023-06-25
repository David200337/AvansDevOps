using System;
using Core.Domain.Sprints;
using Core.Domain.State;

namespace Core.Domain
{
    public class Thread : IObserver<BacklogItem>
    {
        private string _id;

        private string _title;

        private User _author;

        private BacklogItem _backlogItem;

        private List<Message> _messages;

        public bool _isClosed;

        public Thread(string id, string title, User author, BacklogItem backlogItem)
        {
            _id = id;
            _title = title;
            _author = author;
            _backlogItem = backlogItem;
            _messages = new List<Message>();
            _isClosed = false;

            _backlogItem.RegisterObserver(this);
        }

        // Properties
        public string Id => _id;

        public string Title => _title;

        public User Author => _author;

        public BacklogItem BacklogItem => _backlogItem;

        public List<Message> Messages => _messages;

        public bool IsClosed => _isClosed;

        // Observer pattern
        public void UpdateWithPreviousState(BacklogItem previous, BacklogItem current)
        {
            // An update of a backlog item has occurred.

            // Check if the state has changed.
            if (!previous.State.Equals(current.State))
            {
                // Perform an action based on the new backlog item state.
                switch (current.State)
                {
                    case BacklogItemInProgress:
                        _isClosed = false;
                        break;
                    case BacklogItemDone:
                        _isClosed = true;
                        break;
                }
            }
        }

        // Methods
        public void PostMessage(User user, string content)
        {
            if (_isClosed) throw new InvalidOperationException("A message may not be posted anymore once the related backlog item is finished.");
            _messages.Add(new Message(Guid.NewGuid(), content, DateTime.Now, user));
        }
    }
}

