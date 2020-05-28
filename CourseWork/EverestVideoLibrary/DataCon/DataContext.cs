
using CourseWork2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2.DataCon
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DataContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Albums> Albums { get; set; }


        public DbSet<LoanType> LoanTypes { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<MemberCategory> MemberCategories { get; set; }
        public object ArtistAlbums { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Artist>().HasMany(b => b.Album)
                                         .WithMany(c => c.Artists)
                                         .Map(cs =>
                                         {
                                             cs.MapLeftKey("ArtistId");
                                             cs.MapRightKey("AlbumId");
                                             cs.ToTable("ArtistAlbum");
                                         });
            modelBuilder.Entity<Producer>().HasMany(b => b.Albums)
                                        .WithMany(c => c.Producers)
                                        .Map(cs =>
                                        {
                                            cs.MapLeftKey("ProducerId");
                                            cs.MapRightKey("AlbumId");
                                            cs.ToTable("ProducerAlbum");
                                        });
        }


    }

}
