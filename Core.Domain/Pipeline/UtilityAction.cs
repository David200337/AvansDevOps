using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Pipeline
{
    public class UtilityAction : IPipelineActionComponent
    {
        private readonly List<String> _actions;

        public UtilityAction(List<String> actions)
        {
            _actions = actions;
        }
        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitUtilityAction(this);

        public bool StartAction()
        {
            if (_actions == null || _actions.Count == 0)
            {
                throw new ArgumentException("Actions cannot be null or empty.");
            }
            foreach (var action in _actions)
            {
                Console.WriteLine($"Running {action}");
            }
            return true;
        }
    }
}
