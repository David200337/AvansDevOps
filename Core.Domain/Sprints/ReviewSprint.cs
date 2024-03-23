using System;
namespace Core.Domain.Sprints
{
    public class ReviewSprint : Sprint
    {
        public ReviewSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(id, title, description, startDate, endDate, scrumMaster)
        {
        }
    }
}

