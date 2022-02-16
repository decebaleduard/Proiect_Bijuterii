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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Bijuterii.Data.Proiect_BijuteriiContext _context;

        public DetailsModel(Proiect_Bijuterii.Data.Proiect_BijuteriiContext context)
        {
            _context = context;
        }

        public Bijuterie Bijuterie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bijuterie = await _context.Bijuterie.FirstOrDefaultAsync(m => m.ID == id);

            if (Bijuterie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
