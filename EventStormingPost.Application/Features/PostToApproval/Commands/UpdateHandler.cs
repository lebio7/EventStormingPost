using EventStormingPost.Application.Features.PostToApproval.Dto;
using EventStormingPost.Application.Helpers.Interfaces;
using MediatR;

namespace EventStormingPost.Application.Features.PostToApproval.Commands
{
    public class UpdateCommand : IRequest<Unit>
    {
        public PostToApprovalDto Dto { get; }

        public UpdateCommand(PostToApprovalDto dto)
        {
            Dto = dto;
        }
    }

    public class UpdateHandler : IRequestHandler<UpdateCommand>
    {
        private readonly IPostToApprovalRepository postToApprovalRepository;

        public UpdateHandler(IPostToApprovalRepository postToApprovalRepository)
        {
            this.postToApprovalRepository = postToApprovalRepository;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            if (request.Dto?.Id == null)
            {
                throw new ArgumentNullException(nameof(request.Dto.Id));
            }

            bool result = postToApprovalRepository.Update(request.Dto);

            return Unit.Value;
        }
    }
}
