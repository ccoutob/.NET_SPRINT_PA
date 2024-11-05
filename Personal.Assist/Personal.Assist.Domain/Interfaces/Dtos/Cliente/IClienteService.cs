using Personal.Assist.Cliente.Domain.Entities;

namespace Personal.Assist.Cliente.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    }
}
