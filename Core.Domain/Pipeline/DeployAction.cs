using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Pipeline
{
    public class DeployAction : IPipelineActionComponent
    {
        private readonly string _deploymentTarget;

        public DeployAction(string deploymentTarget)
        {
            _deploymentTarget = deploymentTarget;
        }

        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitDeployAction(this);

        public bool StartAction()
        {
            Console.WriteLine($"Deploying to {_deploymentTarget}");
            return true;
        }
    }
}
