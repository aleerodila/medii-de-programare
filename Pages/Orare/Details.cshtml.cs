using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;

namespace Salon.Pages.Orare
{
    public class DetailsModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public DetailsModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

      public Orar Orar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orar == null)
            {
                return NotFound();
            }

            var orar = await _context.Orar.FirstOrDefaultAsync(m => m.ID == id);
            if (orar == null)
            {
                return NotFound();
            }
            else 
            {
                Orar = orar;
            }
            return Page();
        }
    }
}
