using Dapper;
using Rd.Veiculos.Api.Core.Entities;
using Rd.Veiculos.Api.Core.Repositories;
using Rd.Veiculos.Api.Infraestructure.SqlServer.Scripts;
using System.Data;

namespace Rd.Veiculos.Api.Infraestructure.SqlServer.Repositories
{
    public class VeiculoRepository : BaseRepository, IVeiculoRepository
    {
        public VeiculoRepository() : base(Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING"))
        {

        }
        public async Task Adicionar(VeiculoEntity entity, CancellationToken cancellationToken)
        {
            await ExecuteAsync(
                new CommandDefinition(
                    VeiculoScript.ADICIONAR,
                    PreecherParametros(entity),
                    cancellationToken: cancellationToken
                )
            );
        }

        public async Task Alterar(VeiculoEntity entity, CancellationToken cancellationToken)
        {
            await ExecuteAsync(
                new CommandDefinition(
                    VeiculoScript.ATUALIZAR,
                    PreecherParametros(entity),
                    cancellationToken: cancellationToken
                )
            );
        }

        public async Task Excluir(VeiculoEntity entity, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", entity.Id, DbType.Guid);
            parameters.Add("@Ativo", entity.Ativo, DbType.Boolean);
            parameters.Add("@DataAlteracao", entity.DataAlteracao, DbType.DateTime);

            await ExecuteAsync(
                new CommandDefinition(
                    VeiculoScript.EXCLUIR,
                    parameters,
                    cancellationToken: cancellationToken
                )
            );
        }

        public async Task<VeiculoEntity> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", id, DbType.Guid);
            parameters.Add("@Ativo", true, DbType.Boolean);

            return await QueryFirstOrDefaultAsync<VeiculoEntity>(
                new CommandDefinition(
                    VeiculoScript.OBTER,
                    parameters,
                    cancellationToken: cancellationToken
                )
            );
        }

        private static DynamicParameters PreecherParametros(VeiculoEntity entity)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", entity.Id, DbType.Guid);
            parameters.Add("@Marca", entity.Marca, DbType.AnsiString, size: 100);
            parameters.Add("@Modelo", entity.Modelo, DbType.AnsiString, size: 200);
            parameters.Add("@AnoFabricacao", entity.AnoFabricacao, DbType.Int32);
            parameters.Add("@AnoModelo", entity.AnoModelo, DbType.Int32);
            parameters.Add("@QuantidadeLugares", entity.QuantidadeLugares, DbType.Int32);
            parameters.Add("@Categoria", entity.Categoria, DbType.AnsiString, size: 50);
            parameters.Add("@Ativo", entity.Ativo, DbType.Boolean);
            parameters.Add("@DataCriacao", entity.DataCriacao, DbType.DateTime);
            parameters.Add("@DataAlteracao", entity.DataAlteracao, DbType.DateTime);

            return parameters;
        }
    }
}
