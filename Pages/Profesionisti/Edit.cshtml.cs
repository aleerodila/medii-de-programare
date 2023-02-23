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

namespace Salon.Pages.Profesionisti
{
    public class EditModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public EditModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesionist Profesionist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Profesionist == null)
            {
                return NotFound();
            }

            var profesionist =  await _context.Profesionist.FirstOrDefaultAsync(m => m.ID == id);
            if (profesionist == null)
            {
                return NotFound();
            }
            Profesionist = profesionist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Profesionist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionistExists(Profesionist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProfesionistExists(int id)
        {
          return _context.Profesionist.Any(e => e.ID == id);
        }
    }
}
