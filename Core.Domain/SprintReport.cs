using System;
using Core.Domain.Sprints;

namespace Core.Domain
{
    public class SprintReport
    {
        private Sprint _sprint;

        private string _header;

        private string _footer;

        private List<User> _teamMembers;

        public SprintReport(Sprint sprint, string header, string footer, List<User> teamMembers)
        {
            _sprint = sprint;
            _header = header;
            _footer = footer;
            _teamMembers = teamMembers;
        }

        public string GenerateReport()
        {
            var report = "SPRINT REPORT\n";
            report += $"{_header}\n";
            report += "\nTeam Members:\n";

            _teamMembers.ForEach(m => report += $"{m}\n");

            report += $"\n{_footer}";

            return report;
        }
    }
}

