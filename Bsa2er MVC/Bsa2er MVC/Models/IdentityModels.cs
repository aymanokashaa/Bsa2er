<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
﻿using System.Collections.Generic;
>>>>>>> 314a48b15a8847697b782934e0ff792795530fcf
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bsa2er_MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Country{set;get;}
        public string Qualification{set;get;}
           
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       
        public virtual Student Student { set; get; }
        public virtual Instructor Instructor { set; get; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)

        {
        }
        public virtual DbSet<Book> Books { set; get; }
        public virtual DbSet<Booksection> Booksections { set; get;}

        public virtual DbSet<news> News { set; get; }
        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }
        public virtual DbSet<Program> Programs { set; get; }
        public virtual DbSet<Lecture> Lectures { set; get; }
        public virtual DbSet<Exam> Exams { set; get; }
        public virtual DbSet<Certification> Certifications { set; get; }
        public virtual DbSet<Question> Questions { set; get; }
        public virtual DbSet<Instructor> Instructors { set; get; }
        public virtual DbSet<Student> Students { set; get; }
    }
}