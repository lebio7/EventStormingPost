using EventStormingPost.Application.Features.PostToApproval.Dto;
using EventStormingPost.Application.Helpers.Interfaces;

namespace EventStormingPost.Infrastructure.Repositories
{
    public class PostToApprovalRepository : IPostToApprovalRepository
    {
        public static List<PostToApprovalDto> postsToApprove = new List<PostToApprovalDto>();

        public IReadOnlyList<PostToApprovalDto> GetPostsToApprove()
        {
            return postsToApprove?.Where(x => !x.IsApprove)?.ToList();
        }

        public Guid Add(PostToApprovalDto dto)
        {
            dto.Id = Guid.NewGuid();
            postsToApprove.Add(dto);

            return dto.Id;
        }

        public bool Update(PostToApprovalDto dto)
        {
            if (!postsToApprove.Any(x=> x.Id == dto?.Id))
            {
                throw new Exception("Not found");
            }

            var toUpdate = postsToApprove.FirstOrDefault(x => x.Id == dto.Id);

            if (toUpdate != null)
            {
                toUpdate = dto;
            }

            return true;
        }
    }
}
