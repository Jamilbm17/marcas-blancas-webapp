using MarcasBlancas.Core.Models;

namespace MarcasBlancas.Core.Services;

public class CatalogoService
{
    public IReadOnlyList<Producto> ObtenerProductos() => new List<Producto>
    {
        new() { Id = 1, Nombre = "Leche entera 1L",      Categoria = "Lacteos", Tipo = TipoMarcaBlanca.Tradicional,      PrecioMarcaTradicional = 1.20m, PrecioMarcaBlanca = 0.66m },
        new() { Id = 2, Nombre = "Refresco de cola 2L",  Categoria = "Bebidas", Tipo = TipoMarcaBlanca.SegundaGeneracion, PrecioMarcaTradicional = 1.80m, PrecioMarcaBlanca = 0.99m },
        new() { Id = 3, Nombre = "Flan de vainilla x4",  Categoria = "Postres", Tipo = TipoMarcaBlanca.Tradicional,      PrecioMarcaTradicional = 2.00m, PrecioMarcaBlanca = 1.00m },
        new() { Id = 4, Nombre = "Yogur natural x8",     Categoria = "Lacteos", Tipo = TipoMarcaBlanca.SegundaGeneracion, PrecioMarcaTradicional = 2.50m, PrecioMarcaBlanca = 1.45m },
        new() { Id = 5, Nombre = "Auriculares First Line", Categoria = "Electronica", Tipo = TipoMarcaBlanca.MarcaPrivada, PrecioMarcaTradicional = 25.00m, PrecioMarcaBlanca = 15.00m },
    };
}
