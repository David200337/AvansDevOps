namespace Core.Domain.Repository
{
	public interface IBranch
	{
		public bool AddCommit(Commit commit);
		public bool RemoveCommit(Commit commit);
		public List<Commit> GetCommits();
		public Commit GetLastCommit();
	}
}