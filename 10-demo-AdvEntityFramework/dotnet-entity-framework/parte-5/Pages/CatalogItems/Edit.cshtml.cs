using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.CatalogItems;

public class EditModel : PageModel
{
    private readonly DatabaseContext _context;

    public EditModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty] public CatalogItem CatalogItem { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var catalogitem = await _context.CatalogItems.FirstOrDefaultAsync(m => m.Id == id);
        if (catalogitem == null) return NotFound();
        CatalogItem = catalogitem;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(CatalogItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CatalogItemExists(CatalogItem.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool CatalogItemExists(int id)
    {
        return _context.CatalogItems.Any(e => e.Id == id);
    }
}