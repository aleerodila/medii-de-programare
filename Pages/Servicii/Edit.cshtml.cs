using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;

namespace Salon.Pages.Servicii
{
    public class EditModel : CategorieServiciuPageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public EditModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            Serviciu = await _context.Serviciu
               .Include(b => b.Orar)
               .Include(b => b.CategoriiServiciu).ThenInclude(b => b.Categorie)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Serviciu);
            Serviciu = serviciu;
            ViewData["OrarID"] = new SelectList(_context.Set<Orar>(), "ID", "Numeorar");
            ViewData["ProfesionistID"] = new SelectList(_context.Set<Profesionist>(), "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviciuToUpdate = await _context.Serviciu
            .Include(i => i.Orar)
            .Include(i => i.CategoriiServiciu)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviciuToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Numeserviciu, i => i.Profesionist, i => i.Pret, i => i.Orar))
            {
                UpdateCategoriiServiciu(_context, selectedCategories, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 
            UpdateCategoriiServiciu(_context, selectedCategories, serviciuToUpdate);
            PopulateAssignedCategoryData(_context, serviciuToUpdate);
            return Page();
        }
        private bool ServiciuExists(int id)
        {
            return _context.Serviciu.Any(e => e.ID == id);
        }

    }
}

