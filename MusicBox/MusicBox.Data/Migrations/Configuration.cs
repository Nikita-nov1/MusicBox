using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities.Identity;
using System.Data.Entity.Migrations;

namespace MusicBox.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MusicBoxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicBoxDbContext context)
        {
            var roleStore = new RoleStore<Role>(context);
            var roleManager = new RoleManager<Role>(roleStore);
            roleManager.Create(new Role { Name = "Admin", Description = "Administrator" });
            roleManager.Create(new Role { Name = "User", Description = "User" });

            context.SaveChanges();
           

        }
    }
}
