using Core.Domain.Sprints;

namespace Core.Domain
{
    public class FeedbackSprint : Sprint
    {
        public FeedbackSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(id, title, description, startDate, endDate, scrumMaster)
        {
        }
    }
}
