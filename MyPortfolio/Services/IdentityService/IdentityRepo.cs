using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Services.IdentityService
{
    public class IdentityRepo : IIdentityRepo
    {
        private readonly UserManager<IdentityUser<Guid>> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser<Guid>> signInManager;

        public IdentityRepo(UserManager<IdentityUser<Guid>> userManager, IConfiguration configuration,
            SignInManager<IdentityUser<Guid>> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        public async Task<Guid?> Login(string username, string password)
        {
            if (!userManager.Users.Any())
            {
                var createResult = await userManager.CreateAsync(new IdentityUser<Guid>
                {
                    Id = Guid.NewGuid(),
                    UserName = configuration.GetSection("Account:UserName").Value,
                }, configuration.GetSection("Account:Password").Value);

                if(createResult != IdentityResult.Success)
                    return null;
            }

            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return null;
            }

            var loginResult = await signInManager.PasswordSignInAsync(user, password, true, false);
            if (loginResult == Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                return user.Id;
            }

            return null;
        }
    }
}
