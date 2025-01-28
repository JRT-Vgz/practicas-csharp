using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Customers;

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }

    public IList<Customer> Customer { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Customer = await _context.Customers.ToListAsync();
    }
}