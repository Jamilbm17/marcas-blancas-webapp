namespace MarcasBlancas.Core.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public TipoMarcaBlanca Tipo { get; set; }
    public decimal PrecioMarcaTradicional { get; set; }
    public decimal PrecioMarcaBlanca { get; set; }
}
