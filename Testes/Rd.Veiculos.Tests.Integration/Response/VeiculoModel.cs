namespace Rd.Veiculos.Tests.Integration.Response
{
    public class VeiculoModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int QuantidadeLugares { get; set; }
        public string Categoria { get; set; }
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
