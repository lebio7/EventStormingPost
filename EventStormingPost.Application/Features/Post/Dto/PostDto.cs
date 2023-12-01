namespace EventStormingPost.Application.Features.Post.Dto
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Name { get; }

        public string Description { get; }

        public string UserLogin { get; }

        public PostDto(string name, string description, string userLogin)
        {
            Name = name;
            Description = description;
            UserLogin = userLogin;
        }
    }
}