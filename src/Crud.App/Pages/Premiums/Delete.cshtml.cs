using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crud.App.Data;
using Crud.App.Models;

namespace Crud.App.Pages_Premiums
{
    public class DeleteModel : PageModel
    {
        private readonly Crud.App.Data.ApplicationDbContext _context;

        public DeleteModel(Crud.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premium = await _context.Premiums.FirstOrDefaultAsync(m => m.Id == id);

            if (premium == null)
            {
                return NotFound();
            }
            else
            {
                Premium = premium;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premium = await _context.Premiums.FindAsync(id);
            if (premium != null)
            {
                Premium = premium;
                _context.Premiums.Remove(Premium);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
