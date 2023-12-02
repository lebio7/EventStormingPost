using EventStormingPost.Application.Features.PostToApproval.Dto;
using EventStormingPost.Application.Helpers.Interfaces;
using MediatR;

namespace EventStormingPost.Application.Features.PostToApproval.Commands
{
    public class CreateCommand : IRequest<Guid>
    {
        public PostToApprovalDto Dto { get; }

        public CreateCommand(PostToApprovalDto dto)
        {
            Dto = dto;
        }
    }
    public class CreateHandler : IRequestHandler<CreateCommand, Guid>
    {
        private readonly IPostToApprovalRepository postToApprovalRepository;

        public CreateHandler(IPostToApprovalRepository postToApprovalRepository)
        {
            this.postToApprovalRepository = postToApprovalRepository;
        }

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            if (request.Dto.Id != null)
            {
                throw new ArgumentException(nameof(request.Dto.Id));
            }

            var id = postToApprovalRepository.Add(request.Dto);

            return id;
        }
    }
}
