using MarcasBlancas.Core.Models;
using MarcasBlancas.Core.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarcasBlancas.Web.Pages;

public class IndexModel : PageModel
{
    private readonly CatalogoService _catalogo;

    public IndexModel(CatalogoService catalogo, CalculadoraAhorro calculadora)
    {
        _catalogo = catalogo;
        Calculadora = calculadora;
    }

    public IReadOnlyList<Producto> Productos { get; private set; } = [];
    public CalculadoraAhorro Calculadora { get; }

    public void OnGet()
    {
        Productos = _catalogo.ObtenerProductos();
    }
}
