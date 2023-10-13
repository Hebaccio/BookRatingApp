using Bookies.Core.BasicClasses;
using Bookies.Core.BookClasses;
using Bookies.Core.PersonClasses;
using Bookies.Core.UnusedClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Repository
{
    public class BookiesContext : DbContext
    {
        public BookiesContext(DbContextOptions<BookiesContext> dbContext)
            :base(dbContext) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSocial>().HasKey(e => new { e.PersonID, e.SocialMediaID, e.Count });
            modelBuilder.Entity<BookStaff>().HasKey(e => new { e.BookID, e.PersonID, e.RoleID });
            modelBuilder.Entity<RelatedBooks>().HasKey(e => new { e.Book1_ID, e.Book2_ID, e.RelationID });
            modelBuilder.Entity<BookGenre>().HasKey(e => new { e.GenreID, e.BookID });
            modelBuilder.Entity<BookTag>().HasKey(e => new { e.TagID, e.BookID });
            modelBuilder.Entity<BookCharacter>().HasKey(e => new { e.BookID, e.CharacterID });
            modelBuilder.Entity<BookSeries>().HasKey(e => new { e.BookID, e.SeriesID });
        }

        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<PersonSocial> PersonSocial { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<BookStaff> BookStaff { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<RelatedBooks> RelatedBooks { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<BookCharacter> BookCharacter { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BookTag> BookTag { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Tag> Tag { get; set; }
        
    }
}
