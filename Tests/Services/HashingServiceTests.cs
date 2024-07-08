using FinanceBlockchain.Infrastructure.Services;
using Xunit;

public class HashingServiceTests
{
    private readonly HashingService _hashingService;

    public HashingServiceTests()
    {
        _hashingService = new HashingService();
    }

    [Fact]
    public void GerarHash_DeveRetornarHash()
    {
        var texto = "texto original";

        var resultado = _hashingService.GerarHash(texto);

        Assert.NotNull(resultado);
        Assert.NotEqual(texto, resultado);
    }
}
