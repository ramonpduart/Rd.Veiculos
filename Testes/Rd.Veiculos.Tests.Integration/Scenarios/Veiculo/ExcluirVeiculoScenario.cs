using Rd.Veiculos.Tests.Integration.Requests.Veiculo;
using Rd.Veiculos.Tests.Integration.Response;
using System.Net;
using System.Net.Http.Json;

namespace Rd.Veiculos.Tests.Integration.Scenarios.Veiculo
{

    [TestFixture]
    public class ExcluirVeiculoScenario : BaseScenario
    {
        public Guid IdCenario01 { get; set; }

        /// <summary>
        /// Método acionado antes da inicializacao dos cenários de testes
        /// Utilizado para preparar os dados para a execução dos cenários de testes sem depêndencias com outros cenários
        /// É realizado a adicao de um veiculo, para posteriormente a alteração do mesmo
        /// </summary>
        /// <returns></returns>
        [OneTimeSetUp]
        public async Task PrepararDadosDoCenario()
        {
            TestContext.Progress.WriteLine($"Adicionando dependencias do cenarios de exclusao");
            var command = new AdicionarVeiculoCommand("Excluir", "Cenario01", 2024, 2024, 5, "Passeio");
            var response = await _veiculoService.Adicionar(command, ctx);
            var retornoApi = await response.Content.ReadFromJsonAsync<AdicionarVeiculoResponse>(cancellationToken: ctx);
            IdCenario01 = retornoApi.Id;
            TestContext.Progress.WriteLine($"Finalizando dependencias dos cenarios de exclusao");
            TestContext.Progress.WriteLine($"--------------------");
        }

        [Test]
        public async Task ExcluirVeiculo_ComVeiculoCadastrado_DeveCancelarNaBaseDeDados()
        {
            /// Arrange
            var command = new ExcluirVeiculoCommand(IdCenario01);

            /// Act
            var response = await _veiculoService.Excluir(command, ctx);
            var retornoBaseDados = await _veiculoRepository.ObterPorId(IdCenario01, false, ctx);

            /// Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(retornoBaseDados, Is.Not.Null);
            Assert.That(retornoBaseDados.Ativo, Is.False);
        }

        [Test]
        public async Task ExcluirVeiculo_ComVeiculoSemCadastro_DeveRetornarVeiculoNaoCadastrado()
        {
            /// Arrange
            var command = new ExcluirVeiculoCommand(Guid.NewGuid());

            /// Act
            var response = await _veiculoService.Excluir(command, ctx);

            /// Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.UnprocessableEntity));

        }
    }
}
