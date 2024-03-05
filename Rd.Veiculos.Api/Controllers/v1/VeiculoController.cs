using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Adicionar;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Alterar;
using Rd.Veiculos.Api.Application.Commands.Veiculo.Excluir;
using Rd.Veiculos.Api.Core.Entities;
using Rd.Veiculos.Api.Core.Repositories;
using System.Net;

namespace Rd.Veiculos.Api.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly ILogger<VeiculoController> _logger;

        public VeiculoController(ILogger<VeiculoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<VeiculoEntity>> Adicionar(
            [FromBody] AdicionarVeiculoCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"Adicionando veículo - {command.Marca} {command.Modelo}");
            var veiculo = await mediator.Send(command, cancellationToken);
            _logger.LogInformation($"Veículo adicionado - {command.Marca} {command.Modelo} - ID: {veiculo.Id}");
            return Created("Id", new { veiculo.Id });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<VeiculoEntity>> Alterar(
            [FromBody] AlterarVeiculoCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"Alterando veículo - {command.Marca} {command.Modelo}");
            var result = await mediator.Send(command, cancellationToken);
            _logger.LogInformation($"Veículo alterado - {command.Marca} {command.Modelo} - Sucess: {result}");
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<VeiculoEntity>> Excluir(
            [FromBody] ExcluirVeiculoCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"Excluindo veículo - {command.Id}");
            var result = await mediator.Send(command, cancellationToken);
            _logger.LogInformation($"Veículo excluido - {command.Id} - Sucess: {result}");
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoEntity>> Obter(
            [FromRoute] Guid id,
            [FromServices] IVeiculoRepository veiculoRepository,
            CancellationToken cancellationToken
        )
        {
            var veiculo = await veiculoRepository.ObterPorId(id, cancellationToken);
            return Ok(veiculo);
        }
    }
}