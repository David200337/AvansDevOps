using Core.Domain.Roles;
using Core.Domain.Sprints;
using Core.Domain.State;

namespace Core.Domain.Tests.Sprints
{
    public class SprintTests
    {
        [Fact]
        public void Sprint_Should_Be_Created_When_Created()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);

            // Act & Assert
            Assert.IsType<SprintCreated>(sprint.State);
        }

        [Fact]
        public void Sprint_Should_Be_In_Progress_When_In_Progress()
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
            sprint.SetInProgress();

            // Assert
            Assert.IsType<SprintInProgress>(sprint.State);
        }

        [Fact]
        public void Sprint_Should_Throw_InvalidOperationException_When_Setting_Title_At_Non_Created_State()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);
            sprint.SetInProgress();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.Title = "New Title");
        }

        [Fact]
        public void Sprint_Should_Add_Backlog_Item_When_Adding_Backlog_Item()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
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
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);
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
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            sprint.SetInRelease();
            sprint.StartPipeline();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.SetFinished());
        }

        [Fact]
        public void Sprint_Should_Notify_Observers_When_State_Changes()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new TestObserver();
            sprint.RegisterObserver(observer);

            // Act
            sprint.SetInProgress();

            // Assert
            Assert.True(observer.WasNotified);
        }

        [Fact]
        public void Sprint_Should_Not_Notify_Observers_When_State_Does_Not_Change()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new TestObserver();
            sprint.RegisterObserver(observer);
            
            // Act
            // No state change, state should remain SprintCreated
            
            // Assert
            Assert.False(observer.WasNotified);
        }

        [Fact]
        public void Sprint_Should_Not_Notify_Observers_When_ReleaseInProgress()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new TestObserver();
            sprint.RegisterObserver(observer);

            // Act
            sprint.SetInRelease();
            
            // Assert
            Assert.False(observer.WasNotified);
        }

        [Fact]
        public void Sprint_Should_Start_Pipeline_When_ReleaseInProgress()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new TestObserver();
            sprint.RegisterObserver(observer);
            
            // Act
            sprint.SetInRelease();
            
            // Assert
            Assert.True(sprint.Pipeline.IsStarted);
        }

        [Fact]
        public void Sprint_Should_Notify_Scrum_Master_When_Released()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new TestObserver();
            sprint.RegisterObserver(observer);
            
            // Act
            sprint.SetReleased();
            
            // Assert
            Assert.True(observer.WasNotified);
        }

        [Fact]
        public void Sprint_Should_Notify_Scrum_Master_When_ReleaseCancelled()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var scrumMaster = new ScrumMaster("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReviewSprint(id, title, description, startDate, endDate, scrumMaster);
            var observer = new TestObserver();
            sprint.RegisterObserver(observer);
            
            // Act
            sprint.SetReleaseCancelled();
            
            // Assert
            Assert.True(observer.WasNotified);
        }

        [Fact]
        public void Sprint_Should_GenerateReport_When_SprintIsFinished()
        {
            // Arrange
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var developer = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var scrumMaster = new ScrumMaster("2", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);
            sprint.SetFinished();
            const string header = "Sprint Report";
            const string footer = "End of Report";
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
            const string id = "1";
            const string title = "Sprint 1";
            const string description = "This is the first sprint";
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(14);
            var developer = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var scrumMaster = new ScrumMaster("2", "John", "Doe", "john@doe.com", "JohnDoe");
            var sprint = new ReleaseSprint(id, title, description, startDate, endDate, scrumMaster);
            const string header = "Sprint Report";
            const string footer = "End of Report";
            var teamMembers = new List<User> { scrumMaster, developer };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sprint.GenerateReport(header, footer, teamMembers));
        }
        
        private class TestObserver : IObserver<Sprint>
        {
            public bool WasNotified { get; private set; }

            public void UpdateWithPreviousState(Sprint previous, Sprint current)
            {
                WasNotified = true;
            }
        }
    }
}