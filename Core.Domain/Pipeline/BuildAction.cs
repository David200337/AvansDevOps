namespace Core.Domain.Pipeline
{
    public class BuildAction : IPipelineActionComponent
    {
        private readonly string _buildType;

        public BuildAction(string buildTarget)
        {
            _buildType = buildTarget;
        }

        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitBuildAction(this);

        public bool StartAction()
        {
            Console.WriteLine($"Building {_buildType} project");
            return true;
        }
    }
}
