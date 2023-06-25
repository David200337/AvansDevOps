using Core.Domain;
using Core.Domain.Repository;
using Core.Domain.Roles;
using Core.Domain.Sprints;
using Infrastructure;

Console.WriteLine("Avans DevOps User Portal");

// Create the users.
var productOwner = UserFactory.CreateUser<ProductOwner>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var scrumMaster = UserFactory.CreateUser<ScrumMaster>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var tester = UserFactory.CreateUser<Tester>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var leadDeveloper = UserFactory.CreateUser<LeadDeveloper>("123", "John", "Doe", "john@doe.com", "JohnDoe");
var developer = UserFactory.CreateUser<Developer>("123", "John", "Doe", "john@doe.com", "JohnDoe");

// Create a new project.
var project = new Project("1", "Avans DevOps", productOwner, leadDeveloper);

// Create a sprint.
project.CreateSprint(SprintType.Review, "1", "Sprint 1", "Sprint 1 description", DateTime.Now, DateTime.Now.AddDays(14), scrumMaster);

// Add backlog items to the newly created sprint.
var backlogItems = new List<BacklogItem> {
    new BacklogItem("1", "Build API", "The app's API should be built."),
    new BacklogItem("2", "Build App", "The app should be built as a user interface for the API's functionality.")
};

var sprint = project.GetSprint("1");
if (sprint == null) throw new Exception("Sprint is null!");
sprint.AddBacklogItem(backlogItems[0]);
sprint.AddBacklogItem(backlogItems[1]);

// Start the sprint.
project.StartSpint("1");

// Add a backlog item to the sprint.
var activeSprint = project.GetActiveSprint();

Console.WriteLine(activeSprint);


//project.Repository.AddBranch("feature/cool-feature");

//var branches = project.Repository.GetBranches();

//var coolFeatureBranch = project.Repository.GetBranch("feature/cool-feature");
//coolFeatureBranch.AddCommit(new Commit("Initial commit"));

//var backlogItem = new BacklogItem("1", "Create a new console app", "Create a new console app using the .NET 5 template");

//project.ActiveSprint.AddBacklogItem(backlogItem);

//project.ActiveSprint.SetInProgress();

//// Setup the mail notification service.
//var notificationService = new MailNotificationService();



//// var backlogItem = new BacklogItem("1", "Create a new console app", "Create a new console app using the .NET 5 template");

//backlogItem.AddAssignee(assignee);
//backlogItem.RegisterObserver(notificationService);
//backlogItem.AddTester(tester);
//backlogItem.SetReadyForTesting();