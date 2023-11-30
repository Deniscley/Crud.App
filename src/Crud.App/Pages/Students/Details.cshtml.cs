using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crud.App.Data;
using Crud.App.Models;

namespace Crud.App.Pages_Students
{
    public class DetailsModel : PageModel
    {
        private readonly Crud.App.Data.ApplicationDbContext _context;

        public DetailsModel(Crud.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
