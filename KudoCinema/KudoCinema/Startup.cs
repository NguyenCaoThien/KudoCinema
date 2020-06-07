using KudoCinema.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KudoCinema.Startup))]
namespace KudoCinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleAndUser();
        }

        private void CreateRoleAndUser()
        {
            var context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists(RoleName.Admin))
            {
                var role = new IdentityRole();
                role.Name = RoleName.Admin;
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";

                string password = "admin@password";

                var createdUser = userManager.Create(user, password);

                if (createdUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, RoleName.Admin);
                }
            }
        }
    }
}
