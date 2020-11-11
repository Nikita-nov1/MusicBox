using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicBox.App_Start.Core;
using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Models.Entities.Identity;

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

            User nikita = new User
            {
                FirstName = "Никита",
                LastName = "Новицкий",
                UserName = "SuperUser",
                Email = "nikita.novitski11@gmail.com",
                DateBorn = new DateTime(1997, 05, 17),
                UserImage = new UserImage(),
                EmailConfirmed = true
            };
            string password = "123456Nik";

            var result1 = userManager.Create(nikita, password);

            if (result1.Succeeded)
            {
                userManager.AddToRole(nikita.Id, "Admin");
                userManager.AddToRole(nikita.Id, "User");
            }

            User alexey = new User
            {
                FirstName = "Алексей",
                LastName = "Кузьмицкий",
                UserName = "SuperUser1",
                Email = "alexey@mail.ru",
                DateBorn = new DateTime(1980, 10, 25),
                UserImage = new UserImage(),
                EmailConfirmed = true
            };
            password = "123456Alexey";
            var result2 = userManager.Create(alexey, password);

            if (result2.Succeeded)
            {
                userManager.AddToRole(alexey.Id, "Admin");
                userManager.AddToRole(alexey.Id, "User");
            }
        }
    }
}
