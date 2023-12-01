using EventStormingPost.Application.Features.Post.Dto;
using EventStormingPost.Application.Helpers.Interfaces;
using MediatR;

namespace EventStormingPost.Application.Features.Post.Commands
{
    public class CreateCommand : IRequest<Guid>
    {
        public PostDto Dto { get; }

        public CreateCommand(PostDto dto)
        {
            Dto = dto;
        }
    }

    public class CreateHandler : IRequestHandler<CreateCommand, Guid>
    {
        private readonly IPostRepository postRepository;

        public CreateHandler(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var id = postRepository.Create(dto);

            return id;
        }
    }
}
