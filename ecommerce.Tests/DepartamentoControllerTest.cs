using ecommerce.PordutoAPI.Controllers;
using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ecommerce.Tests
{
    public class DepartamentoControllerTest
    {
        private readonly DepartamentoController _controller;
        private readonly Mock<IDepartamentoRepository> _repositoryMock;

        public DepartamentoControllerTest()
        {
            _repositoryMock = new Mock<IDepartamentoRepository>();
            _controller = new DepartamentoController(_repositoryMock.Object);
        }

        [Fact]
        public async Task BuscarTodos_DeveRetornarOkResult_ComUmaListaDeDepartamentos()
        {
            // Preparação
            var departamentos = new List<DepartamentoVO>
            {
                new DepartamentoVO { Id = 1, Codigo = "D001", Descricao = "Departamento 1" },
                new DepartamentoVO { Id = 2, Codigo = "D002", Descricao = "Departamento 2" }
            };
            _repositoryMock.Setup(repo => repo.Buscar()).ReturnsAsync(departamentos);

            // Ação
            var resultado = await _controller.BuscarTodos();

            // Verificação
            var resultadoOk = Assert.IsType<OkObjectResult>(resultado.Result);
            var valorRetornado = Assert.IsType<List<DepartamentoVO>>(resultadoOk.Value);
            Assert.Equal(2, valorRetornado.Count);
        }
    }
}
