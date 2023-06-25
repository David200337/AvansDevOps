﻿using Core.Domain.Roles;
using Core.Domain.Sprints;

namespace Core.Domain.Tests;

public class ProjectTests
{
    [Fact]
    public void A_Project_Should_Be_Created()
    {
        // Create the users.
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("2", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create a new project.
        var project = new Project("1", "Avans DevOps", productOwner, leadDeveloper);

        Assert.True(project is not null);
        Assert.Equal("Avans DevOps", project.Title);
    }

    [Fact]
    public void Product_Owner_Should_Be_Added_To_Project()
    {
        // Create the users.
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("2", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create a new project.
        var project = new Project("1", "Avans DevOps", productOwner, leadDeveloper);

        Assert.True(project is not null);
        Assert.True(project.LeadDeveloper is not null);
        Assert.Equal(leadDeveloper.Id, project.LeadDeveloper.Id);
    }

    [Fact]
    public void Lead_Developer_Should_Be_Added()
    {
        // Create the users.
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("2", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create a new project.
        var project = new Project("1", "Avans DevOps", productOwner, leadDeveloper);

        Assert.True(project.LeadDeveloper is not null);
        Assert.Equal(leadDeveloper.Id, project.LeadDeveloper.Id);
    }

    [Fact]
    public void Users_Should_Be_Added_To_Project()
    {
        // Create the users.
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var scrumMaster = UserFactory.CreateUser<ScrumMaster>("2", "John", "Doe", "john@doe.com", "JohnDoe");
        var tester = UserFactory.CreateUser<Tester>("3", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("4", "John", "Doe", "john@doe.com", "JohnDoe");
        var developer = UserFactory.CreateUser<Developer>("5", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create a new project.
        var project = new Project("1", "Avans DevOps", productOwner, leadDeveloper);

        // Add additional team members to the project.
        project.AddTeamMember(scrumMaster);
        project.AddTeamMember(tester);
        project.AddTeamMember(developer);

        var teamMembers = project.GetTeamMembers();

        Assert.Contains(teamMembers, t => t.Id.Equals(scrumMaster.Id));
        Assert.Contains(teamMembers, t => t.Id.Equals(tester.Id));
        Assert.Contains(teamMembers, t => t.Id.Equals(developer.Id));
        Assert.Equal(3, teamMembers.Count);
    }

    [Fact]
    public void Sprint_Should_Be_Added_To_Project()
    {
        // Create the users.
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("2", "John", "Doe", "john@doe.com", "JohnDoe");
        var scrumMaster = UserFactory.CreateUser<ScrumMaster>("3", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create a new project.
        var project = new Project("1", "Avans DevOps", productOwner, leadDeveloper);

        // Add a new backlog item.
        project.CreateSprint(SprintType.Review, "1", "Review Sprint", "This is our review sprint", DateTime.Now, DateTime.Now.AddDays(2), scrumMaster);

        var sprints = project.GetSprints();

        Assert.Equal(1, sprints.Count);
        Assert.Equal("Review Sprint", sprints[0].Title);
    }

    [Fact]
    public void Project_Should_CreateThread_When_ValidParameters()
    {
        // Arrange
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("2", "John", "Doe", "john@doe.com", "JohnDoe");
        var project = new Project("1", "Project 1", productOwner, leadDeveloper);
        var threadId = "1";
        var threadTitle = "Thread 1";
        var author = UserFactory.CreateUser<Developer>("2", "John", "Doe", "john@doe.com", "JohnDoe");
        var backlogItem = new BacklogItem("1", "Backlog item", "This is a backlog item.");

        // Act
        project.CreateThread(threadId, threadTitle, author, backlogItem);

        // Assert
        var threads = project.GetThreads();
        Assert.Single(threads);
        Assert.Equal(threadId, threads[0].Id);
        Assert.Equal(threadTitle, threads[0].Title);
        Assert.Equal(author, threads[0].Author);
        Assert.Equal(backlogItem, threads[0].BacklogItem);
    }

    [Fact]
    public void Project_Should_ThrowArgumentNullException_When_NullBacklogItem()
    {
        // Arrange
        var productOwner = UserFactory.CreateUser<ProductOwner>("1", "John", "Doe", "john@doe.com", "JohnDoe");
        var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("2", "John", "Doe", "john@doe.com", "JohnDoe");
        var project = new Project("1", "Project 1", productOwner, leadDeveloper);
        var threadId = "1";
        var threadTitle = "Thread 1";
        var author = UserFactory.CreateUser<Developer>("2", "John", "Doe", "john@doe.com", "JohnDoe");
        BacklogItem? backlogItem = null;

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => project.CreateThread(threadId, threadTitle, author, backlogItem));
    }
}
