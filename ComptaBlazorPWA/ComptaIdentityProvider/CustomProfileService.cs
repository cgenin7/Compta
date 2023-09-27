using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ComptaIdentityRepository.Models;

namespace ComptaIdentityProvider
{
	public class CustomProfileService : ProfileService<ApplicationComptaUser>
    {
        public CustomProfileService(UserManager<ApplicationComptaUser> userManager, IUserClaimsPrincipalFactory<ApplicationComptaUser> claimsFactory) : base(userManager, claimsFactory)
        {
        }

        protected override async Task GetProfileDataAsync(ProfileDataRequestContext context, ApplicationComptaUser user)
        {
            var principal = await GetUserClaimsAsync(user);
            var id = (ClaimsIdentity)principal.Identity;
            id.AddClaim(new Claim("TestId", 5.ToString()));
            
            context.AddRequestedClaims(principal.Claims);
        }
    }
}