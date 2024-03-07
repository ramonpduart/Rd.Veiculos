namespace Rd.Veiculos.Tests.Integration.Requests.Veiculo
{
    public record AlterarVeiculoCommand
    {
        public Guid Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int AnoFabricacao { get; set; }

        public int AnoModelo { get; set; }

        public int QuantidadeLugares { get; set; }

        public string Categoria { get; set; }

        public AlterarVeiculoCommand(Guid id, string marca, string modelo, int anoFabricacao, int anoModelo, int quantidadeLugares, string categoria)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            QuantidadeLugares = quantidadeLugares;
            Categoria = categoria;
        }
    }
}
