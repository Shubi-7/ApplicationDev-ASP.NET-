﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CourseWork2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="Full Name"),Required]
        public string FullName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IEnumerable<object> User { get; internal set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CourseWork2.Models.ArtistAlbum> ArtistAlbums { get; set; }

        public System.Data.Entity.DbSet<CourseWork2.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<CourseWork2.Models.Producer> Producers { get; set; }

        public System.Data.Entity.DbSet<CourseWork2.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<CourseWork2.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<CourseWork2.Models.LoanType> LoanTypes { get; set; }

        public System.Data.Entity.DbSet<CourseWork2.Models.Loan> Loans { get; set; }

    }
}