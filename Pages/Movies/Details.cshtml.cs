using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DSD603_MovieDB.Data;
using MovieDB.Models;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi;

namespace DSD603_MovieDB.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly DSD603_MovieDB.Data.ApplicationDbContext _context;

        public DetailsModel(DSD603_MovieDB.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MovieDB.Models.Movie Movie { get; set; } = default!;
        public List<Cast> CastList { get; set; }
        public string? PosterPath { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is not null)
            {
                Movie = movie;
                CastList = await _context.Cast
                    .Where(c => c.MovieId == movie.Id)
                    .ToListAsync();

                var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
                var searchResponse = await movieApi.SearchByTitleAsync(movie.Title);
                var movieResult = searchResponse.Results.FirstOrDefault();

                if (movieResult != null)
                {
                    int tmdbId = movieResult.Id;
                    var movieDetails = await movieApi.FindByIdAsync(tmdbId);
                    string posterPath = movieDetails.Item.PosterPath;
                    PosterPath = "https://image.tmdb.org/t/p/w200" + posterPath;
                }
                else
                {
                    PosterPath = null;
                }

                return Page();
            }

            return NotFound();
        }
    }
}
