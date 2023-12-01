using EventStormingPost.Application.Features.Post.Commands;
using EventStormingPost.Application.Features.Post.Dto;
using EventStormingPost.Application.Features.Post.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventStormingPost.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController
    {
        private readonly IMediator mediator;
        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PostDto>> GetAll()
        {
            return await mediator.Send(new GetAllQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] PostDto dto)
        {
            var result =  await mediator.Send(new CreateCommand(dto));

            return result;
        }
    }
}
