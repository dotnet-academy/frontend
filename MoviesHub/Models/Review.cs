using System;
using System.Collections.Generic;

namespace MoviesHub.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public string Reviewer { get; set; }
        public string Text { get; set; }
        public decimal Score { get; set; }

        public Movie Movie { get; set; }
    }
}
