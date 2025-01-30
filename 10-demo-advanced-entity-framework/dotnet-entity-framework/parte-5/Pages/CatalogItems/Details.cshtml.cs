using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.CatalogItems;

public class DetailsModel : PageModel
{
    private readonly DatabaseContext _context;

    public DetailsModel(DatabaseContext context)
    {
        _context = context;
    }

    public CatalogItem CatalogItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var catalogitem = await _context.CatalogItems.FirstOrDefaultAsync(m => m.Id == id);
        if (catalogitem == null)
            return NotFound();
        CatalogItem = catalogitem;
        return Page();
    }
}