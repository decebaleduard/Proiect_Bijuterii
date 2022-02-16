using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Bijuterii.Data;


namespace Proiect_Bijuterii.Models
{
    public class BijuterieCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_BijuteriiContext context,
        Bijuterie bijuterie)
        {
            var allCategories = context.Category;
            var BijuterieCategories = new HashSet<int>(
            bijuterie.BijuterieCategories.Select(c => c.BijuterieID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned =BijuterieCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBijuterieCategories(Proiect_BijuteriiContext context,
        string[] selectedCategories, Bijuterie bijuterieToUpdate)
        {
            if (selectedCategories == null)
            {
                bijuterieToUpdate.BijuterieCategories = new List<BijuterieCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var BijuterieCategories = new HashSet<int>
            (bijuterieToUpdate.BijuterieCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!BijuterieCategories.Contains(cat.ID))
                    {
                        bijuterieToUpdate.BijuterieCategories.Add(
                        new BijuterieCategory
                        {
                            BijuterieID = bijuterieToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (BijuterieCategories.Contains(cat.ID))
                    {
                        BijuterieCategory courseToRemove
                        = bijuterieToUpdate
                        .BijuterieCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
