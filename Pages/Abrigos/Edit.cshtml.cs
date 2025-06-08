using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firewatch.Abrigos.Data;
using Firewatch.Abrigos.Models;

namespace Firewatch.Abrigos.Pages.Abrigos
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abrigo Abrigo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Abrigo = await _context.Abrigos
                                   .Include(a => a.Cidade)
                                   .FirstOrDefaultAsync(m => m.Id == id);

            if (Abrigo == null)
                return NotFound();

            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome", Abrigo.CidadeId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome", Abrigo.CidadeId);
                return Page();
            }

            _context.Attach(Abrigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Abrigos.Any(e => e.Id == Abrigo.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
