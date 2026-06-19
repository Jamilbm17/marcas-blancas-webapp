using MarcasBlancas.Core.Models;
using MarcasBlancas.Core.Services;
using Xunit;

namespace MarcasBlancas.Tests;

public class CalculadoraAhorroTests
{
    private readonly CalculadoraAhorro _calculadora = new();

    [Fact]
    public void CalcularAhorroAbsoluto_DevuelveDiferenciaDePrecios()
    {
        var producto = new Producto { PrecioMarcaTradicional = 1.20m, PrecioMarcaBlanca = 0.66m };

        var ahorro = _calculadora.CalcularAhorroAbsoluto(producto);

        Assert.Equal(0.54m, ahorro);
    }

    [Theory]
    [InlineData(1.20, 0.66, 45)]
    [InlineData(2.00, 1.00, 50)]
    [InlineData(25.00, 15.00, 40)]
    public void CalcularPorcentajeAhorro_DevuelvePorcentajeEsperado(
        double tradicional, double blanca, double esperado)
    {
        var producto = new Producto
        {
            PrecioMarcaTradicional = (decimal)tradicional,
            PrecioMarcaBlanca = (decimal)blanca
        };

        var porcentaje = _calculadora.CalcularPorcentajeAhorro(producto);

        Assert.Equal((decimal)esperado, porcentaje);
    }

    [Fact]
    public void CalcularPorcentajeAhorro_PrecioTradicionalCero_LanzaExcepcion()
    {
        var producto = new Producto { PrecioMarcaTradicional = 0m, PrecioMarcaBlanca = 0m };

        Assert.Throws<ArgumentException>(() => _calculadora.CalcularPorcentajeAhorro(producto));
    }

    [Fact]
    public void EsGanga_AhorroSuperiorAlUmbral_DevuelveTrue()
    {
        var producto = new Producto { PrecioMarcaTradicional = 2.00m, PrecioMarcaBlanca = 1.00m };

        Assert.True(_calculadora.EsGanga(producto));
    }

    [Fact]
    public void EsGanga_AhorroInferiorAlUmbral_DevuelveFalse()
    {
        var producto = new Producto { PrecioMarcaTradicional = 25.00m, PrecioMarcaBlanca = 15.00m };

        Assert.False(_calculadora.EsGanga(producto));
    }
}
