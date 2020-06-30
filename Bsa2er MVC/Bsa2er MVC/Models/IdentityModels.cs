using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bsa2er_MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [MetadataType(typeof(HelperClass))]
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="البلد")]
        public string Country { set; get; }
        [Display(Name ="المؤهل")]
        public string Qualification { set; get; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    
    public class HelperClass
    {
        [Display(Name ="البريد الالكترونى")]
        public virtual string Email { get; set; }
        [Display(Name = "رقم الهاتف")]
        public virtual string PhoneNumber { get; set; }
        [Display(Name = "هل أكد رقم الهاتف")]
        public virtual bool PhoneNumberConfirmed { get; set; }
        [Display(Name = "أسم المستخدم")]
        public virtual string UserName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)

        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Book> Books { set; get; }
        public virtual DbSet<Booksection> Booksections { set; get; }

        public virtual DbSet<news> News { set; get; }
        public virtual DbSet<Exam> Exams { set; get; }
        public virtual DbSet<Instructor> Instructors { set; get; }
        public virtual DbSet<Lecture> Lectures { set; get; }
 
        public virtual DbSet<Program> Programs { set; get; }
        public virtual DbSet<Question> Questions { set; get; }
        public virtual DbSet<StudentsPrograms> StudentsPrograms { set; get; }
        public virtual DbSet<Student> Students { set; get; }
        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}