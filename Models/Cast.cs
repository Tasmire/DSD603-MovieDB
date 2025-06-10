using System.ComponentModel.DataAnnotations;
namespace MovieDB.Models
{
    public class Cast
    {
        public Guid Id { get; set; }

        [Display (Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Screen Name")]
        public string? ScreenName { get; set; }

        [Display(Name = "Movie ID")]
        public Guid? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}