using Personal.Assist.Cliente.Application.Dtos;
using Personal.Assist.Cliente.Domain.Entities;
using Personal.Assist.Cliente.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Personal.Assist.Cliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _applicationService;

        public ClienteController(IClienteApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<ClienteEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodosClientes();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<ClienteEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _applicationService.ObterClientePorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<ClienteEntity>]
        public IActionResult Post(ClienteDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarCliente(entity);

                if (categorias is not null)
                    return Ok(categorias);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpPut("{id}")]
        [Produces<ClienteEntity>]
        public IActionResult Put(int id, ClienteDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarCliente(id, entity);

                if (categorias is not null)
                    return Ok(categorias);

                return BadRequest("Não foi possivel editar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpDelete("{id}")]
        [Produces<ClienteEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _applicationService.RemoverCliente(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }

        [HttpGet("busca/endereco/{cep}")]
        [Produces<Endereco>]
        public async Task<IActionResult> GetDataService(string cep)
        {
            var endereco = await _applicationService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return Ok(endereco);

            return BadRequest("Não foi possivel obter os dados do endereço");
        }
    }
}
