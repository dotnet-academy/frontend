using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesHub.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActor = new HashSet<MovieActor>();
            Review = new HashSet<Review>();
        }

        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }
        public decimal? Revenue { get; set; }
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoPosterUrl { get; set; }
        public string Summary { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public byte ContentRatingId { get; set; }

        public ContentRating ContentRating { get; set; }
        public ICollection<MovieActor> MovieActor { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
