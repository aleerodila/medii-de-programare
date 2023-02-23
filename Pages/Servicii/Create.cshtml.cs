using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon.Models;

namespace Salon.Pages.Servicii
{
    public class CreateModel : CategorieServiciuPageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public CreateModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var profesionistList = _context.Profesionist.Select(x => new
            {
                x.ID,
                FullName1 = x.Nume + " " + x.Prenume
            });

            ViewData["ProfesionistID"] = new SelectList(profesionistList, "ID", "FullName1");
            ViewData["OrarID"] = new SelectList(_context.Set<Orar>(), "ID", "Numeorar");
            var serviciu = new Serviciu();
            serviciu.CategoriiServiciu = new List<CategorieServiciu>();
            PopulateAssignedCategoryData(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var serviciuNou = Serviciu;
            if (selectedCategories != null)
            {
                serviciuNou.CategoriiServiciu = new List<CategorieServiciu>();
                foreach (var sp in selectedCategories)
                {
                    var spToAdd = new CategorieServiciu
                    {
                        CategorieID = int.Parse(sp)
                    };
                    serviciuNou.CategoriiServiciu.Add(spToAdd);
                }
            }

            _context.Serviciu.Add(serviciuNou);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, serviciuNou);
            return Page();
        }
    }
}
