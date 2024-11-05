using Personal.Assist.Estatistica.Domain.Entities;
using Personal.Assist.Estatistica.Domain.Interfaces;
using Personal.Assist.Estatistica.Domain.Interfaces.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Personal.Assist.Estatistica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatisticaController : ControllerBase
    {
        private readonly IEstatisticaApplicationService _applicationService;

        public EstatisticaController(IEstatisticaApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Produces<IEnumerable<EstatisticaEntity>>]
        public IActionResult Get()
        {
            var categorias = _applicationService.ObterTodasEstatisticas();

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<EstatisticaEntity>]
        public IActionResult GetPorId(string id)
        {
            var categorias = _applicationService.ObterEstatisticaPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        [HttpPost]
        [Produces<EstatisticaEntity>]
        public IActionResult Post(IEstatisticaDto entity)
        {
            try
            {
                var categorias = _applicationService.AdicionarEstatistica(entity);

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
        [Produces<EstatisticaEntity>]
        public IActionResult Put(string id, IEstatisticaDto entity)
        {
            try
            {
                var categorias = _applicationService.EditarEstatistica(id, entity);

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
        [Produces<EstatisticaEntity>]
        public IActionResult Delete(string id)
        {
            var categorias = _applicationService.RemoverEstatistica(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
