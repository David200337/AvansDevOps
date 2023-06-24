using Core.Domain;
using Core.Domain.Roles;
using Infrastructure;

Console.WriteLine("Avans DevOps User Portal");

<<<<<<< HEAD
// Test code
var assignee = new User("1", "John", "Doe", "john@doe.com", "JohnnyDoe");

var tester = new User("2", "Jane", "Doe", "jane@doe.com", "JaneDoe");
tester.RegisterObserver(new MailNotificationService());
=======
// Create the users.
var productOwner = UserFactory.CreateUser<ProductOwner>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var scrumMaster = UserFactory.CreateUser<ScrumMaster>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var tester = UserFactory.CreateUser<Tester>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var developer = UserFactory.CreateUser<Developer>("123", "John", "Doe", "john@doe.com", "JohnDoe");


// Setup the mail notification service.
var notificationService = new MailNotificationService();


>>>>>>> feature/domain-design

var backlogItem = new BacklogItem("1", "Create a new console app", "Create a new console app using the .NET 5 template");

<<<<<<< HEAD
=======
backlogItem.AddAssignee(assignee);
backlogItem.RegisterObserver(notificationService);
>>>>>>> feature/domain-design
backlogItem.AddTester(tester);
backlogItem.SetReadyForTesting();