using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rd.Veiculos.Tests.Integration;

[SetUpFixture]
public class ConfigTests
{
    /// <summary>
    /// Método que é acionado antes dos testes serem inicializados, utilizado para adicionar variaveis de ambiente
    /// Também poderia ser utilizado para criar a base de dados, tabelas, preencher parametros e outros
    /// </summary>
    [OneTimeSetUp]
    public void ApplicationSetUp()
    {
        TestContext.Progress.WriteLine("Adicionando variaveis de ambiente!");
        SetEnvironmentVariables();
        TestContext.Progress.WriteLine("Variaveis de ambiente adicionadas!");
    }

    private static void SetEnvironmentVariables()
    {
        using var file = File.OpenText("Config/app_settings.json");
        var reader = new JsonTextReader(file);
        var jObject = JObject.Load(reader);

        var variables = jObject
            .GetValue("AppSettings")!
            .ToList();

        foreach (var variable in variables)
        {
            var item = variable as JProperty;
            Environment.SetEnvironmentVariable(item.Name, item.Value.ToString());
            TestContext.Progress.WriteLine($"Variavel: {item.Name} adicionada!");
        }
    }
}