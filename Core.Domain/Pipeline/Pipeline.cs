namespace Core.Domain.Pipeline
{
    public class Pipeline : PipelineActionComposite
    {
        private bool _isStarted = false;
        private bool _hasRun = false;
        public override bool AcceptVisitor(IPipelineActionVisitor visitor)
        {
           bool success = visitor.VisitPipeline(this);
           return success;
        }

        public bool IsStarted => _isStarted;

        public bool HasRun => _hasRun;

        public bool StartPipeline()
        {
            Console.WriteLine("Starting pipeline.");
            _isStarted = true;
            _hasRun = true;
            try
            {
                IPipelineActionVisitor visitor = new PipelineActionVisitor();
                bool success = base.AcceptVisitor(new PipelineActionVisitor());
                _isStarted = false;
                return success;
            } catch (Exception e)
            {
                _isStarted = false;
                Console.WriteLine($"Pipeline failed: {e.Message}");
                return false;
            }
        }
    }
}