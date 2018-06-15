using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoviesHub.Models
{
    public partial class MoviesMvcContext : DbContext
    {
        public MoviesMvcContext()
        {
        }

        public MoviesMvcContext(DbContextOptions<MoviesMvcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<ContentRating> ContentRating { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.ProfilePictureUrl).HasMaxLength(256);

                entity.Property(e => e.ShortBio).HasMaxLength(256);
            });

            modelBuilder.Entity<ContentRating>(entity =>
            {
                entity.HasIndex(e => e.Symbol)
                    .HasName("AK_ContentRating_Name")
                    .IsUnique();

                entity.Property(e => e.LongDescription).HasMaxLength(256);

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.PosterUrl).HasMaxLength(256);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Revenue).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Summary).HasMaxLength(1024);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VideoPosterUrl).HasMaxLength(256);

                entity.Property(e => e.VideoUrl).HasMaxLength(256);

                entity.HasOne(d => d.ContentRating)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.ContentRatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorId });

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).ValueGeneratedNever();

                entity.Property(e => e.Reviewer)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Score).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
