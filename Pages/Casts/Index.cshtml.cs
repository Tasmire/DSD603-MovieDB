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
    public class IndexModel : PageModel
    {
        private readonly DSD603_MovieDB.Data.ApplicationDbContext _context;

        public IndexModel(DSD603_MovieDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cast> Cast { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cast = await _context.Cast
                .Include(c => c.Movie).ToListAsync();
        }
    }
}
