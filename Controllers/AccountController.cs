using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sales_and_Finance.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sales_and_Finance.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/Register")]
        [HttpPost]
        public IdentityResult Register(AccountVm model)
        {
            var userStore = new UserStore<ApplicationUser>(new Models.Identity.IdentityDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.Username };
            IdentityResult result = manager.Create(user, model.Password);
            return result;

        }
    }
}
