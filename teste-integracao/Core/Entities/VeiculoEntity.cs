namespace Rd.Veiculos.Api.Core.Entities
{
    public class VeiculoEntity : BaseEntity<VeiculoEntity>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int QuantidadeLugares { get; set; }
        public string Categoria { get; set; }

        public VeiculoEntity()
        {

        }

        public VeiculoEntity(Guid id, string marca, string modelo, short anoFabricacao, short anoModelo, short quantidadeLugares, string categoria, bool ativo, DateTime dataCriacao, DateTime dataAlteracao)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            QuantidadeLugares = quantidadeLugares;
            Categoria = categoria;
            Ativo = ativo;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
        }

        public void Adicionar(string marca, string modelo, int anoFabricacao, int anoModelo, int quantidadeLugares, string categoria)
        {
            Id = Guid.NewGuid();
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            QuantidadeLugares = quantidadeLugares;
            Categoria = categoria;
            Ativo = true;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public void Alterar(string marca, string modelo, int anoFabricacao, int anoModelo, int quantidadeLugares, string categoria)
        {
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            QuantidadeLugares = quantidadeLugares;
            Categoria = categoria;
            DataAlteracao = DateTime.Now;
        }

        public void Excluir()
        {
            Ativo = false;
            DataAlteracao = DateTime.Now;
        }
    }
}
