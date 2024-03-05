using Rd.Veiculos.Api.Core.Repositories;
using Rd.Veiculos.Api.Infraestructure.SqlServer.Repositories;

namespace Rd.Veiculos.Api.Infraestructure.SqlServer
{
    public static class Setup
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            services.AddSingleton<IVeiculoRepository, VeiculoRepository>();
            return services;
        }
    }
}
