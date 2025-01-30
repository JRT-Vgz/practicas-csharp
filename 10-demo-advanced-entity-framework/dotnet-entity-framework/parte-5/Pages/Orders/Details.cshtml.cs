using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Orders;

public class DetailsModel : PageModel
{
    private readonly DatabaseContext _context;

    public DetailsModel(DatabaseContext context)
    {
        _context = context;
    }

    public Order Order { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
        if (order == null)
            return NotFound();
        Order = order;
        return Page();
    }
}