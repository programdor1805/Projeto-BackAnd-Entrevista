using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Repositoy;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.PordutoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoVO>>> BuscarTodos()
        {
            var produto = await _repository.Buscar();
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoVO>> BuscarPorId(int id)
        {
            var produto = await _repository.BuscarPorId(id);

            if (produto.Id <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(produto);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoVO>> Criar(ProdutoVO vo)
        {
            if (vo == null)
            {
                return BadRequest();
            }
            else
            {
                var produto = await _repository.Criar(vo);
                return Ok(produto);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoVO>> Atualizar(ProdutoVO vo)
        {
            if (vo == null)
            {
                return BadRequest();
            }
            else
            {
                var produto = await _repository.Atualizar(vo);
                return Ok(produto);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            var status = await _repository.Deletar(id);

            if (!status)
            {
                return BadRequest();
            }
            else
            {
                return Ok(status);
            }
        }
    }
}
