using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using Sales_and_Finance.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Sales_and_Finance
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var UserStore = new UserStore<ApplicationUser>(new Models.Identity.IdentityDbContext());
            var UserManager = new UserManager<ApplicationUser>(UserStore);
            var user = await UserManager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                context.Validated(identity);
            }
            else 
            {
                return;
            }
        }

    }
}