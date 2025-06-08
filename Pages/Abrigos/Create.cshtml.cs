using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Firewatch.Abrigos.Data;
using Firewatch.Abrigos.Models;

namespace Firewatch.Abrigos.Pages.Abrigos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abrigo Abrigo { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("CidadeId recebido: " + Abrigo.CidadeId);

            if (!ModelState.IsValid)
            {
                ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome");
                return Page();
            }

            _context.Abrigos.Add(Abrigo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
