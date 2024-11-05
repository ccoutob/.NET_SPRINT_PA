using Personal.Assist.Cliente.Data.AppData;
using Personal.Assist.Cliente.Data.Repositories;
using Personal.Assist.Cliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Personal.Assist.Cliente.Tests
{
    public class ClienteRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly ClienteRepository _clienteRepository;

        public ClienteRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(_options);
            _clienteRepository = new ClienteRepository(_context);
        }

        [Fact]
        public void Adicionar_DeveAdicionarClienteERetornarClienteEntity()
        {
            // Arrange
            var cliente = new ClienteEntity { Nome = "João", SobreNome = "Silva", Email = "joao.silva@example.com", Idade = 30 };

            // Act
            var resultado = _clienteRepository.Adicionar(cliente);

            // Assert
            var clienteNoDb = _context.Cliente.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(clienteNoDb);
            Assert.Equal(cliente.Nome, clienteNoDb.Nome);
            Assert.Equal(cliente.SobreNome, clienteNoDb.SobreNome);
            Assert.Equal(cliente.Email, clienteNoDb.Email);
            Assert.Equal(cliente.Idade, clienteNoDb.Idade);
        }

        [Fact]
        public void Editar_DeveAtualizarClienteERetornarClienteEntity_QuandoClienteExiste()
        {
            // Arrange
            var cliente = new ClienteEntity { Nome = "Maria", SobreNome = "Oliveira", Email = "maria.oliveira@example.com", Idade = 25 };
            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            cliente.Nome = "Maria Atualizada";
            cliente.SobreNome = "Oliveira Atualizada";

            // Act
            var resultado = _clienteRepository.Editar(cliente);

            // Assert
            var clienteNoDb = _context.Cliente.FirstOrDefault(c => c.Id == cliente.Id);
            Assert.NotNull(clienteNoDb);
            Assert.Equal("Maria Atualizada", clienteNoDb.Nome);
            Assert.Equal("Oliveira Atualizada", clienteNoDb.SobreNome);
        }

        [Fact]
        public void ObterPorId_DeveRetornarClienteEntity_QuandoClienteExiste()
        {
            // Arrange
            var cliente = new ClienteEntity { Nome = "Carlos", SobreNome = "Santos", Email = "carlos.santos@example.com", Idade = 40 };
            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            // Act
            var resultado = _clienteRepository.ObterPorId(cliente.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(cliente.Id, resultado.Id);
            Assert.Equal(cliente.Nome, resultado.Nome);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeClientes_QuandoExistiremClientes()
        {
            // Arrange
            var clientes = new List<ClienteEntity>
            {
                new ClienteEntity { Nome = "Paula", SobreNome = "Martins", Email = "paula.martins@example.com", Idade = 35 },
                new ClienteEntity { Nome = "Rafael", SobreNome = "Ferreira", Email = "rafael.ferreira@example.com", Idade = 28 }
            };
            _context.Cliente.AddRange(clientes);
            _context.SaveChanges();

            // Act
            var resultado = _clienteRepository.ObterTodos();

            // Assert
            Assert.Equal(clientes.Count, resultado.Count());
            Assert.Equal(clientes[0].Nome, resultado.First().Nome);
            Assert.Equal(clientes[1].Nome, resultado.Last().Nome);
        }

        [Fact]
        public void Remover_DeveRemoverClienteERetornarClienteEntity_QuandoClienteExiste()
        {
            // Arrange
            var cliente = new ClienteEntity { Nome = "Rogério", SobreNome = "Souza", Email = "rogerio.souza@example.com", Idade = 45 };
            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            // Act
            var resultado = _clienteRepository.Remover(cliente.Id);

            // Assert
            var clienteNoDb = _context.Cliente.FirstOrDefault(c => c.Id == cliente.Id);

            Assert.Null(clienteNoDb);
            Assert.Equal(cliente, resultado);
        }
    }
}
