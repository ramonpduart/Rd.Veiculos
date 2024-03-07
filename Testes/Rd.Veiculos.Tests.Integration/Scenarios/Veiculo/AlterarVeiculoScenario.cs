using Rd.Veiculos.Tests.Integration.Requests.Veiculo;
using Rd.Veiculos.Tests.Integration.Response;
using System.Net;
using System.Net.Http.Json;

namespace Rd.Veiculos.Tests.Integration.Scenarios.Veiculo
{

    [TestFixture]
    public class AlterarVeiculoScenario : BaseScenario
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
            TestContext.Progress.WriteLine($"Adicionando dependencias do cenarios de alteracao");
            var command = new AdicionarVeiculoCommand("Alterar", "Cenario01", 2024, 2024, 5, "Passeio");
            var response = await _veiculoService.Adicionar(command, ctx);
            var retornoApi = await response.Content.ReadFromJsonAsync<AdicionarVeiculoResponse>(cancellationToken: ctx);
            IdCenario01 = retornoApi.Id;
            TestContext.Progress.WriteLine($"Finalizando dependencias dos cenarios de alteracao");
            TestContext.Progress.WriteLine($"--------------------");
        }

        [Test]
        public async Task AlterarVeiculo_ComDadosValidos_DeveAtualizarBaseDeDados()
        {
            /// Arrange
            var command = new AlterarVeiculoCommand(IdCenario01, "Fiat", "Pulse", 2023, 2024, 5, "Passeio");

            /// Act
            var response = await _veiculoService.Alterar(command, ctx);
            var retornoBaseDados = await _veiculoRepository.ObterPorId(IdCenario01, true, ctx);

            /// Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(retornoBaseDados, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(retornoBaseDados.Marca, Is.EqualTo(command.Marca));
                Assert.That(retornoBaseDados.Modelo, Is.EqualTo(command.Modelo));
                Assert.That(retornoBaseDados.AnoFabricacao, Is.EqualTo(command.AnoFabricacao));
                Assert.That(retornoBaseDados.AnoModelo, Is.EqualTo(command.AnoModelo));
                Assert.That(retornoBaseDados.QuantidadeLugares, Is.EqualTo(command.QuantidadeLugares));
                Assert.That(retornoBaseDados.Categoria, Is.EqualTo(command.Categoria));
                Assert.That(retornoBaseDados.Ativo, Is.True);
                Assert.That(retornoBaseDados.DataAlteracao, Is.Not.EqualTo(retornoBaseDados.DataCriacao));
            });
        }

        [Test]
        public async Task AlterarVeiculo_ComVeiculoSemCadastro_DeveRetornarVeiculoNaoCadastrado()
        {
            /// Arrange
            var command = new AlterarVeiculoCommand(Guid.NewGuid(), "VW", "Gol", 2010, 2011, 5, "Passeio");

            /// Act
            var response = await _veiculoService.Alterar(command, ctx);

            /// Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.UnprocessableEntity));

        }
    }
}
