namespace Rd.Veiculos.Api.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task Adicionar(T entity, CancellationToken cancellationToken);
        Task Alterar(T entity, CancellationToken cancellationToken);
        Task Excluir(T entity, CancellationToken cancellationToken);
        Task<T> ObterPorId(Guid id, CancellationToken cancellationToken);
    }
}
