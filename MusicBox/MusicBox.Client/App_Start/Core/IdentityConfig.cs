using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities.Identity;

namespace MusicBox.App_Start.Core
{
    public class AppUserManager : UserManager<User>// , IAppUserManager
    {
        public AppUserManager(IUserStore<User> store)
                : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            MusicBoxDbContext db = context.Get<MusicBoxDbContext>();
            AppUserManager manager = new AppUserManager(new UserStore<User>(db));
            return manager;
        }

        // 1
        // public class FastBusUserManager : UserManager<User, int>       ---- валидация User
        // {
        //    public FastBusUserManager(FastBusUserStore store)
        //        : base(store)
        //    {
        //        UserValidator = new UserValidator<User, int>(this)
        //        {
        //            AllowOnlyAlphanumericUserNames = false,
        //            RequireUniqueEmail = true
        //        };

        // PasswordValidator = new PasswordValidator
        //        {
        //            RequiredLength = 6,
        //            RequireNonLetterOrDigit = false,
        //            RequireDigit = false,
        //            RequireLowercase = false,
        //            RequireUppercase = false
        //        };

        // UserLockoutEnabledByDefault = false;
        //    }
        //
        // 1
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