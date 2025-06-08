using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Firewatch.Abrigos.Data;
using Firewatch.Abrigos.Models;

namespace Firewatch.Abrigos.Pages.Abrigos
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abrigo Abrigo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Abrigo = await _context.Abrigos
                .Include(a => a.Cidade)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Abrigo == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var abrigo = await _context.Abrigos.FindAsync(id);

            if (abrigo != null)
            {
                _context.Abrigos.Remove(abrigo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
