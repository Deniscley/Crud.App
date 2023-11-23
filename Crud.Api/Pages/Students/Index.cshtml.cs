using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crud.Api.Data;
using Crud.Api.Models;

namespace Crud.Api.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly Crud.Api.Data.ApplicationDbContext _context;

        public IndexModel(Crud.Api.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
