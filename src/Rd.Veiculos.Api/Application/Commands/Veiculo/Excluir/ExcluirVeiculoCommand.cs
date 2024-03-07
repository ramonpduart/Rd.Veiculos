using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Rd.Veiculos.Api.Application.Commands.Veiculo.Excluir
{

    public class ExcluirVeiculoCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }

        public ExcluirVeiculoCommand(Guid id)
        {
            Id = id;
        }
    }
}
