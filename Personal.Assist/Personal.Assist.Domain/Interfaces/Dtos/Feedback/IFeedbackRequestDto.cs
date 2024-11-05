namespace Personal.Assist.Feedback.Domain.Interfaces.Dtos
{
    public interface IFeedbackRequestDto : IFeedbackDto
    {
        string Id { get; set; }
    }
}
