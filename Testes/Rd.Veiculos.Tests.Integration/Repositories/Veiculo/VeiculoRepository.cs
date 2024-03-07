using Dapper;
using Rd.Veiculos.Tests.Integration.Response;
using System.Data;

namespace Rd.Veiculos.Tests.Integration.Repositories.Veiculo
{
    public class VeiculoRepository : BaseSqlServerRepository
    {
        public VeiculoRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<VeiculoModel> ObterPorId(Guid id, bool ativo, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id, DbType.Guid);
            parameters.Add("@Ativo", ativo, DbType.Boolean);

            return await QueryFirstOrDefaultAsync<VeiculoModel>(
                new CommandDefinition(
                    VeiculoScript.OBTER,
                    parameters,
                    cancellationToken: cancellationToken
                )
            );
        }
    }
}
