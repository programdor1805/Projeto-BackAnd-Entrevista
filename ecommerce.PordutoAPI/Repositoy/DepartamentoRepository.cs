using AutoMapper;
using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Model;

namespace ecommerce.PordutoAPI.Repositoy
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public DepartamentoRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        public async Task<IEnumerable<DepartamentoVO>> Buscar()
        {
            List<Departamento> departamentos = await _context.BuscarDepartamentos();
            return _mapper.Map<List<DepartamentoVO>>(departamentos);
        }

    }
}
