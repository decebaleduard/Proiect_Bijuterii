using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Bijuterii.Data;
using Proiect_Bijuterii.Models;

namespace Proiect_Bijuterii.Pages.Bijuterii
{
    public class CreateModel : BijuterieCategoriesPageModel
    {
        private readonly Proiect_Bijuterii.Data.Proiect_BijuteriiContext _context;

        public CreateModel(Proiect_Bijuterii.Data.Proiect_BijuteriiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "DenumireMaterial");
            var bijuterie = new Bijuterie();
            bijuterie.BijuterieCategories = new List<BijuterieCategory>();
            PopulateAssignedCategoryData(_context, bijuterie);
            return Page();
        }

        [BindProperty]
        public Bijuterie Bijuterie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBijuterie = new Bijuterie();
            if (selectedCategories != null)
            {
                newBijuterie.BijuterieCategories = new List<BijuterieCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BijuterieCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBijuterie.BijuterieCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Bijuterie>(
            newBijuterie,
            "Bijuterie",
            i => i.Tip,i => i.Marca,
            i => i.Pret,i => i.MaterialID))
            {
                _context.Bijuterie.Add(newBijuterie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newBijuterie);
            return Page();
        }
    }
}
