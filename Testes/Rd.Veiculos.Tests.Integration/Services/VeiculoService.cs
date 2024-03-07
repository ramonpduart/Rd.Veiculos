using Rd.Veiculos.Tests.Integration.Requests.Veiculo;
using System.Text;
using System.Text.Json;

namespace Rd.Veiculos.Tests.Integration.Services
{
    internal class VeiculoService
    {
        private readonly HttpClient _httpClient;

        public VeiculoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("API_BASE_URL") ?? "");
        }

        public async Task<HttpResponseMessage> Adicionar(AdicionarVeiculoCommand command, CancellationToken ctx)
        {
            string jsonObject = JsonSerializer.Serialize(command);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var uri = GetUri();
            var response = await _httpClient.PostAsync(uri, content, ctx);

            return response;

            Uri GetUri()
                => new(_httpClient.BaseAddress ?? throw new NotSupportedException(), "v1/veiculo");
        }

        public async Task<HttpResponseMessage> Alterar(AlterarVeiculoCommand command, CancellationToken ctx)
        {
            string jsonObject = JsonSerializer.Serialize(command);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var uri = GetUri(command.Id);
            var response = await _httpClient.PutAsync(uri, content, ctx);

            return response;

            Uri GetUri(Guid id)
                => new(_httpClient.BaseAddress ?? throw new NotSupportedException(), $"v1/veiculo/{id}");
        }

        public async Task<HttpResponseMessage> Excluir(ExcluirVeiculoCommand command, CancellationToken ctx)
        {
            string jsonObject = JsonSerializer.Serialize(command);
            var uri = GetUri(command.Id);
            var response = await _httpClient.DeleteAsync(uri, ctx);

            return response;

            Uri GetUri(Guid id)
                => new(_httpClient.BaseAddress ?? throw new NotSupportedException(), $"v1/veiculo/{id}");
        }
    }
}
