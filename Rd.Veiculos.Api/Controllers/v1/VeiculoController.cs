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
        private readonly IMediator _mediator;

        public VeiculoController(ILogger<VeiculoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Adicionar(
            [FromBody] AdicionarVeiculoCommand command,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"Adicionando veículo - {command.Marca} {command.Modelo}");
            var veiculo = await _mediator.Send(command, cancellationToken);
            _logger.LogInformation($"Veículo adicionado - {command.Marca} {command.Modelo} - ID: {veiculo.Id}");
            return Created("Id", new { veiculo.Id });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Alterar(
            [FromBody] AlterarVeiculoCommand command,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"Alterando veículo - {command.Marca} {command.Modelo}");
            var result = await _mediator.Send(command, cancellationToken);
            _logger.LogInformation($"Veículo alterado - {command.Marca} {command.Modelo} - Sucess: {result}");
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Excluir(
            [FromBody] ExcluirVeiculoCommand command,
            CancellationToken cancellationToken
        )
        {
            _logger.LogInformation($"Excluindo veículo - {command.Id}");
            var result = await _mediator.Send(command, cancellationToken);
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