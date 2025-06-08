using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Firewatch.Abrigos.Data;
using Firewatch.Abrigos.Models;

namespace Firewatch.Abrigos.Pages.Abrigos
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

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
    }
}
