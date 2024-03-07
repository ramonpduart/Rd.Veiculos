using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rd.Veiculos.Api.Application.Commands.Veiculo.Alterar
{
    public class AlterarVeiculoCommand : IRequest<bool>
    {
        [JsonIgnore]
        [Required]
        public Guid Id { get; set; }

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
