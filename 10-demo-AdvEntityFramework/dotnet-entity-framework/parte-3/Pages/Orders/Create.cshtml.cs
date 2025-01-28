using Cf.Dotnet.EntityFramework.Parte3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cf.Dotnet.EntityFramework.Parte3.Pages.Orders;

public class CreateModel : PageModel
{
    private readonly DatabaseContext _context;

    public CreateModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty] public Order Order { get; set; } = default!;

    public IActionResult OnGet()
    {
        ViewData["CatalogItemId"] = new SelectList(_context.CatalogItems, "Id", "Id");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        _context.Orders.Add(Order);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}