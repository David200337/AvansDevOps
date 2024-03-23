using Core.Domain.Pipeline;
using Core.Domain.Roles;
using Core.Domain.Sprints;

namespace Core.Domain.Tests.Pipeline;

public class PipelineTests
{
    [Fact]
    public void Pipeline_Should_Be_Created()
    {
        // Arrange
        const string id = "1";
        const string title = "Sprint 1";
        const string description = "This is the first sprint";
        var startDate = DateTime.Now.AddDays(1);
        var endDate = DateTime.Now.AddDays(14);
        var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);

        // Act
        var pipeline = sprint.Pipeline;

        // Assert
        Assert.NotNull(sprint.Pipeline);
        Assert.Equal(sprint.Pipeline, pipeline);
    }

    [Fact]
    public void Pipeline_Action_Should_Be_Added_To_Pipeline()
    {
        // Arrange
        const string id = "1";
        const string title = "Sprint 1";
        const string description = "This is the first sprint";
        var startDate = DateTime.Now.AddDays(1);
        var endDate = DateTime.Now.AddDays(14);
        var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);

        var sourceAction = new SourceAction("Source");
        var packages = new List<String> { "Package1", "Package2" };
        var packageAction = new PackageAction(packages);
        var buildAction = new BuildAction("Build");
        var testAction = new TestAction("NUnit");
        var analyzeAction = new AnalyseAction("SonarQube");
        var deployAction = new DeployAction("Deploy");
        var utilityActions = new List<String> { "Utility1", "Utility2" };
        var utilityAction = new UtilityAction(utilityActions);

        // Act
        sprint.Pipeline.Add(sourceAction);
        sprint.Pipeline.Add(packageAction);
        sprint.Pipeline.Add(buildAction);
        sprint.Pipeline.Add(testAction);
        sprint.Pipeline.Add(analyzeAction);
        sprint.Pipeline.Add(deployAction);
        sprint.Pipeline.Add(utilityAction);

        // Assert
        Assert.Contains(sourceAction, sprint.Pipeline.Children);
        Assert.Contains(packageAction, sprint.Pipeline.Children);
        Assert.Contains(buildAction, sprint.Pipeline.Children);
        Assert.Contains(testAction, sprint.Pipeline.Children);
        Assert.Contains(analyzeAction, sprint.Pipeline.Children);
        Assert.Contains(deployAction, sprint.Pipeline.Children);
        Assert.Contains(utilityAction, sprint.Pipeline.Children);
    }

    [Fact]
    public void Pipeline_Action_Should_Not_Execute_When_Missing_Framework_Or_Configuration()
    {
        // Arrange
        const string id = "1";
        const string title = "Sprint 1";
        const string description = "This is the first sprint";
        var startDate = DateTime.Now.AddDays(1);
        var endDate = DateTime.Now.AddDays(14);
        var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);

        var sourceAction = new SourceAction("");
        var packages = new List<string> { "Package1", "Package2" };
        var packageAction = new PackageAction(packages);
        var buildAction = new BuildAction("");
        var testAction = new TestAction("XUnit");
        var analyzeAction = new AnalyseAction("SonarQube");
        var deployAction = new DeployAction("Deploy");
        var utilityActions = new List<string> { "Utility1", "Utility2" };
        var utilityAction = new UtilityAction(utilityActions);

        // Act
        sprint.Pipeline.Add(sourceAction);
        sprint.Pipeline.Add(packageAction);
        sprint.Pipeline.Add(buildAction);
        sprint.Pipeline.Add(testAction);
        sprint.Pipeline.Add(analyzeAction);
        sprint.Pipeline.Add(deployAction);
        sprint.Pipeline.Add(utilityAction);

        // Assert
        Assert.False(sprint.Pipeline.AcceptVisitor(new PipelineActionVisitor()));
    }
}