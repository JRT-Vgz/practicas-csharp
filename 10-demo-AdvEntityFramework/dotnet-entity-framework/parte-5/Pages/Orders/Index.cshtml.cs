using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Orders;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

    [BindProperty(SupportsGet = true)] public int? RangeStart { get; set; }

    [BindProperty(SupportsGet = true)] public int? RangeEnd { get; set; }

    public IList<Order> Order { get; set; } = default!;

    public async Task OnGetAsync()
    {
        var query = _context.Orders.AsQueryable();

        if (RangeStart.HasValue) query = query.Where(o => o.Quantity >= RangeStart.Value);

        if (RangeEnd.HasValue) query = query.Where(x => x.Quantity <= RangeEnd.Value);

        Order = await query
            .Include(o => o.CatalogItem)
            .Include(o => o.Customer)
            .ToListAsync();
    }
}