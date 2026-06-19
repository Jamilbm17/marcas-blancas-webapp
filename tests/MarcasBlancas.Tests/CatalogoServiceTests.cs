using MarcasBlancas.Core.Services;
using Xunit;

namespace MarcasBlancas.Tests;

public class CatalogoServiceTests
{
    private readonly CatalogoService _catalogo = new();

    [Fact]
    public void ObtenerProductos_DevuelveCatalogoNoVacio()
    {
        var productos = _catalogo.ObtenerProductos();

        Assert.NotEmpty(productos);
    }

    [Fact]
    public void ObtenerProductos_TodosTienenNombreYCategoria()
    {
        var productos = _catalogo.ObtenerProductos();

        Assert.All(productos, p =>
        {
            Assert.False(string.IsNullOrWhiteSpace(p.Nombre));
            Assert.False(string.IsNullOrWhiteSpace(p.Categoria));
        });
    }

    [Fact]
    public void ObtenerProductos_PrecioBlancaSiempreMenorQueTradicional()
    {
        var productos = _catalogo.ObtenerProductos();

        Assert.All(productos, p =>
            Assert.True(p.PrecioMarcaBlanca < p.PrecioMarcaTradicional));
    }
}
