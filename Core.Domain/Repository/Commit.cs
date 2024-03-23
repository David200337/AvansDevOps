namespace Core.Domain.Repository
{
	public class Commit
	{
        public string Content { get; set;}

        public Commit(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Content cannot be empty or null.", nameof(content));
            }
            
            Content = content;
        }
    }
}
