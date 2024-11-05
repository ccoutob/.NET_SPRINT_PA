using Personal.Assist.Estatistica.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace Personal.Assist.Estatistica.Domain.Interfaces
{
    public interface IEstatisticaApplicationService
    {
        IEnumerable<IEstatisticaRequestDto> ObterTodasEstatisticas();
        IEstatisticaRequestDto ObterEstatisticaPorId(string id);
        IEstatisticaRequestDto AdicionarEstatistica(IEstatisticaDto entity);
        IEstatisticaRequestDto EditarEstatistica(string id, IEstatisticaDto entity);
        IEstatisticaRequestDto RemoverEstatistica(string id);
    }
}