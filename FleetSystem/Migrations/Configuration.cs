namespace FleetSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FleetSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FleetSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FleetSystem.Models.ApplicationDbContext";
        }

        protected override void Seed(FleetSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Genders.AddOrUpdate(
                  p => p.Name,
                  new Gender { Name = "Female" },
                  new Gender { Name = "Male" },
                  new Gender { Name = "Unknown" }
                );

            context.AddressTypes.AddOrUpdate(
                 p => p.Type,
                 new AddressType { Type = "Postal" },
                 new AddressType { Type = "Residential" },
                 new AddressType { Type = "Fuel" }
               );

            context.VehicleMakes.AddOrUpdate(
               p => p.Make,
               new VehicleMake { Make = "Toyota" },
               new VehicleMake { Make = "Scania" },
               new VehicleMake { Make = "Volvo" }
             );

            context.VehicleColors.AddOrUpdate(
               p => p.Color,
               new VehicleColor { Color = "Blue" },
               new VehicleColor { Color = "Black" },
               new VehicleColor { Color = "Green" }
             );

            context.ChecklistYesNoes.AddOrUpdate(
               p => p.Value,
               new ChecklistYesNo { Value = "" },
               new ChecklistYesNo { Value = "Yes" },
               new ChecklistYesNo { Value = "No" }
             );

            context.Routes.AddOrUpdate(
              p => p.RouteName,
              new Route { RouteName = "Pretoria" },
              new Route { RouteName = "Cape Town" },
              new Route { RouteName = "Durban" }
            );
        }
    }
}
