using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSD603_MovieDB.Data;
using MovieDB.Models;

namespace DSD603_MovieDB.Pages.Casts
{
    public class DetailsModel : PageModel
    {
        private readonly DSD603_MovieDB.Data.ApplicationDbContext _context;

        public DetailsModel(DSD603_MovieDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cast Cast { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast.FirstOrDefaultAsync(m => m.Id == id);

            if (cast is not null)
            {
                Cast = cast;

                return Page();
            }

            return NotFound();
        }
    }
}
