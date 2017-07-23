using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Port.Net.Data.Infrastructure;
using Port.Net.Models.Dto;

namespace Port.Net.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly PortfolioContext _portfolioContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _portfolioContext = new PortfolioContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_portfolioContext));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = userModel.UserName;

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _portfolioContext.Dispose();
            _userManager.Dispose();
        }
    }
}
