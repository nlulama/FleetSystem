using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FleetSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

        public System.Data.Entity.DbSet<FleetSystem.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.Gender> Genders { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.AddressType> AddressTypes { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.VehicleMake> VehicleMakes { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.VehicleModel> VehicleModels { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.VehicleColor> VehicleColors { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.ChecklistYesNo> ChecklistYesNoes { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.Checklist> Checklists { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.Trip> Trips { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.TripRecord> TripRecords { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.Route> Routes { get; set; }

        public System.Data.Entity.DbSet<FleetSystem.Models.InspectChecklist> InspectChecklists { get; set; }
    }
}