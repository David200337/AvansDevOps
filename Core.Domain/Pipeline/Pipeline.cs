namespace Core.Domain.Pipeline
{
    public class Pipeline : PipelineActionComposite
    {
        private bool _isStarted = false;
        public override bool AcceptVisitor(IPipelineActionVisitor visitor)
        {
            try
            {
                bool success = visitor.VisitPipeline(this);
                success = base.AcceptVisitor(visitor);
                _isStarted = false;
                return success;
            } catch (Exception e)
            {
                _isStarted = false;
                Console.WriteLine($"Pipeline execution failed: {e.Message}");
                return false;
            }
        }

        public bool IsStarted => _isStarted;

        public bool StartPipeline()
        {
            Console.WriteLine("Starting pipeline.");
            _isStarted = true;
            AcceptVisitor(new PipelineActionVisitor());
            return true;
        }
    }
}