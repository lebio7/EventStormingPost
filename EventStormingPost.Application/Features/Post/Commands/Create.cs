using EventStormingPost.Application.Features.Post.Dto;
using EventStormingPost.Application.Features.Post.Events;
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
        private readonly IMediator mediator;

        public CreateHandler(IPostRepository postRepository, IMediator mediator)
        {
            this.postRepository = postRepository;
            this.mediator = mediator;
        }

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var id = postRepository.Create(dto);

            await mediator.Publish(new PostCreatedEvent(dto));

            return id;
        }
    }
}
