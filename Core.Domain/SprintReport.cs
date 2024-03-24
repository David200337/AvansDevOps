using System;
using Core.Domain.Sprints;

namespace Core.Domain
{
    public class SprintReport
    {
        private readonly Sprint _sprint;

        private readonly string _header;

        private readonly string _footer;

        private readonly List<User> _teamMembers;

        public SprintReport(Sprint sprint, string header, string footer, List<User> teamMembers)
        {
            _sprint = sprint;
            _header = header;
            _footer = footer;
            _teamMembers = teamMembers;
        }

        public string GenerateReport()
        {
            var report = $"SPRINT REPORT ({_sprint.Title})\n";
            report += $"{_header}\n";
            report += "\nTeam Members:\n";

            _teamMembers.ForEach(m => report += $"{m}\n");

            report += $"\n{_footer}";

            return report;
        }
    }
}

