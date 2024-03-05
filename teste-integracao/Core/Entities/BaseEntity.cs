namespace Rd.Veiculos.Api.Core.Entities
{
    public class BaseEntity<TEntity> where TEntity : class
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
