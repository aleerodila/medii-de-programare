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
    public class IndexModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public IndexModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IList<Profesionist> Profesionist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Profesionist != null)
            {
                Profesionist = await _context.Profesionist.ToListAsync();
            }
        }
    }
}
