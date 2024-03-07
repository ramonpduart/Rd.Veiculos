namespace Rd.Veiculos.Api.Infraestructure.SqlServer.Scripts
{
    public static class VeiculoScript
    {
        public static readonly string ADICIONAR = @"
            INSERT INTO [dbo].[veiculo]
               ([id]
               ,[marca]
               ,[modelo]
               ,[ano_fabricacao] 
               ,[ano_modelo]
               ,[quantidade_lugares]
               ,[categoria]
               ,[ativo]
               ,[data_criacao]
               ,[data_alteracao])
            VALUES
               (@Id
               ,@Marca
               ,@Modelo
               ,@AnoFabricacao
               ,@AnoModelo
               ,@QuantidadeLugares
               ,@Categoria
               ,@Ativo
               ,@DataCriacao
               ,@DataAlteracao)";

        public static readonly string ATUALIZAR = @"
            UPDATE [dbo].[veiculo]
            SET
                [marca] = @Marca,
                [modelo] = @Modelo, 
                [ano_fabricacao] = @AnoFabricacao,
                [ano_modelo] = @AnoModelo,
                [quantidade_lugares] = @QuantidadeLugares,
                [categoria] = @Categoria,
                [data_alteracao] = @DataAlteracao  
            WHERE id = @Id";

        public static readonly string EXCLUIR = @"
            UPDATE [dbo].[veiculo]
            SET
                [ativo] = @Ativo,
                [data_alteracao] = @DataAlteracao  
            WHERE id = @Id";

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
