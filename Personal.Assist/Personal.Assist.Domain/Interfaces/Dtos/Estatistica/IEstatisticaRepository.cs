using Personal.Assist.Estatistica.Domain.Entities;
using System.Collections.Generic;

namespace Personal.Assist.Estatistica.Domain.Interfaces
{
    public interface IEstatisticaRepository
    {
        IEnumerable<EstatisticaEntity> ObterTodos();
        EstatisticaEntity ObterPorId(string id);
        EstatisticaEntity Adicionar(EstatisticaEntity estatistica);
        EstatisticaEntity Editar(EstatisticaEntity estatistica);
        EstatisticaEntity Remover(string id);
    }
}
