﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using Salon.Models;

namespace Salon.Pages.Orare
{
    public class EditModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public EditModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Orar Orar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orar == null)
            {
                return NotFound();
            }

            var orar =  await _context.Orar.FirstOrDefaultAsync(m => m.ID == id);
            if (orar == null)
            {
                return NotFound();
            }
            Orar = orar;
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

            _context.Attach(Orar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrarExists(Orar.ID))
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

        private bool OrarExists(int id)
        {
          return _context.Orar.Any(e => e.ID == id);
        }
    }
}
