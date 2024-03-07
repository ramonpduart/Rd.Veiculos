using Moq;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Adicionar;
using Rd.Veiculos.Api.Core.Entities;
using Rd.Veiculos.Api.Core.Repositories;

namespace Rd.Veiculos.Tests.Unit.Application.Commands
{
    public class AdicionarVeiculoCommandHandlerTest
    {
        private readonly Mock<IVeiculoRepository> _veiculoRepository;
        private readonly CancellationToken _cancellationToken;
        private readonly AdicionarVeiculoCommandHandler _handler;

        public AdicionarVeiculoCommandHandlerTest()
        {
            _veiculoRepository = new Mock<IVeiculoRepository>();
            _cancellationToken = CancellationToken.None;
            _handler = new(_veiculoRepository.Object);
        }

        [Fact]
        public async void AdicionarVeiculoCommandHandler_ComDadosValidos_DeveSalvarNaBase()
        {
            /// Arrange
            var command = new AdicionarVeiculoCommand()
            {
                Marca = "Fiat",
                Modelo = "Uno",
                AnoFabricacao = 2008,
                AnoModelo = 2009,
                QuantidadeLugares = 5,
                Categoria = "Passeio"
            };

            /// Act
            var result = await _handler.Handle(command, _cancellationToken);


            /// Assert
            _veiculoRepository.Verify(v => v.Adicionar(It.IsAny<VeiculoEntity>(), _cancellationToken), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(command.Marca, result.Marca);
            Assert.Equal(command.Modelo, result.Modelo);
            Assert.Equal(command.AnoFabricacao, result.AnoFabricacao);
            Assert.Equal(command.AnoModelo, result.AnoModelo);
            Assert.Equal(command.QuantidadeLugares, result.QuantidadeLugares);
            Assert.Equal(command.Categoria, result.Categoria);
        }
    }
}
