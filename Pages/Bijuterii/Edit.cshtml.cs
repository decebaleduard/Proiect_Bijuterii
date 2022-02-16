using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Bijuterii.Data;
using Proiect_Bijuterii.Models;

namespace Proiect_Bijuterii.Pages.Bijuterii
{
    public class EditModel : BijuterieCategoriesPageModel
    {
        private readonly Proiect_Bijuterii.Data.Proiect_BijuteriiContext _context;

        public EditModel(Proiect_Bijuterii.Data.Proiect_BijuteriiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bijuterie Bijuterie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bijuterie = await _context.Bijuterie
                .Include(b => b.BijuterieCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Bijuterie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Bijuterie);

           ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "DenumireMaterial");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bijuterieToUpdate = await _context.Bijuterie
            .Include(i => i.BijuterieCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bijuterieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Bijuterie>(
            bijuterieToUpdate,
            "Bijuterie",
            i => i.Tip, i => i.Marca,
            i => i.Pret,i => i.Material))
            {
                UpdateBijuterieCategories(_context, selectedCategories, bijuterieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateBijuterieCategories(_context, selectedCategories, bijuterieToUpdate);
            PopulateAssignedCategoryData(_context, bijuterieToUpdate);
            return Page();
        }
    }
}
