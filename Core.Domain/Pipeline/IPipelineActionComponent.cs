namespace Core.Domain.Pipeline
{ 
    public interface IPipelineActionComponent
    {
        public bool AcceptVisitor(IPipelineActionVisitor visitor);
    }
}