using EventStormingPost.Application.Features.Post.Dto;
using EventStormingPost.Application.Features.PostToApproval.Commands;
using MediatR;

namespace EventStormingPost.Application.Features.Post.Events
{
    public class PostCreatedEvent : INotification
    {
        public PostDto CreatedPost { get; }

        public PostCreatedEvent(PostDto createdPost)
        {
            CreatedPost = createdPost;
        }
    }
    public class PostCreatedEventHandler : INotificationHandler<PostCreatedEvent>
    {
        private readonly IMediator mediator;

        public PostCreatedEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(PostCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Post was created with Id {notification.CreatedPost.Id}");

            await mediator.Send(new CreateCommand(new PostToApproval.Dto.PostToApprovalDto()
            {
                Post = notification.CreatedPost.Id,
            }));
        }
    }
}
