using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;
using Salon.Models.ViewModels;

namespace Salon.Pages.Orare
{
    public class IndexModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public IndexModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IList<Orar> Orar { get; set; } = default!;
        public OrarIndexData OrarData { get; set; }
        public int OrarID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            OrarData = new OrarIndexData();
            OrarData.Orare = await _context.Orar
            .Include(i => i.Servicii)
            .ThenInclude(c => c.Profesionist)
            .OrderBy(i => i.Numeorar)
            .ToListAsync();
            if (id != null)
            {
                OrarID = id.Value;
                Orar orar = OrarData.Orare
                .Where(i => i.ID == id.Value).Single();
                OrarData.Servicii = orar.Servicii;
            }
        }
    }
}
