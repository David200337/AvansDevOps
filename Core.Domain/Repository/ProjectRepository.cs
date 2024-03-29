﻿namespace Core.Domain.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private Branch _mainBranch;
        private readonly List<Branch> _branches = new();

        public ProjectRepository()
        {
            _branches.Add(new Branch("main"));
            _mainBranch = _branches.First();
        }

        public bool AddBranch(string branchName)
        {
            if (_branches.Exists(b => b.Name == branchName)) return false;
            
            _branches.Add(new Branch(branchName));
            return true;
        }

        public Branch? GetBranch(string branchName)
        {
            return _branches.First(b => b.Name == branchName);
        }

        public List<Branch> GetBranches()
        {
            return _branches;
        }

        public Branch GetMainBranch()
        {
            return _mainBranch;
        }

        public bool RemoveBranch(string branchName)
        {
            if (!_branches.Exists(b => b.Name == branchName)) return false;
            
            _branches.Remove(_branches.First(b => b.Name == branchName));
            return true;
        }

        public bool SetMainBranch(string branchName)
        {
            if (!_branches.Exists(b => b.Name == branchName)) return false;
            
            _mainBranch = _branches.First(b => b.Name == branchName);
            return true;
        }
    }
}
