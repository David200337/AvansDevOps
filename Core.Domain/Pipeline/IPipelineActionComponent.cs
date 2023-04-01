using Core.Domain.Pipeline;

namespace Core.Domain
{ 
    public interface IPipelineActionComponent
    {
        public bool AcceptVisitor(IPipelineActionVisitor visitor);
    }
}