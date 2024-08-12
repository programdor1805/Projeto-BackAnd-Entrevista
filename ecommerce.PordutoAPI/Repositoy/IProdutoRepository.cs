using ecommerce.PordutoAPI.Data.ValueObjects;

namespace ecommerce.PordutoAPI.Repositoy
{
    public interface IProdutoRepository
    {
        Task<ProdutoVO> Criar(ProdutoVO Produto);
        Task<ProdutoVO> Atualizar(ProdutoVO Produto);
        Task<IEnumerable<ProdutoVO>> Buscar();
        Task<ProdutoVO> BuscarPorId( int id);       
        Task<bool> Deletar(int id);   
    }
}
