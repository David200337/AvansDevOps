using Core.Domain.Repository;

namespace Core.Domain.Tests.Repository;

public class ProjectRepositoryTests
{
    [Fact]
    public void Branch_Should_Be_Added_To_Repository()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        // Assert
        var branches = projectRepository.GetBranches();
        Assert.Equal("feature/cool-feature", branches[1].Name);        
    }

    [Fact]
    public void Branch_Should_Not_Be_Added_Twice_When_Same_Name()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        var failed = projectRepository.AddBranch("feature/cool-feature");
        Assert.False(failed);
        
        // Assert
        var branches = projectRepository.GetBranches();
        Assert.Equal(2, branches.Count); // Should be main and feature/cool-feature, which is why count should be 2.
    }
    
    [Fact]
    public void Branch_Should_Be_Removed_From_Repository()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        var removed = projectRepository.RemoveBranch("feature/cool-feature");
        Assert.True(removed);
        
        // Assert
        var branches = projectRepository.GetBranches();
        Assert.Single(branches); // Should be only main branch left.
    }
    
    [Fact]
    public void Main_Branch_Should_Be_Set()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        var set = projectRepository.SetMainBranch("feature/cool-feature");
        Assert.True(set);
        
        // Assert
        var mainBranch = projectRepository.GetMainBranch();
        Assert.Equal("feature/cool-feature", mainBranch.Name);
    }
    
    [Fact]
    public void Commit_Should_Be_Added_To_Branch()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        var branch = projectRepository.GetBranch("feature/cool-feature");
        branch?.AddCommit(new Commit("Initial commit"));
        
        // Assert
        var commits = branch?.GetCommits();
        Assert.NotNull(commits);
        Assert.Single(commits);
        Assert.Equal("Initial commit", commits[0].Content);
    }
    
    [Fact]
    public void Commit_Should_Not_Be_Added_To_Branch_Without_Content()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        var branch = projectRepository.GetBranch("feature/cool-feature");
        
        // Assert
        Assert.Throws<ArgumentException>(() => branch?.AddCommit(new Commit("")));
    }
    
    [Fact]
    public void Commit_Should_Be_Removed_From_Branch()
    {
        // Arrange
        var projectRepository = new ProjectRepository();
        
        // Act
        var succeeded = projectRepository.AddBranch("feature/cool-feature");
        Assert.True(succeeded);
        
        var branch = projectRepository.GetBranch("feature/cool-feature");
        
        var commit = new Commit("Initial commit");
        branch?.AddCommit(commit);
        
        var removed = branch?.RemoveCommit(commit);
        Assert.True(removed);
        
        // Assert
        var commits = branch?.GetCommits();
        Assert.NotNull(commits);
        Assert.Empty(commits);
    }
}