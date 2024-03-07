namespace Rd.Veiculos.Tests.Integration.Repositories.Veiculo
{
    internal class VeiculoScript
    {
        public static readonly string OBTER = @"
            SELECT 
                [id]
                ,[marca]
                ,[modelo]
                ,[ano_fabricacao] as anoFabricacao
                ,[ano_modelo] as anoModelo
                ,[quantidade_lugares] as quantidadeLugares
                ,[categoria]
                ,[ativo]
                ,[data_criacao] as dataCriacao
                ,[data_alteracao] as dataAlteracao
            FROM [dbo].[veiculo]
            WHERE id = @Id
            AND ativo = @Ativo";
    }
}
