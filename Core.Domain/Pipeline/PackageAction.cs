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
            if (_packages == null || _packages.Count == 0)
            {
                throw new ArgumentException("Packages cannot be null or empty.");
            }
            Console.WriteLine("Installing packages:");
            foreach (var package in _packages)
            {
                Console.WriteLine($"- {package}");
            }
            return true;
        }
    }
}
