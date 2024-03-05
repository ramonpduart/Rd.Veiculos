using MediatR;
using Rd.Veiculos.Api.Core.Entities;
using Rd.Veiculos.Api.Core.Repositories;

namespace Rd.Veiculos.Api.Application.Commands.Veiculo.Adicionar
{
    public class AdicionarVeiculoCommandHandler : IRequestHandler<AdicionarVeiculoCommand, VeiculoEntity>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public AdicionarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<VeiculoEntity> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculoEntity = new VeiculoEntity();
            veiculoEntity.Adicionar(request.Marca, request.Modelo, request.AnoFabricacao, request.AnoModelo, request.QuantidadeLugares, request.Categoria);
            await _veiculoRepository.Adicionar(veiculoEntity, cancellationToken);
            return veiculoEntity;
        }
    }
}
