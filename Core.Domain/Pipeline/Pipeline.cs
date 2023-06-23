namespace Core.Domain.Pipeline
{
    public class Pipeline : PipelineActionComposite
    {
        public override bool AcceptVisitor(IPipelineActionVisitor visitor) => visitor.VisitPipeline(this) && base.AcceptVisitor(visitor);

        public bool StartPipeline()
        {
            Console.WriteLine("Starting pipeline.");
            return true;
        }
    }
}