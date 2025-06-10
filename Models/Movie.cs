using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public string? Overview { get; set; }
        public string? Genre { get; set; }
        public decimal? Price { get; set; }

    }
}