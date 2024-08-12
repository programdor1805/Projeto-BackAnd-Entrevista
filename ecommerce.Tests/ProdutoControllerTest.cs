using ecommerce.PordutoAPI.Controllers;
using ecommerce.PordutoAPI.Data.ValueObjects;
using ecommerce.PordutoAPI.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace ecommerce.Tests
{
    public class ProdutoControllerTest
    {


        private readonly ProdutoController _controller;
        private readonly Mock<IProdutoRepository> _repositoryMock;

        public ProdutoControllerTest()
        {
            _repositoryMock = new Mock<IProdutoRepository>();
            _controller = new ProdutoController(_repositoryMock.Object);
        }

        [Fact]
        public async Task BuscarTodos_DeveRetornarOkResult_ComUmaListaDeProdutos()
        {
            // Arrange
            var produtos = new List<ProdutoVO>
            {
                new ProdutoVO { Id = 1, Codigo = "P001", Descricao = "Produto 1", DepartamentoId = 1, Preco = 10, Status = true },
                new ProdutoVO { Id = 2, Codigo = "P002", Descricao = "Produto 2", DepartamentoId = 2, Preco = 20, Status = true }
            };
            _repositoryMock.Setup(repo => repo.Buscar()).ReturnsAsync(produtos);

            // Act
            var result = await _controller.BuscarTodos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<ProdutoVO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task BuscarPorId_DeveRetornarNotFound_QuandoProdutoNaoExistir()
        {
            // Arrange
            var produto = new ProdutoVO { Id = 0, Codigo = "", Descricao = "Produto Não Existente", DepartamentoId = 0, Preco = 0, Status = false };
            _repositoryMock.Setup(repo => repo.BuscarPorId(It.IsAny<int>())).ReturnsAsync(produto);

            // Act
            var result = await _controller.BuscarPorId(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task BuscarPorId_DeveRetornarOkResult_QuandoProdutoExistir()
        {
            // Arrange
            var produto = new ProdutoVO { Id = 1, Codigo = "P001", Descricao = "Produto 1", DepartamentoId = 1, Preco = 10, Status = true };
            _repositoryMock.Setup(repo => repo.BuscarPorId(1)).ReturnsAsync(produto);

            // Act
            var result = await _controller.BuscarPorId(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ProdutoVO>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task Criar_DeveRetornarBadRequest_QuandoProdutoForNulo()
        {
            // Act
            var result = await _controller.Criar(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Criar_DeveRetornarOkResult_QuandoProdutoForCriado()
        {
            // Arrange
            var produto = new ProdutoVO { Id = 1, Codigo = "P001", Descricao = "Produto 1", DepartamentoId = 1, Preco = 10, Status = true };
            _repositoryMock.Setup(repo => repo.Criar(It.IsAny<ProdutoVO>())).ReturnsAsync(produto);

            // Act
            var result = await _controller.Criar(produto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ProdutoVO>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task Atualizar_DeveRetornarBadRequest_QuandoProdutoForNulo()
        {
            // Act
            var result = await _controller.Atualizar(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task Atualizar_DeveRetornarOkResult_QuandoProdutoForAtualizado()
        {
            // Arrange
            var produto = new ProdutoVO { Id = 1, Codigo = "P001", Descricao = "Produto Atualizado", DepartamentoId = 1, Preco = 20, Status = true };
            _repositoryMock.Setup(repo => repo.Atualizar(It.IsAny<ProdutoVO>())).ReturnsAsync(produto);

            // Act
            var result = await _controller.Atualizar(produto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ProdutoVO>(okResult.Value);
            Assert.Equal(20, returnValue.Preco);
            Assert.Equal("Produto Atualizado", returnValue.Descricao);
        }

        [Fact]
        public async Task Deletar_DeveRetornarBadRequest_QuandoProdutoNaoPuderSerDeletado()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.Deletar(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _controller.Deletar(1);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Deletar_DeveRetornarOkResult_QuandoProdutoForDeletado()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.Deletar(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _controller.Deletar(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

