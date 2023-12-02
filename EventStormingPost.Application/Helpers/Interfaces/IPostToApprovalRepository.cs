using EventStormingPost.Application.Features.PostToApproval.Dto;

namespace EventStormingPost.Application.Helpers.Interfaces
{
    public interface IPostToApprovalRepository
    {
        public IReadOnlyList<PostToApprovalDto> GetPostsToApprove();

        public Guid Add(PostToApprovalDto dto);

        public bool Update(PostToApprovalDto dto);
    }
}
