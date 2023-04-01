namespace Core.Domain.Pipeline
{
    public class PackageAction : IPipelineActionComponent
    {
        private readonly List<String> _packages;

        public PackageAction(List<String> packages)
        {
            _packages = packages;
        }

        public bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitPackageAction(this);

        public bool StartAction()
        {
            Console.WriteLine("Installing packages:");
            foreach (var package in _packages)
            {
                Console.WriteLine($"- {package}");
            }
            return true;
        }
    }
}
