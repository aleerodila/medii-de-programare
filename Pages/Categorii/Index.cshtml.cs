using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;
using Salon.Models.ViewModels;

namespace Salon.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public IndexModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
            .Include(i => i.CategoriiServiciu)
            .ThenInclude(i => i.Serviciu)
            .ThenInclude(i => i.Profesionist)
            .OrderBy(i => i.Numecategorie)
            .ToListAsync();
            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie= CategorieData.Categorii
                .Where(i => i.ID == id.Value).Single();
                CategorieData.CategoriiServiciu = categorie.CategoriiServiciu;
            }
        }
    }
}
