using FinanceBlockchain.Infrastructure.Services;
using System.Security.Cryptography;
using Xunit;

public class EncryptionServiceTests
{
    private readonly EncryptionService _encryptionService;

    public EncryptionServiceTests()
    {
        _encryptionService = new EncryptionService();
    }

    [Fact]
    public void Criptografar_DeveRetornarTextoCriptografado()
    {
        var texto = "texto original";
        var senha = "Z2wLKBGwKwODsAo7PwURgHxGfI6kVKzl"; // 32 caracteres (256 bits)

        var resultado = _encryptionService.Criptografar(texto, senha);

        Assert.NotNull(resultado);
        Assert.NotEqual(texto, resultado);
    }

    [Fact]
    public void Descriptografar_DeveRetornarTextoOriginal()
    {
        var texto = "texto original";
        var senha = "Z2wLKBGwKwODsAo7PwURgHxGfI6kVKzl"; // 32 caracteres (256 bits)
        var textoCriptografado = _encryptionService.Criptografar(texto, senha);

        var resultado = _encryptionService.Descriptografar(textoCriptografado, senha);

        Assert.Equal(texto, resultado);
    }

    [Fact]
    public void CriptografarEDescriptografar_EntradasVariadas()
    {
        var senhas = new[]
        {
            "senhaSegura1234567890123456789012",
            "outraSenha4567890123456789012345",
            "maisUmaSenha78901234567890123456"
        };
        var textos = new[]
        {
            "Texto curto",
            "Texto de tamanho médio para testar a criptografia",
            new string('A', 1000) // Texto longo
        };

        foreach (var senha in senhas)
        {
            foreach (var texto in textos)
            {
                var textoCriptografado = _encryptionService.Criptografar(texto, senha);
                var textoDescriptografado = _encryptionService.Descriptografar(textoCriptografado, senha);

                Assert.Equal(texto, textoDescriptografado);
            }
        }
    }

    [Fact]
    public void CriptografarEDescriptografar_ResistenteAForcaBruta()
    {
        var texto = "texto original";
        var senha = "Z2wLKBGwKwODsAo7PwURgHxGfI6kVKzl"; // 32 caracteres (256 bits)
        var textoCriptografado = _encryptionService.Criptografar(texto, senha);

        // Testar com senha incorreta
        var senhaIncorreta = "senhaIncorreta7890123456789012345";

        Assert.Throws<CryptographicException>(() =>
        {
            _encryptionService.Descriptografar(textoCriptografado, senhaIncorreta);
        });
    }

    [Fact]
    public void Salt_DeveSerUnicoParaCadaCriptografia()
    {
        var texto = "texto original";
        var senha = "Z2wLKBGwKwODsAo7PwURgHxGfI6kVKzl"; // 32 caracteres (256 bits)

        var textoCriptografado1 = _encryptionService.Criptografar(texto, senha);
        var textoCriptografado2 = _encryptionService.Criptografar(texto, senha);

        // Verificar se os textos criptografados são diferentes
        Assert.NotEqual(textoCriptografado1, textoCriptografado2);
    }
}
