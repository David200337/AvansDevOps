namespace Core.Domain.Sprints
{
    public class ReleaseSprint : Sprint
    {
        public ReleaseSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(id, title, description, startDate, endDate, scrumMaster)
        {
        }


    }
}
