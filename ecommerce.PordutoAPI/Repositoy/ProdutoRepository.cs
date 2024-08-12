using AutoMapper;
using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Model;

namespace ecommerce.PordutoAPI.Repositoy
{

    public class ProdutoRepository : IProdutoRepository
    {

        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProdutoRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProdutoVO> Criar(ProdutoVO produtoVO)
        {
            Produto produto = _mapper.Map<Produto>(produtoVO);
            await _context.Criar(produto);
            return _mapper.Map<ProdutoVO>(produto);
        }
        public async Task<ProdutoVO> Atualizar(ProdutoVO produtoVO)
        {
            Produto produto = _mapper.Map<Produto>(produtoVO);
            await _context.Atualizar(produto);
            return _mapper.Map<ProdutoVO>(produto);
        }        
        public async Task<IEnumerable<ProdutoVO>> Buscar()
        {
            List<Produto> produtos = await _context.Buscar();
            return _mapper.Map<List<ProdutoVO>>(produtos);
        }
        public async Task<ProdutoVO> BuscarPorId(int id)
        {
            Produto produto = await _context.BuscarPorId(id);
            return _mapper.Map<ProdutoVO>(produto);
        }
        public async Task<bool> Deletar(int id)
        {
            try
            {
                Produto produto = await _context.BuscarPorId(id);

                if (produto.Id <= 0)
                {
                    return false;

                }else
                {
                   await _context.Deletar(id);
                   return true;
                }
              
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
