namespace Core.Domain.Repository
{
	public interface IProjectRepository
	{
		public bool AddBranch(string branchName);
		public bool RemoveBranch(string branchName);
		public Branch? GetBranch(string branchName);
		public List<Branch> GetBranches();
		public bool SetMainBranch(string branchName);
		public Branch GetMainBranch();
	}
}
