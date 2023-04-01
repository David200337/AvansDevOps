using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Pipeline
{
    public class TestAction : IPipelineActionComponent
    {
        private readonly string _testFramework;
        private bool _testsDone = false;

        public TestAction(string testFramework)
        {
            _testFramework = testFramework;
        }

        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitTestAction(this);

        public bool StartAction()
        {
            Console.WriteLine($"Running {_testFramework} tests");
            _testsDone = true;
            return true;
        }

        public bool PublishResults()
        {
            if (!_testsDone)
            {
                Console.WriteLine("Tests not done yet");
                return false;
            }
            Console.WriteLine("Publishing test results");
            return true;
        }
    }
}
