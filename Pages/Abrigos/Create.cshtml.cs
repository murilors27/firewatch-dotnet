using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firewatch.Abrigos.Data;
using Firewatch.Abrigos.Models;

namespace Firewatch.Abrigos.Pages.Abrigos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
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
            try
            {
                _logger.LogInformation("Tentando criar novo abrigo: {@Abrigo}", Abrigo);

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Modelo inválido: {@ModelState}", ModelState);
                    ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome");
                    return Page();
                }

                // Verifica se a cidade existe
                var cidade = await _context.Cidades.FindAsync(Abrigo.CidadeId);
                if (cidade == null)
                {
                    ModelState.AddModelError("Abrigo.CidadeId", "Cidade não encontrada");
                    ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome");
                    return Page();
                }

                _context.Abrigos.Add(Abrigo);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Abrigo criado com sucesso. ID: {Id}", Abrigo.Id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar abrigo");
                ModelState.AddModelError("", "Ocorreu um erro ao salvar o abrigo. Por favor, tente novamente.");
                ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome");
                return Page();
            }
        }
    }
}
