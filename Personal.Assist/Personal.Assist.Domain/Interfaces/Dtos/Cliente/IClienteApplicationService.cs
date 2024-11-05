using Personal.Assist.Cliente.Domain.Entities;
using Personal.Assist.Cliente.Domain.Interfaces.Dtos;

namespace Personal.Assist.Cliente.Domain.Interfaces
{
    public interface IClienteApplicationService
    {
        IEnumerable<ClienteEntity> ObterTodosClientes();
        ClienteEntity ObterClientePorId(int id);
        ClienteEntity AdicionarCliente(IClienteDto entity);
        ClienteEntity EditarCliente(int id, IClienteDto entity);
        ClienteEntity RemoverCliente(int id);
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);

    }
}
    