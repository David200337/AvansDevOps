namespace Core.Domain.Repository
{
    public class Branch : IBranch
    {
        private string _name;
        private readonly List<Commit> _commits = new();

        public Branch(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }

        public bool AddCommit(Commit commit)
        {
            _commits.Add(commit);

            if (_commits.Contains(commit))
            {
                return true;
            }

            return false;
        }

        public List<Commit> GetCommits()
        {
            return _commits;
        }

        public Commit GetLastCommit()
        {
            return _commits.Last();
        }

        public bool RemoveCommit(Commit commit)
        {
            _commits.Remove(commit);

            if (!_commits.Contains(commit))
            {
                return true;
            }

            return false;
        }
    }
}
