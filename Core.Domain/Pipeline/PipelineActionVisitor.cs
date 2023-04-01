
namespace Core.Domain.Pipeline
{
    internal class PipelineActionVisitor : IPipelineActionVisitor
    {
        public bool VisitPipeline(Pipeline pipeline) => pipeline.StartPipeline();
        public bool VisitSourceAction(SourceAction sourceAction) => sourceAction.StartAction();
        public bool VisitPackageAction(PackageAction packageAction) => packageAction.StartAction();
        public bool VisitBuildAction(BuildAction buildAction) => buildAction.StartAction();
        public bool VisitTestAction(TestAction testAction) => testAction.StartAction() && testAction.PublishResults();
        public bool VisitAnalyseAction(AnalyseAction analyzeAction) => analyzeAction.StartAction();
        public bool VisitDeployAction(DeployAction deployAction) => deployAction.StartAction();
        public bool VisitUtilityAction(UtilityAction utilityAction) => utilityAction.StartAction();
    } 
}
