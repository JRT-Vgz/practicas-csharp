using Cf.Dotnet.EntityFramework.Parte5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cf.Dotnet.EntityFramework.Parte5.Pages.Customers;

public class CreateModel : PageModel
{
    private readonly DatabaseContext _context;

    public CreateModel(DatabaseContext context)
    {
        _context = context;
    }

    [BindProperty] public Customer Customer { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Customers.Add(Customer);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}