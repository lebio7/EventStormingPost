using EventStormingPost.Application.Features.Post.Dto;
using EventStormingPost.Application.Helpers.Interfaces;

namespace EventStormingPost.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public static List<PostDto> posts = new List<PostDto>();
        public Guid Create(PostDto dto)
        {
            dto.Id = Guid.NewGuid();
            posts.Add(dto);

            return dto.Id;
        }

        public IReadOnlyList<PostDto> GetPosts()
        {
            return posts;
        }
    }
}
