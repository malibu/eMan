using eManager.Core;
using eManager.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eManager.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            //  This method will be called after migrating to the latest version.
            context.Departments.AddOrUpdate(d=> d.Name,
                new Department(){ Name = "Software Development"},
                new Department(){Name="Systems Engineering"},
                new Department() { Name = "Business Development" }
                );

        }
    }

    internal sealed class AppConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public AppConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected async override void Seed(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser(){ UserName = "avalliath"};
           await  userManager.CreateIdentityAsync(user, "Password1");

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(new IdentityRole() {Name = "Admin"});
             user = userManager.FindByName("avalliath");
            userManager.AddToRole(user.Id, "admin");
            base.Seed(context);
        }
    }
}
