using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities.Identity;

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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new Role { Name = "Admin", Description = "Administrator" });
            roleManager.Create(new Role { Name = "User", Description = "User" });

            context.SaveChanges();
        }
    }
}
