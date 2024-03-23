namespace Core.Domain.Pipeline
{
    public class PipelineActionComposite : IPipelineActionComponent
    {
        private readonly List<IPipelineActionComponent> _children;

        public List<IPipelineActionComponent> Children => _children; 

        public PipelineActionComposite()
        {
            _children = new List<IPipelineActionComponent>();
        }

        public void Add(IPipelineActionComponent component)
        {
            _children.Add(component);
        }

        public void Remove(IPipelineActionComponent component)
        {
            _children.Remove(component);
        }

        virtual public bool AcceptVisitor(IPipelineActionVisitor visitor)
        {
            foreach (var child in _children)
            {
                bool success = child.AcceptVisitor(visitor);
                if (!success)
                    return false;
            }
            return true;
        }
    }
}