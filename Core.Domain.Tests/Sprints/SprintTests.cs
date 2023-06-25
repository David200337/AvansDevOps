using System;
using System.Collections.Generic;
using Core.Domain.Roles;
using Core.Domain.Sprints;
using Core.Domain.State;
using Xunit;

namespace Core.Domain.Tests.Sprints
{
    public class SprintTests
    {
        [Fact]
        public void Sprint_Should_Be_Created_When_Created()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);

            // Act & Assert
            Assert.IsType<SprintCreated>(sprint.State);
        }

        [Fact]
        public void Sprint_Should_Be_In_Progress_When_In_Progress()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);

            // Act
            sprint.SetInProgress();

            // Assert
            Assert.IsType<SprintInProgress>(sprint.State);
        }

        [Fact]
        public void Sprint_Should_Throw_InvalidOperationException_When_Setting_Title_At_Non_Created_State()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            sprint.SetInProgress();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.Title = "New Title");
        }

        [Fact]
        public void Sprint_Should_Add_Backlog_Item_When_Adding_Backlog_Item()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            var backlogItem = new BacklogItem("1", "Backlog Item 1", "This is the first backlog item");

            // Act
            sprint.AddBacklogItem(backlogItem);

            // Assert
            Assert.Contains(backlogItem, sprint.Backlog);
        }

        [Fact]
        public void Sprint_Should_Remove_Backlog_Item_When_Removing_Backlog_Item()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            var backlogItem = new BacklogItem("1", "Backlog Item 1", "This is the first backlog item");
            sprint.AddBacklogItem(backlogItem);

            // Act
            sprint.RemoveBacklogItem(backlogItem);

            // Assert
            Assert.DoesNotContain(backlogItem, sprint.Backlog);
        }

        [Fact]
        public void Sprint_Should_Throw_InvalidOperationException_When_Changing_State_While_Pipeline_Is_Running()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            sprint.SetInRelease();
            sprint.StartPipeline();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.SetFinished());
        }

        [Fact]
        public void Sprint_Should_Notify_Observers_When_State_Changes()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new ConcreteObserver();
            sprint.RegisterObserver(observer);

            // Act
            sprint.SetInProgress();

            // Assert
            Assert.True(observer.WasNotified);
        }

        [Fact]
        public void Sprint_Should_GenerateReport_When_SprintIsFinished()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var developer = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var scrumMaster = new ScrumMaster("2", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            sprint.SetFinished();
            var header = "Sprint Report";
            var footer = "End of Report";
            var teamMembers = new List<User> { scrumMaster, developer };

            // Act
            var report = sprint.GenerateReport(header, footer, teamMembers);

            // Assert
            Assert.NotNull(report);
        }

        [Fact]
        public void Sprint_Should_ThrowInvalidOperationException_When_SprintIsNotFinished()
        {
            // Arrange
            var id = "1";
            var title = "Sprint 1";
            var description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var developer = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var scrumMaster = new ScrumMaster("2", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ConcreteSprint(id, title, description, startDate, endDate, scrumMaster);
            var header = "Sprint Report";
            var footer = "End of Report";
            var teamMembers = new List<User> { scrumMaster, developer };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.GenerateReport(header, footer, teamMembers));
        }

        private class ConcreteSprint : Sprint
        {
            public ConcreteSprint(string id, string title, string description, DateTime startDate, DateTime endDate, User scrumMaster) : base(id, title, description, startDate, endDate, scrumMaster)
            {
            }
        }

        private class ConcreteObserver : IObserver<Sprint>
        {
            public bool WasNotified { get; private set; }

            public void UpdateWithPreviousState(Sprint previous, Sprint current)
            {
                WasNotified = true;
            }
        }
    }
}