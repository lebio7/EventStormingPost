using EventStormingPost.Application.Features.Post.Dto;

namespace EventStormingPost.Application.Helpers.Interfaces
{
    public interface IPostRepository
    {
        public IReadOnlyList<PostDto> GetPosts();

        public Guid Create(PostDto dto);
    }
}
