using MediatR;
using Rd.Veiculos.Api.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Rd.Veiculos.Api.Application.Commands.Veiculo.Adicionar
{
    public class AdicionarVeiculoCommand : IRequest<VeiculoEntity>
    {
        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }

        [Required]
        [Range(1886, 2099)]
        public int AnoFabricacao { get; set; }

        [Required]
        [Range(1886, 2099)]
        public int AnoModelo { get; set; }

        [Required]
        [Range(1, 100)]
        public int QuantidadeLugares { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }
    }
}
