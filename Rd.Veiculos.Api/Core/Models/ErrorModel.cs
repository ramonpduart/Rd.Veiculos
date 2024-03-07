namespace Rd.Veiculos.Api.Core.Models;

/// <summary>
/// Erro Model
/// </summary>
/// <remarks>https://tools.ietf.org/html/rfc7231</remarks>
[Serializable]
public class ErrorModel
{
    /// <inheritdoc />
    public ErrorModel(int status, string mensagemErro) : this(status, string.Empty,
        new Dictionary<string, string[]>
        {
            [string.Empty] = new[] { mensagemErro }
        })
    { }

    /// <inheritdoc />
    public ErrorModel(int status, string type, string mensagemErro) : this(status, type,
        new Dictionary<string, string[]>
        {
            [type ?? string.Empty] = new[] { mensagemErro }
        })
    { }

    /// <inheritdoc />
    public ErrorModel(int status, string type, Dictionary<string, string[]> mensagens)
    {
        Status = status;
        Type = type;
        Messages = mensagens;
    }

    /// <summary>
    /// Status
    /// </summary>
    public int Status { get; init; }

    /// <summary>
    /// Tipo
    /// </summary>
    public string Type { get; init; }

    /// <summary>
    /// Mensagens de erro
    /// </summary>
    public Dictionary<string, string[]> Messages { get; init; }
}