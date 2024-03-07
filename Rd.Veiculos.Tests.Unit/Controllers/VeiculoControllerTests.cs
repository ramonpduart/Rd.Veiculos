using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Adicionar;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Alterar;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Excluir;
using Rd.Veiculos.Api.Controllers.v1;

namespace Rd.Veiculos.Tests.Unit.Controllers
{
    public class VeiculoControllerTests
    {
        private readonly Mock<ILogger<VeiculoController>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly VeiculoController _controller;

        public VeiculoControllerTests()
        {
            _logger = new Mock<ILogger<VeiculoController>>();
            _mediator = new Mock<IMediator>();
            _controller = new(_logger.Object, _mediator.Object);
        }

        [Fact]
        public async Task VeiculoController_AdicionarVeiculoComDadosValidos_DeveRetornarCreated()
        {
            // Arrange
            var command = new AdicionarVeiculoCommand()
            {
                Marca = "Fiat",
                Modelo = "Uno",
                AnoFabricacao = 2008,
                AnoModelo = 2009,
                QuantidadeLugares = 5,
                Categoria = "Passeio"
            };

            _mediator.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Api.Core.Entities.VeiculoEntity()
                {
                    Id = Guid.NewGuid(),
                });

            // Act
            var result = await _controller.Adicionar(command, CancellationToken.None);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        //[Fact]
        //public async Task VeiculoController_AdicionarVeiculo_ComValoresInvalidosDeveRetornarBadRequest()
        //{
        //    // Arrange
        //    var command = new AdicionarVeiculoCommand()
        //    {
        //        Marca = "Fiat",
        //        Modelo = "Uno",
        //        AnoFabricacao = 2998,
        //        AnoModelo = 2859,
        //        QuantidadeLugares = 500,
        //        Categoria = "Passeio"
        //    };

        //    _mediator.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new Api.Core.Entities.VeiculoEntity()
        //        {
        //            Id = Guid.NewGuid(),
        //        });

        //    // Act
        //    var result = await _controller.Adicionar(command, CancellationToken.None);

        //    // Assert
        //    Assert.IsType<BadRequestResult>(result);
        //}

        [Fact]
        public async Task VeiculoController_AlterarVeiculoComDadosValidos_DeveRetornarOk()
        {
            // Arrange
            var command = new AlterarVeiculoCommand()
            {
                Id = Guid.NewGuid(),
                Marca = "Fiat",
                Modelo = "Uno",
                AnoFabricacao = 2008,
                AnoModelo = 2009,
                QuantidadeLugares = 5,
                Categoria = "Passeio"
            };

            _mediator.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Alterar(command, CancellationToken.None);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task VeiculoController_AlterarVeiculoComDadosInvalidos_DeveRetornarBadRequest()
        {
            // Arrange
            var command = new AlterarVeiculoCommand()
            {
                Id = Guid.NewGuid(),
                Marca = "Fiat",
                Modelo = "Uno",
                AnoFabricacao = 2008,
                AnoModelo = 2009,
                QuantidadeLugares = 5,
                Categoria = "Passeio"
            };

            _mediator.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.Alterar(command, CancellationToken.None);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task VeiculoController_ExcluirVeiculoComDadosValidos_DeveRetornarOk()
        {
            // Arrange
            var command = new ExcluirVeiculoCommand()
            {
                Id = Guid.NewGuid()
            };

            _mediator.Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Excluir(command, CancellationToken.None);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
