using Core.Domain;
using Core.Domain.Roles;
using Infrastructure;

Console.WriteLine("Avans DevOps User Portal");

// Create the users.
var productOwner = UserFactory.CreateUser<ProductOwner>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var scrumMaster = UserFactory.CreateUser<ScrumMaster>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var tester = UserFactory.CreateUser<Tester>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var developer = UserFactory.CreateUser<Developer>("123", "John", "Doe", "john@doe.com", "JohnDoe");


// Setup the mail notification service.
var notificationService = new MailNotificationService();



var backlogItem = new BacklogItem("1", "Create a new console app", "Create a new console app using the .NET 5 template");

backlogItem.AddAssignee(assignee);
backlogItem.RegisterObserver(notificationService);
backlogItem.AddTester(tester);
backlogItem.SetReadyForTesting();
