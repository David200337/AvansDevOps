using System;
namespace Core.Domain.Sprints
{
    public class ReviewSprint : Sprint
    {
        public ReviewSprint(string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(title, description, startDate, endDate, scrumMaster)
        {
        }
    }
}

