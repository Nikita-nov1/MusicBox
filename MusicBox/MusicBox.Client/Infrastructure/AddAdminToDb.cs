using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicBox.App_Start.Core;
using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Models.Entities.Identity;
using System;

namespace MusicBox.Infrastructure
{
    public class AddAdminToDb
    {
        public AddAdminToDb()
        {
            Seed(new MusicBoxDbContext());
        }


        private void Seed(MusicBoxDbContext context)
        {
            var userManager = new AppUserManager(new UserStore<User>(context));

            User admin1 = new User
            {
                FirstName = "Никита",
                LastName = "Новицкий",
                UserName = "SuperUser",
                Email = "nikita@mail.ru",
                DateBorn = new DateTime(1997, 05, 17),
                UserImage = new UserImage(),
            };
            string password = "123456nik";

            var result = userManager.Create(admin1, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin1.Id, "Admin");
                userManager.AddToRole(admin1.Id, "User");
            }

        }
    }
}

