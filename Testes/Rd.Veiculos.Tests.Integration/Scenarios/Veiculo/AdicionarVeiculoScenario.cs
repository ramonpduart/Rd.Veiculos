using Rd.Veiculos.Tests.Integration.Requests.Veiculo;
using Rd.Veiculos.Tests.Integration.Response;
using System.Net;
using System.Net.Http.Json;

namespace Rd.Veiculos.Tests.Integration.Scenarios.Veiculo
{
    [TestFixture]
    public class AdicionarVeiculoScenario : BaseScenario
    {
        [Test]
        public async Task AdicionarVeiculo_ComDadosValidos_DeveSalvarNaBaseDeDados()
        {
            /// Arrange
            var command = new AdicionarVeiculoCommand("VW", "Gol", 2015, 2016, 5, "Passeio");

            /// Act
            var response = await _veiculoService.Adicionar(command, ctx);
            var retornoApi = await response.Content.ReadFromJsonAsync<AdicionarVeiculoResponse>(cancellationToken: ctx);
            var retornoBaseDados = await _veiculoRepository.ObterPorId(retornoApi.Id, true, ctx);

            /// Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.Multiple(() =>
            {
                Assert.That(retornoApi, Is.Not.Null);
                Assert.That(retornoBaseDados, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(retornoBaseDados.Marca, Is.EqualTo(command.Marca));
                Assert.That(retornoBaseDados.Modelo, Is.EqualTo(command.Modelo));
                Assert.That(retornoBaseDados.AnoFabricacao, Is.EqualTo(command.AnoFabricacao));
                Assert.That(retornoBaseDados.AnoModelo, Is.EqualTo(command.AnoModelo));
                Assert.That(retornoBaseDados.QuantidadeLugares, Is.EqualTo(command.QuantidadeLugares));
                Assert.That(retornoBaseDados.Categoria, Is.EqualTo(command.Categoria));
                Assert.That(retornoBaseDados.Ativo, Is.True);
            });
        }

        [Test]
        public async Task AdicionarVeiculo_ComDadosInvalidos_DeveRetornarErro()
        {
            /// Arrange
            var command = new AdicionarVeiculoCommand("VW", "Gol", 22015, 12016, -1, "Passeio");

            /// Act
            var response = await _veiculoService.Adicionar(command, ctx);

            /// Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        }
    }
}
