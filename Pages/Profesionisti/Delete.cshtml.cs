using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;

namespace Salon.Pages.Profesionisti
{
    public class DeleteModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public DeleteModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Profesionist Profesionist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Profesionist == null)
            {
                return NotFound();
            }

            var profesionist = await _context.Profesionist.FirstOrDefaultAsync(m => m.ID == id);

            if (profesionist == null)
            {
                return NotFound();
            }
            else 
            {
                Profesionist = profesionist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Profesionist == null)
            {
                return NotFound();
            }
            var profesionist = await _context.Profesionist.FindAsync(id);

            if (profesionist != null)
            {
                Profesionist = profesionist;
                _context.Profesionist.Remove(Profesionist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
