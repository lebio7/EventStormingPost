using EventStormingPost.Application.Features.PostToApproval.Commands;
using EventStormingPost.Application.Features.PostToApproval.Dto;
using EventStormingPost.Application.Features.PostToApproval.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventStormingPost.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostToApprovalController
    {
        private readonly IMediator mediator;
        public PostToApprovalController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PostToApprovalDto>> GetPostsToApprove()
        {
            return await mediator.Send(new GetPostsToApproveQuery());
        }

        [HttpPost]
        public async Task<Guid> Create([FromBody] PostToApprovalDto dto)
        {
            return await mediator.Send(new CreateCommand(dto));
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] PostToApprovalDto dto)
        {
            return await mediator.Send(new UpdateCommand(dto));
        }
    }
}
