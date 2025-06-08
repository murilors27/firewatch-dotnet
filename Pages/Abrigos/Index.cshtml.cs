using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Firewatch.Abrigos.Data;
using Firewatch.Abrigos.Models;

namespace Firewatch.Abrigos.Pages.Abrigos
{
    public class IndexModel : PageModel
    {
        private readonly Firewatch.Abrigos.Data.AppDbContext _context;

        public IndexModel(Firewatch.Abrigos.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Abrigo> Abrigo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Abrigo = await _context.Abrigos
                .Include(a => a.Cidade).ToListAsync();
        }
    }
}
