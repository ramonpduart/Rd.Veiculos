using MediatR;
using Rd.Veiculos.Api.Core.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Rd.Veiculos.Api.Application.Commands.Veiculo.Alterar
{
    public class AlterarVeiculoCommandHandler : IRequestHandler<AlterarVeiculoCommand, bool>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public AlterarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> Handle(AlterarVeiculoCommand command, CancellationToken cancellationToken)
        {
            var veiculoEntity = await _veiculoRepository.ObterPorId(command.Id, cancellationToken) ?? throw new ValidationException("Veículo não encontrado");
            veiculoEntity.Alterar(command.Marca, command.Modelo, command.AnoFabricacao, command.AnoModelo, command.QuantidadeLugares, command.Categoria);
            await _veiculoRepository.Alterar(veiculoEntity, cancellationToken);
            return true;
        }
    }
}
