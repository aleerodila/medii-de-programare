using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;

namespace Salon.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public IndexModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get; set; } = default!;

        public ServiciuData ServiciuD { get; set; }
        public int SeriviciuID { get; set; }
        public int CategorieID { get; set; }
        public string NumeServiciuSort { get; set; }
        public string ProfesionistSort { get; set; }

        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            ServiciuD = new ServiciuData();

            NumeServiciuSort = String.IsNullOrEmpty(sortOrder) ? "numeserv_desc" : "";
            ProfesionistSort = String.IsNullOrEmpty(sortOrder) ? "prof_desc" : "";

            CurrentFilter = searchString;


            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Orar)
            .Include(b => b.Profesionist)
            .Include(b => b.CategoriiServiciu)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Numeserviciu)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Profesionist.Prenume.Contains(searchString) || s.Profesionist.Nume.Contains(searchString) || s.Numeserviciu.Contains(searchString));
            }

                if (id != null)
                {
                    SeriviciuID = id.Value;
                    Serviciu serviciu = ServiciuD.Servicii
                    .Where(i => i.ID == id.Value).Single();
                    ServiciuD.Categorii = serviciu.CategoriiServiciu.Select(s => s.Categorie);
                }

                switch (sortOrder)
                {
                    case "numeserv_desc":
                        ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                       s.Numeserviciu);
                        break;
                    case "prof_desc":
                        ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                       s.Profesionist.FullName);
                        break;

                }

            }

        }
    }

