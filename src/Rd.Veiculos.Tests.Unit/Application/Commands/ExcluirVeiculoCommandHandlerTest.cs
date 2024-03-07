using Moq;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Excluir;
using Rd.Veiculos.Api.Core.Entities;
using Rd.Veiculos.Tests.Unit.Mocks;
using System.ComponentModel.DataAnnotations;

namespace Rd.Veiculos.Tests.Unit.Application.Commands
{
    public class ExcluirVeiculoCommandHandlerTest
    {
        private readonly CancellationToken _cancellationToken;

        public ExcluirVeiculoCommandHandlerTest()
        {
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async void ExcluirVeiculoCommandHandler_ComDadosValidos_DeveAtualizarNaBase()
        {
            /// Arrange
            var command = new ExcluirVeiculoCommand()
            {
                Id = Guid.NewGuid()
            };
            var _veiculoRepository = new VeiculoRepositoryMock().ObterPorIdComResultado();

            /// Act
            var _handler = new ExcluirVeiculoCommandHandler(_veiculoRepository.Object);
            var result = await _handler.Handle(command, _cancellationToken);

            /// Assert
            _veiculoRepository.Verify(v => v.Excluir(It.IsAny<VeiculoEntity>(), _cancellationToken), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task ExcluirVeiculoCommandHandler_ComDadoInvalidos_DeveRetornarExcessao()
        {
            try
            {
                /// Arrange
                var command = new ExcluirVeiculoCommand()
                {
                    Id = Guid.NewGuid()
                };
                var _veiculoRepository = new VeiculoRepositoryMock().ObterPorIdSemResultado();
                var _handler = new ExcluirVeiculoCommandHandler(_veiculoRepository.Object);

                /// Act
                await _handler.Handle(command, _cancellationToken);

            }
            catch (ValidationException ex)
            {
                /// Assert
                Assert.Equal("Veículo não encontrado", ex.Message);
            }
        }
    }
}
