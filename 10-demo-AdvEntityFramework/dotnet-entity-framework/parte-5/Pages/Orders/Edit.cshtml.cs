using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Orders;

public class EditModel : PageModel
{
    private readonly DatabaseContext _context;

    public EditModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty] public Order Order { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
        if (order == null) return NotFound();
        Order = order;
        ViewData["CatalogItemId"] = new SelectList(_context.CatalogItems, "Id", "Id");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(Order.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }
}