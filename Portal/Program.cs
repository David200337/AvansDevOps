using Core.Domain;
using Infrastructure;

Console.WriteLine("Avans DevOps User Portal");

// Test code
var notificationService = new MailNotificationService();

var assignee = new User("1", "John", "Doe", "john@doe.com", "JohnnyDoe");

var tester = new User("2", "Jane", "Doe", "jane@doe.com", "JaneDoe");

var backlogItem = new BacklogItem("1", "Create a new console app", "Create a new console app using the .NET 5 template", assignee);

backlogItem.RegisterObserver(notificationService);
backlogItem.AddTester(tester);
backlogItem.SetReadyForTesting();
