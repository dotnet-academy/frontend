using System;
using System.Collections.Generic;

namespace MoviesHub.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActor = new HashSet<MovieActor>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ShortBio { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<MovieActor> MovieActor { get; set; }
    }
}
