using Personal.Assist.Cliente.Domain.Entities;

namespace Personal.Assist.Cliente.Domain.Interfaces
{
    public interface IClienteRepository
    {
        ClienteEntity? ObterPorId(int id);
        IEnumerable<ClienteEntity>? ObterTodos();
        ClienteEntity? Adicionar(ClienteEntity cliente);
        ClienteEntity? Editar(ClienteEntity cliente);
        ClienteEntity? Remover(int id);
    }
}
