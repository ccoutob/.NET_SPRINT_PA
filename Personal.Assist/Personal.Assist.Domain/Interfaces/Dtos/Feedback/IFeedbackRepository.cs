using Personal.Assist.Feedback.Domain.Entities;
using System.Collections.Generic;

namespace Personal.Assist.Feedback.Domain.Interfaces
{
    public interface IFeedbackRepository
    {
        IEnumerable<FeedbackEntity> ObterTodos();
        FeedbackEntity ObterPorId(string id);
        FeedbackEntity Adicionar(FeedbackEntity cliente);
        FeedbackEntity Editar(FeedbackEntity cliente);
        FeedbackEntity Remover(string id);
    }
}
