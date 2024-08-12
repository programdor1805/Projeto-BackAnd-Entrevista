using ecommerce.PordutoAPI.Data.ValueObjects;

namespace ecommerce.PordutoAPI.Repositoy
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<DepartamentoVO>> Buscar();
    }
}
