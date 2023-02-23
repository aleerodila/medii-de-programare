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
    public class DetailsModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public DetailsModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

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
    }
}
