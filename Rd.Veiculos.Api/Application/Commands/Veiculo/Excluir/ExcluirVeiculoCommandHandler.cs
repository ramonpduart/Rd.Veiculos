using MediatR;
using Rd.Veiculos.Api.Core.Repositories;

namespace Rd.Veiculos.Api.Application.Commands.Veiculo.Excluir
{
    public class ExcluirVeiculoCommandHandler : IRequestHandler<ExcluirVeiculoCommand, bool>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ExcluirVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> Handle(ExcluirVeiculoCommand command, CancellationToken cancellationToken)
        {
            var veiculoEntity = await _veiculoRepository.ObterPorId(command.Id, cancellationToken) ?? throw new ArgumentNullException("Veículo não encontrado");
            veiculoEntity.Excluir();
            await _veiculoRepository.Excluir(veiculoEntity, cancellationToken);
            return true;
        }
    }
}
