using Personal.Assist.Feedback.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace Personal.Assist.Feedback.Domain.Interfaces
{
    public interface IFeedbackApplicationService
    {
        IEnumerable<IFeedbackRequestDto> ObterTodosFeedback();
        IFeedbackRequestDto ObterFeedbackPorId(string id);
        IFeedbackRequestDto AdicionarFeedback(IFeedbackDto entity);
        IFeedbackRequestDto EditarFeedback(string id, IFeedbackDto entity);
        IFeedbackRequestDto RemoverFeedback(string id);
    }
}
