namespace EventStormingPost.Application.Features.PostToApproval.Dto
{
    public class PostToApprovalDto
    {
        public Guid Id { get; set; }

        public Guid Post { get; set; }

        public bool IsApprove { get; set; }

        public string Description { get; set; }
    }
}
