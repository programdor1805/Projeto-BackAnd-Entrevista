using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Repositoy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.PordutoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private IDepartamentoRepository _repository;

        public DepartamentoController(IDepartamentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartamentoVO>>> BuscarTodos()
        {
            var produto = await _repository.Buscar();
            return Ok(produto);
        }
    }
}
