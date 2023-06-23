namespace Core.Domain.Repository
{
	public class Commit
	{
        private string Content { get; set;}

        public Commit(string content)
        {
            Content = content;
        }
    }
}
