using System;
using Core.Domain.Roles;
using Core.Domain.State;

namespace Core.Domain.Tests
{
    public class BacklogItemTests
    {

        [Fact]
        public void Backlog_Item_Should_Be_Created()
        {
            // Create backlog item.
            var backlogItem = new BacklogItem("1", "Backlog Item", "This is a backlog item");

            Assert.True(backlogItem is not null);
        }

        [Fact]
        public void Backlog_Item_Should_Be_Assigned()
        {
            // Create user.
            var developer = UserFactory.CreateUser<Developer>("1", "John", "Doe", "john@doe.com", "JohnDoe");

            // Create backlog item.
            var backlogItem = new BacklogItem("1", "Backlog Item", "This is a backlog item");

            // Add assignee.
            backlogItem.AddAssignee(developer);

            Assert.Equal(developer, backlogItem.Assignee);
        }

        [Fact]
        public void Backlog_Item_State_Should_Be_To_Do_When_Created()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");

            // Assert
            Assert.IsType<BacklogItemToDo>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Be_In_Progress()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");

            // Act
            backlogItem.SetInProgress();

            // Assert
            Assert.IsType<BacklogItemInProgress>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Be_Ready_For_Testing()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");

            // Act
            backlogItem.SetReadyForTesting();

            // Assert
            Assert.IsType<BacklogItemReadyForTesting>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Be_Testing()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");

            // Act
            backlogItem.SetTesting();

            // Assert
            Assert.IsType<BacklogItemTesting>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Be_Tested()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");

            // Act
            backlogItem.SetTested();

            // Assert
            Assert.IsType<BacklogItemTested>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Be_Done_When_Tasks_Are_Done()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            backlogItem.AddTask(new Task("1", "Task 1", "This is task 1.", user));
            backlogItem.AddTask(new Task("2", "Task 2", "This is task 2", user));
            backlogItem.Tasks[0].SetDone();
            backlogItem.Tasks[1].SetDone();

            // Act
            backlogItem.SetDone();

            // Assert
            Assert.IsType<BacklogItemDone>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Not_Be_Done_When_Tasks_Are_Not_Done()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            backlogItem.AddTask(new Task("1", "Task 1", "This is task 1.", user));
            backlogItem.AddTask(new Task("2", "Task 2", "This is task 2", user));
            backlogItem.Tasks[0].SetDone();

            // Act
            backlogItem.SetDone();

            // Assert
            Assert.IsNotType<BacklogItemDone>(backlogItem.State);
        }

        [Fact]
        public void Backlog_Item_State_Should_Add_Assignee()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");

            // Act
            backlogItem.AddAssignee(user);

            // Assert
            Assert.Equal(user, backlogItem.Assignee);
        }

        [Fact]
        public void Backlog_Item_State_Should_Remove_Assignee()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            backlogItem.AddAssignee(user);

            // Act
            backlogItem.RemoveAssignee();

            // Assert
            Assert.Null(backlogItem.Assignee);
        }

        [Fact]
        public void Backlog_Item_State_Should_Add_Task()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            var task = new Task("1", "Task 1", "This is task 1.", user);

            // Act
            backlogItem.AddTask(task);

            // Assert
            Assert.Contains(task, backlogItem.Tasks);
        }

        [Fact]
        public void Backlog_Item_State_Should_Remove_Task()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            var task = new Task("1", "Task 1", "This is task 1.", user);
            backlogItem.AddTask(task);

            // Act
            backlogItem.RemoveTask(task);

            // Assert
            Assert.DoesNotContain(task, backlogItem.Tasks);
        }

        [Fact]
        public void Backlog_Item_Tasks_Should_Be_Done()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            backlogItem.AddTask(new Task("1", "Task 1", "This is task 1.", user));
            backlogItem.AddTask(new Task("2", "Task 2", "This is task 2", user));
            backlogItem.Tasks[0].SetDone();
            backlogItem.Tasks[1].SetDone();

            // Act
            var result = backlogItem.AreTasksDone();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreTasksDone_ReturnsFalse_WhenNotAllTasksAreDone()
        {
            // Arrange
            var user = new Developer("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            backlogItem.AddTask(new Task("1", "Task 1", "This is task 1.", user));
            backlogItem.AddTask(new Task("2", "Task 2", "This is task 2", user));
            backlogItem.Tasks[0].SetDone();

            // Act
            var result = backlogItem.AreTasksDone();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ShallowCopy_ReturnsShallowCopy()
        {
            // Arrange
            var backlogItem = new BacklogItem("1", "Title", "Description");

            // Act
            var copy = backlogItem.ShallowCopy();

            // Assert
            Assert.Equal(backlogItem.Id, copy.Id);
            Assert.Equal(backlogItem.Title, copy.Title);
            Assert.Equal(backlogItem.Description, copy.Description);
            Assert.Equal(backlogItem.Assignee, copy.Assignee);
            Assert.Equal(backlogItem.Tasks, copy.Tasks);
            Assert.Equal(backlogItem.GetTesters(), copy.GetTesters());
            Assert.Equal(backlogItem.State.GetType(), copy.State.GetType());
        }


    }
}

