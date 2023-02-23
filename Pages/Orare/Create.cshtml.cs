﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Salon.Data;
using Salon.Models;

namespace Salon.Pages.Orare
{
    public class CreateModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public CreateModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Orar Orar { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orar.Add(Orar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
