using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NissanCartTest01.WebUi.Models;


namespace NissanCartTest01.WebUi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public DbSet<Staff> Staffs { get; set; }

        public DbSet<RegisterViewModel> RegisterViewModels { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<JobCard> JobCards { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<BookIn> BookIns { get; set; }

        public DbSet<EmailFormModel> EmailFormModels { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Faults> Faults { get; set; }

        public DbSet<Foremen> Foremens { get; set; }

    }
}