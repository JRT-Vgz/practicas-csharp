using Cf.Dotnet.EntityFramework.Parte3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.CatalogItems;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }

    public IList<CatalogItem> CatalogItem { get; set; } = default!;

    public async Task OnGetAsync()
    {
        CatalogItem = await _context.CatalogItems.ToListAsync();
    }
}