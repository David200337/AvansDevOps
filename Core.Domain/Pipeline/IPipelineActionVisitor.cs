namespace Core.Domain.Pipeline
{
    public interface IPipelineActionVisitor
    {
        public bool VisitPipeline(Pipeline pipeline);
        public bool VisitSourceAction(SourceAction sourceAction);
        public bool VisitPackageAction(PackageAction packageAction);
        public bool VisitBuildAction(BuildAction buildAction);
        public bool VisitTestAction(TestAction testAction);
        public bool VisitAnalyseAction(AnalyseAction analyzeAction);
        public bool VisitDeployAction(DeployAction deployAction);
        public bool VisitUtilityAction(UtilityAction utilityAction);
    }
}