namespace Core.Domain
{
    public class FeedbackSprint : Sprint
    {
        public FeedbackSprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(title, description, startDate, endDate, scrumMaster)
        {
        }


    }
}
