namespace Core.Domain
{
    public class ReleaseSprint : Sprint
    {
        public ReleaseSprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(title, description, startDate, endDate, scrumMaster)
        {
        }


    }
}
