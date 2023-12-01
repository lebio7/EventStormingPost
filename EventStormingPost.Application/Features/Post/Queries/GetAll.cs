using EventStormingPost.Application.Features.Post.Dto;
using EventStormingPost.Application.Helpers.Interfaces;
using MediatR;

namespace EventStormingPost.Application.Features.Post.Queries
{
    public class GetAllQuery : IRequest<IReadOnlyList<PostDto>>
    {
    }

    public class GetAllHandler : IRequestHandler<GetAllQuery, IReadOnlyList<PostDto>>
    {
        private readonly IPostRepository postRepository;

        public GetAllHandler(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<IReadOnlyList<PostDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return postRepository.GetPosts();
        }
    }
}
