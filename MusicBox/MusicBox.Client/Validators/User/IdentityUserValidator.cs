using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MusicBox.App_Start.Core;

namespace MusicBox.Validators.User
{
    public class IdentityUserValidator : UserValidator<Domain.Models.Entities.Identity.User>
    {
        public IdentityUserValidator(AppUserManager mgr)
            : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
            RequireUniqueEmail = true;
        }

        public override async Task<IdentityResult> ValidateAsync(Domain.Models.Entities.Identity.User user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (user.UserName.Length < 3 || user.UserName.Length > 20)
            {
                var errors = result.Errors.ToList();
                errors.Add("Длина логина должна быть в диапазоне от 3 до 20 символов.");
                result = new IdentityResult(errors);
            }

            if (user.DateBorn != null)
            {
                if (user.DateBorn.Value.Year <= 1901 || user.DateBorn >= DateTime.Now)
                {
                    var errors = result.Errors.ToList();
                    errors.Add($"Дата рождения должна быть в диапазоне 1900.01.01 - {DateTime.Now.ToShortDateString()}");
                    result = new IdentityResult(errors);
                }
            }

            return result;
        }
    }
}
