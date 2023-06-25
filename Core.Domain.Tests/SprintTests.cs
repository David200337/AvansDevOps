using System;
using Core.Domain.Roles;
using Core.Domain.Sprints;

namespace Core.Domain.Tests;

public class SprintTests
{

    [Fact]
    public void Sprint_Should_Be_Created()
    {
        // Create the users.
        var scrumMaster = UserFactory.CreateUser<ScrumMaster>("1", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create the sprint.
        var releaseSprint = new ReleaseSprint("1", "Release sprint", "This is a release sprint", DateTime.Now, DateTime.Now.AddDays(4), scrumMaster);

        Assert.True(releaseSprint is not null);
    }

    [Fact]
    public void BacklogItem_Should_Be_Added()
    {
        // Create the users.
        var scrumMaster = UserFactory.CreateUser<ScrumMaster>("1", "John", "Doe", "john@doe.com", "JohnDoe");

        // Create the sprint.
        var releaseSprint = new ReleaseSprint("1", "Release sprint", "This is a release sprint", DateTime.Now, DateTime.Now.AddDays(4), scrumMaster);

        var backlogItem = new BacklogItem("1", "Backlog Item", "This is a backlog item");
        releaseSprint.AddBacklogItem(backlogItem);

        Assert.True(releaseSprint is not null);
        Assert.Equal(backlogItem, releaseSprint.Backlog[0]);
        Assert.Single(releaseSprint.Backlog);
    }
}

