using System;
using Core.Domain;
using Core.Domain.Roles;
using Core.Domain.State;

namespace Infrastructure.Tests
{
    public class MailNotificationServiceTests
    {
        public MailNotificationServiceTests()
        {
        }

        [Fact]
        public void MailNotificationService_Should_SendNotification()
        {
            // Arrange
            var tester = UserFactory.CreateUser<Tester>("1", "John", "Doe", "john@doe.com", "JohnDoe");
            var backlogItem = new BacklogItem("1", "Title", "Description");
            backlogItem.AddTester(tester);

            //// Act
            //mailNotificationService.SendNotification(notification);

            // Assert
            // We can't really assert anything here, since the method only writes to the console.
            // However, we can check if the method throws any exceptions.
        }

        [Fact]
        public void MailNotificationService_Should_SendNotificationToTesters_When_BacklogItemStateIsReadyForTesting()
        {
            //    var tester = UserFactory.CreateUser<Tester>("1", "John", "Doe", "john@doe.com", "JohnDoe");
            //    var backlogItem = new BacklogItem("1", "Backlog Item", "This is a backlog item.");
            //    backlogItem.AddTester(tester);
            //    backlogItem.

            //    backlogItem.

            //    // Arrange
            //    var email = "test@example.com";
            //    var previousState = new BacklogItem("1", "Title", "Description");
            //    var currentState = previousState.ShallowCopy();
            //    var mailNotificationService = new MailNotificationService(email);

            //    // Act
            //    currentState.SetReadyForTesting();
            //    mailNotificationService.UpdateWithPreviousState(previousState, currentState);

            //    // Assert
            //    // We can't really assert anything here, since the method only writes to the console.
            //    // However, we can check if the method throws any exceptions.
        }
    }
}

