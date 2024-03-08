using Rd.Veiculos.Tests.Integration.Repositories.Veiculo;
using Rd.Veiculos.Tests.Integration.Services;

namespace Rd.Veiculos.Tests.Integration.Scenarios
{
    [TestFixture]
    public class BaseScenario
    {
        internal readonly VeiculoService _veiculoService;
        internal readonly VeiculoRepository _veiculoRepository;
        internal readonly CancellationToken ctx;

        /// <summary>
        /// Construtor base, utilizado para injetar as dependcias utilizadas nos cenários de testes
        /// </summary>
        public BaseScenario()
        {
            _veiculoService = new VeiculoService();
            _veiculoRepository = new VeiculoRepository(Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING"));
            ctx = new CancellationToken();
        }

        /// <summary>
        /// Método acionado antes da execução de cada cenário de teste
        /// </summary>
        [SetUp]
        public static void SetUp()
        {
            var cenario = TestContext.CurrentContext.Test.Name;
            TestContext.Progress.WriteLine($"Iniciando {cenario}");
        }

        /// <summary>
        /// Método acionado após a execução de cada cenário de teste
        /// Caso haja algum erro é impresso no console para melhor acompanhamento do dev
        /// </summary>
        [TearDown]
        public static void TearDown()
        {
            var cenario = TestContext.CurrentContext.Test.Name;
            var quantidadeErros = TestContext.CurrentContext.Result.FailCount;

            TestContext.Progress.WriteLine($"Sucesso: {quantidadeErros == 0}");

            if (quantidadeErros > 0)
                TestContext.Progress.WriteLine(TestContext.CurrentContext.Result.Message);

            TestContext.Progress.WriteLine($"Finalizando {cenario}");
            TestContext.Progress.WriteLine($"--------------------");
        }
    }
}
