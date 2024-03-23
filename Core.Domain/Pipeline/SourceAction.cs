using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Pipeline
{
    public class SourceAction : IPipelineActionComponent
    {
        private readonly string _sourceUrl;

        public SourceAction(string sourceUrl)
        {
            _sourceUrl = sourceUrl;
        }

        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitSourceAction(this);

        public bool StartAction()
        {
            if (string.IsNullOrWhiteSpace(_sourceUrl))
            {
                throw new ArgumentException("Source URL cannot be null or empty.");
            }
            Console.WriteLine($"Downloading source repository from {_sourceUrl}");
            return true;
        }
    }
}
