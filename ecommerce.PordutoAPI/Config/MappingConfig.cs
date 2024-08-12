using AutoMapper;
using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Model;

namespace ecommerce.PordutoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoVO, Produto>();
                config.CreateMap<Produto, ProdutoVO>();

                config.CreateMap<DepartamentoVO, Departamento>();
                config.CreateMap<Departamento, DepartamentoVO>();

            });

            return mappingConfig;
        }
    }
}
