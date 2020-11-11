using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MusicBox.Utilities.AuthorizeAttributes
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        public int Age { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            ClaimsIdentity claimsIdentity;
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
            var yearClaims = claimsIdentity.FindFirst("Year");
            if (yearClaims == null)
            {
                return false;
            }

            if (!DateTime.TryParse(yearClaims.Value, out DateTime dateBorn))
            {
                return false;
            }

            DateTime age = dateBorn - (DateTime.Now - dateBorn);

            if (age.Year < Age)
            {
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}