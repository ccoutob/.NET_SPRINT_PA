using Personal.Assist.Feedback.Domain.Entities;
using Personal.Assist.Feedback.Domain.Interfaces;
using Personal.Assist.Feedback.Domain.Interfaces.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Personal.Assist.Estatistica.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedbackController : ControllerBase
	{
		private readonly IFeedbackApplicationService _applicationService;

		public FeedbackController(IFeedbackApplicationService applicationService)
		{
			_applicationService = applicationService;
		}

		[HttpGet]
		[Produces<IEnumerable<FeedbackEntity>>]
		public IActionResult Get()
		{
			var categorias = _applicationService.ObterTodosFeedback();

			if (categorias is not null)
				return Ok(categorias);

			return BadRequest("Não foi possivel obter os dados");
		}


		[HttpGet("{id}")]
		[Produces<FeedbackEntity>]
		public IActionResult GetPorId(string id)
		{
			var categorias = _applicationService.ObterFeedbackPorId(id);

			if (categorias is not null)
				return Ok(categorias);

			return BadRequest("Não foi possivel obter os dados");
		}

		[HttpPost]
		[Produces<FeedbackEntity>]
		public IActionResult Post(IFeedbackDto entity)
		{
			try
			{
				var categorias = _applicationService.AdicionarFeedback(entity);

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
		[Produces<FeedbackEntity>]
		public IActionResult Put(string id, IFeedbackDto entity)
		{
			try
			{
				var categorias = _applicationService.EditarFeedback(id, entity);

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
		[Produces<FeedbackEntity>]
		public IActionResult Delete(string id)
		{
			var categorias = _applicationService.RemoverFeedback(id);

			if (categorias is not null)
				return Ok(categorias);

			return BadRequest("Não foi possivel deletar os dados");
		}
	}
}
