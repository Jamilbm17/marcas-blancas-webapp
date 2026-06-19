using MarcasBlancas.Core.Models;

namespace MarcasBlancas.Core.Services;

public class CalculadoraAhorro
{
    public decimal CalcularAhorroAbsoluto(Producto producto)
    {
        ArgumentNullException.ThrowIfNull(producto);
        return producto.PrecioMarcaTradicional - producto.PrecioMarcaBlanca;
    }

    public decimal CalcularPorcentajeAhorro(Producto producto)
    {
        ArgumentNullException.ThrowIfNull(producto);

        if (producto.PrecioMarcaTradicional <= 0)
            throw new ArgumentException(
                "El precio de la marca tradicional debe ser mayor que cero.",
                nameof(producto));

        var ahorro = CalcularAhorroAbsoluto(producto);
        var porcentaje = ahorro / producto.PrecioMarcaTradicional * 100m;
        return Math.Round(porcentaje, 2);
    }

    public bool EsGanga(Producto producto, decimal umbralPorcentaje = 45m)
        => CalcularPorcentajeAhorro(producto) >= umbralPorcentaje;
}
