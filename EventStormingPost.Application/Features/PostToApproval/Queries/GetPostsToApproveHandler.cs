using EventStormingPost.Application.Features.PostToApproval.Dto;
using EventStormingPost.Application.Helpers.Interfaces;
using MediatR;

namespace EventStormingPost.Application.Features.PostToApproval.Queries
{
    public class GetPostsToApproveQuery : IRequest<IReadOnlyList<PostToApprovalDto>>
    {
    }
    public class GetPostsToApproveHandler : IRequestHandler<GetPostsToApproveQuery, IReadOnlyList<PostToApprovalDto>>
    {
        private readonly IPostToApprovalRepository postToApproval;

        public GetPostsToApproveHandler(IPostToApprovalRepository postToApproval)
        {
            this.postToApproval = postToApproval;
        }

        public async Task<IReadOnlyList<PostToApprovalDto>> Handle(GetPostsToApproveQuery request, CancellationToken cancellationToken)
        {
            return postToApproval.GetPostsToApprove();
        }
    }
}
