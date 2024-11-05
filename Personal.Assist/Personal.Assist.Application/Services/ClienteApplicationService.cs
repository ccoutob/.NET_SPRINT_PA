using Personal.Assist.Cliente.Domain.Entities;
using Personal.Assist.Cliente.Domain.Interfaces;
using Personal.Assist.Cliente.Domain.Interfaces.Dtos;

namespace Personal.Assist.Cliente.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteService _clienteService;

        public ClienteApplicationService(IClienteRepository repository, IClienteService clienteService)
        {
            _repository = repository;
            _clienteService = clienteService;
        }

        public ClienteEntity? AdicionarCliente(IClienteDto entity)
        {
            return _repository.Adicionar(new ClienteEntity
            {
                Nome = entity.Nome,
                SobreNome = entity.SobreNome,
                Email = entity.Email,
                Idade = entity.Idade,
            });
        }

        public ClienteEntity? EditarCliente(int id, IClienteDto entity)
        {
            return _repository.Editar(new ClienteEntity
            {
                Id = id,
                Nome = entity.Nome,
                SobreNome = entity.SobreNome,
                Email = entity.Email,
                Idade = entity.Idade,
            });
        }

        public ClienteEntity? ObterClientePorId(int id)
        {
            return _repository.ObterPorId(id);
        }


        public IEnumerable<ClienteEntity>? ObterTodosClientes()
        {
            return _repository.ObterTodos();
        }

        public ClienteEntity? RemoverCliente(int id)
        {
            return _repository.Remover(id);
        }
        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var endereco = await _clienteService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return endereco;

            return null;
        }
    }
}
