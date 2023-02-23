namespace Salon.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salon.Data;


public class CategorieServiciuPageModel : PageModel
{
    public List<AssignedCategoryData> AssignedCategoryDataList;
    public void PopulateAssignedCategoryData(SalonContext context,
    Serviciu serviciu)
    {
        var allCategories = context.Categorie;
        var serviciuCategories = new HashSet<int>(serviciu.CategoriiServiciu.Select(c => c.CategorieID)); //
        AssignedCategoryDataList = new List<AssignedCategoryData>();
        foreach (var cat in allCategories)
        {
            AssignedCategoryDataList.Add(new AssignedCategoryData
            {
                CategorieID = cat.ID,
                Nume = cat.Numecategorie,
                Assigned = serviciuCategories.Contains(cat.ID)
            });
        }
    }
    public void UpdateCategoriiServiciu(SalonContext context,
    string[] selectedCategories, Serviciu serviciuToUpdate)
    {
        if (selectedCategories == null)
        {
            serviciuToUpdate.CategoriiServiciu = new List<CategorieServiciu>();
            return;
        }
        var selectedCategoriesHS = new HashSet<string>(selectedCategories);
        var serviciuCategories = new HashSet<int>
        (serviciuToUpdate.CategoriiServiciu.Select(c => c.Categorie.ID));
        foreach (var cat in context.Categorie)
        {
            if (selectedCategoriesHS.Contains(cat.ID.ToString()))
            {
                if (!serviciuCategories.Contains(cat.ID))
                {
                    serviciuToUpdate.CategoriiServiciu.Add(
                    new CategorieServiciu
                    {
                        ServiciuID = serviciuToUpdate.ID,
                        CategorieID = cat.ID
                    });
                }
            }
            else
            {
                if (serviciuCategories.Contains(cat.ID))
                {
                    CategorieServiciu courseToRemove = serviciuToUpdate.CategoriiServiciu.SingleOrDefault(i => i.CategorieID == cat.ID);
                    context.Remove(courseToRemove);
                }
            }
        }
    }
}


