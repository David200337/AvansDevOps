namespace Core.Domain.Pipeline
{
    public class Pipeline : PipelineActionComposite
    {
        private bool _isStarted = false;
        public override bool AcceptVisitor(IPipelineActionVisitor visitor)
        {
            bool success = visitor.VisitPipeline(this);
            success = base.AcceptVisitor(visitor);
            _isStarted = false;
            return success;
        }

        public bool IsStarted => _isStarted;

        public bool StartPipeline()
        {

            Console.WriteLine("Starting pipeline.");
            _isStarted = true;
            return true;
        }
    }
}