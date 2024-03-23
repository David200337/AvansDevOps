using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Pipeline
{
    public class AnalyseAction : IPipelineActionComponent
    {
        private readonly string _analysisTool;

        public AnalyseAction(string analysisTool)
        {
            _analysisTool = analysisTool;
        }
        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitAnalyseAction(this);

        public bool StartAction()
        {
            if (string.IsNullOrWhiteSpace(_analysisTool))
            {
                throw new ArgumentException("Analysis tool cannot be null or empty.");
            }
            Console.WriteLine($"Running {_analysisTool} code analysis");
            return true;
        }
    }
}
