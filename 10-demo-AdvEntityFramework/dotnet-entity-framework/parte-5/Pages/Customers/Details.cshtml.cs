using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Customers;

public class DetailsModel : PageModel
{
    private readonly DatabaseContext _context;

    public DetailsModel(DatabaseContext context)
    {
        _context = context;
    }

    public Customer Customer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
        if (customer == null)
            return NotFound();
        Customer = customer;
        return Page();
    }
}