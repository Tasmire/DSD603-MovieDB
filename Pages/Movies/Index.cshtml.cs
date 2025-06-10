using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSD603_MovieDB.Data;
using MovieDB.Models;

namespace DSD603_MovieDB.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly DSD603_MovieDB.Data.ApplicationDbContext _context;

        public IndexModel(DSD603_MovieDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
