using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities.Identity;
using MusicBox.Validators.User;

namespace MusicBox.App_Start.Core
{
    public class AppUserManager : UserManager<User>// , IAppUserManager
    {
        public AppUserManager(IUserStore<User> store)
                : base(store)
        {
            UserValidator = new IdentityUserValidator(this);

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = true,
            };

            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            EmailService = new EmailService();
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            MusicBoxDbContext db = context.Get<MusicBoxDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<User>(db));

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }

    public class AppRoleManager : RoleManager<Role>
    {
        public AppRoleManager(RoleStore<Role> store)
                    : base(store)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options,  IOwinContext context)
        {
            return new AppRoleManager(new
                    RoleStore<Role>(context.Get<MusicBoxDbContext>()));
        }
    }
}