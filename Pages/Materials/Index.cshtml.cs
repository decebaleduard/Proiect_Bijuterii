using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Bijuterii.Data;
using Proiect_Bijuterii.Models;

namespace Proiect_Bijuterii.Pages.Materials
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Bijuterii.Data.Proiect_BijuteriiContext _context;

        public IndexModel(Proiect_Bijuterii.Data.Proiect_BijuteriiContext context)
        {
            _context = context;
        }

        public IList<Material> Material { get;set; }

        public async Task OnGetAsync()
        {
            Material = await _context.Material.ToListAsync();
        }
    }
}
