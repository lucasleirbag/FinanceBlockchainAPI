using FinanceBlockchain.Infrastructure.Services;
using FinanceBlockchain.Tests.Utils;
using System.Security.Cryptography;
using Xunit;

public class DigitalSignatureServiceTests
{
    private readonly DigitalSignatureService _digitalSignatureService;
    private readonly RSAParameters _chavePrivada;
    private readonly RSAParameters _chavePublica;

    public DigitalSignatureServiceTests()
    {
        _digitalSignatureService = new DigitalSignatureService();

        using var rsa = new RSACryptoServiceProvider(2048);
        _chavePrivada = rsa.ExportParameters(true);
        _chavePublica = rsa.ExportParameters(false);
    }

    [Fact]
    public void Assinar_DeveRetornarAssinatura()
    {
        var texto = "texto original";

        var assinatura = _digitalSignatureService.Assinar(texto, _chavePrivada);

        Assert.NotNull(assinatura);
    }

    [Fact]
    public void VerificarAssinatura_DeveRetornarVerdadeiroParaAssinaturaValida()
    {
        var texto = "texto original";
        var assinatura = _digitalSignatureService.Assinar(texto, _chavePrivada);

        var resultado = _digitalSignatureService.VerificarAssinatura(texto, assinatura, _chavePublica);

        Assert.True(resultado);
    }

    [Fact]
    public void VerificarAssinatura_DeveRetornarFalsoParaAssinaturaInvalida()
    {
        var texto = "texto original";
        var assinatura = _digitalSignatureService.Assinar(texto, _chavePrivada);
        var textoAlterado = "texto alterado";

        var resultado = _digitalSignatureService.VerificarAssinatura(textoAlterado, assinatura, _chavePublica);

        Assert.False(resultado);
    }
}
