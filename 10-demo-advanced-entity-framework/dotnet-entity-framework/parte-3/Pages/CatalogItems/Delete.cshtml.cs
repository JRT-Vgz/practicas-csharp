using Cf.Dotnet.EntityFramework.Parte3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.CatalogItems;

public class DeleteModel : PageModel
{
    private readonly DatabaseContext _context;

    public DeleteModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty] public CatalogItem CatalogItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var catalogitem = await _context.CatalogItems.FirstOrDefaultAsync(m => m.Id == id);

        if (catalogitem == null)
            return NotFound();
        CatalogItem = catalogitem;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var catalogitem = await _context.CatalogItems.FindAsync(id);
        if (catalogitem != null)
        {
            CatalogItem = catalogitem;
            _context.CatalogItems.Remove(CatalogItem);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}