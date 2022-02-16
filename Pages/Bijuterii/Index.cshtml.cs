using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Bijuterii.Data;
using Proiect_Bijuterii.Models;

namespace Proiect_Bijuterii.Pages.Bijuterii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Bijuterii.Data.Proiect_BijuteriiContext _context;

        public IndexModel(Proiect_Bijuterii.Data.Proiect_BijuteriiContext context)
        {
            _context = context;
        }

        public IList<Bijuterie> Bijuterie { get;set; }

        public async Task OnGetAsync()
        {
            Bijuterie = await _context.Bijuterie
                .Include(b=>b.Material)
                .ToListAsync();
        }
    }
}
