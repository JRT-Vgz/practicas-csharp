using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages;

/// <summary>
///     Modelo de página Razor para la visualización y generación de informes.
/// </summary>
public class ReportModel : PageModel
{
    private readonly DatabaseContext _context;

    /// <summary>
    ///     Constructor que inyecta el contexto de la base de datos en el modelo de página.
    /// </summary>
    /// <param name="context">Contexto de la base de datos de Entity Framework.</param>
    public ReportModel(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Lista para almacenar y mostrar los elementos de informe en la página.
    /// </summary>
    public IList<ReportItem> ReportItem { get; set; }

    /// <summary>
    ///     Método GET asincrónico que se llama al cargar la página.
    ///     Recupera los elementos de informe de la base de datos.
    /// </summary>
    public async Task OnGetAsync()
    {
        // Consulta SQL directa para obtener los datos de la tabla OrderReports.
        ReportItem = await _context.Database
            .SqlQuery<ReportItem>($"select * from OrderReports")
            .ToListAsync();
    }

    /// <summary>
    ///     Método POST asincrónico que se llama cuando se envía un formulario en la página.
    ///     Ejecuta un procedimiento almacenado para generar informes.
    /// </summary>
    /// <returns>Redirecciona a la misma página para actualizar la vista con los nuevos datos.</returns>
    public async Task<IActionResult> OnPostRunSPAsync()
    {
        // Ejecuta el procedimiento almacenado GenerateOrderReports en la base de datos.
        await _context.Database.ExecuteSqlAsync($"EXEC GenerateOrderReports");
        // Redirecciona a la misma página para ver los datos actualizados.
        return RedirectToPage();
    }
}