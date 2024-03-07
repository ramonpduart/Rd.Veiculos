namespace Rd.Veiculos.Tests.Integration.Requests.Veiculo
{
    public record ExcluirVeiculoCommand
    {
        public Guid Id { get; set; }

        public ExcluirVeiculoCommand(Guid id)
        {
            Id = id;
        }
    }
}
