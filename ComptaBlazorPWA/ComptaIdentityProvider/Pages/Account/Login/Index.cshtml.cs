using ComptaIdentityRepository.Models;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComptaIdentityProvider.Pages.Login;

[SecurityHeaders]
[AllowAnonymous]
public class Index : PageModel
{
    private readonly UserManager<ApplicationComptaUser> _userManager;
    private readonly SignInManager<ApplicationComptaUser> _signInManager;
    private readonly IIdentityServerInteractionService _interaction;
    private readonly IEventService _events;
    private readonly IAuthenticationSchemeProvider _schemeProvider;
    private readonly IIdentityProviderStore _identityProviderStore;

    public ViewModel View { get; set; }
        
    [BindProperty]
    public InputModel Input { get; set; }
        
    public Index(
        IIdentityServerInteractionService interaction,
        IAuthenticationSchemeProvider schemeProvider,
        IIdentityProviderStore identityProviderStore,
        IEventService events,
        UserManager<ApplicationComptaUser> userManager,
        SignInManager<ApplicationComptaUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _interaction = interaction;
        _schemeProvider = schemeProvider;
        _identityProviderStore = identityProviderStore;
        _events = events;
    }
        
    public async Task<IActionResult> OnGet(string returnUrl)
    {
        await BuildModelAsync(returnUrl);
            
        return Page();
    }
        
    public async Task<IActionResult> OnPost()
    {
        // check if we are in the context of an authorization request
        var authorizationRequest = await _interaction.GetAuthorizationContextAsync(Input.ReturnUrl);

        // the user clicked the "cancel" button
        if (Input.Button != "login")
        {
            return await CancelRequest(authorizationRequest);
        }

        if (ModelState.IsValid)
        {
            var (success, result) = await LoginUser(authorizationRequest);

            if (success) return result;
        }

        // something went wrong, show form with error
        await BuildModelAsync(Input.ReturnUrl);
        return Page();
    }

    private async Task<IActionResult> CancelRequest(AuthorizationRequest authorizationRequest)
    {
		if (authorizationRequest != null)
		{
			// if the user cancels, send a result back into IdentityServer as if they 
			// denied the consent (even if this client does not require consent).
			// this will send back an access denied OIDC error response to the client.
			await _interaction.DenyAuthorizationAsync(authorizationRequest, AuthorizationError.AccessDenied);

			// we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
			if (authorizationRequest.IsNativeClient())
			{
				// The client is native, so this change in how to
				// return the response is for better UX for the end user.
				return this.LoadingPage(Input.ReturnUrl);
			}

			return Redirect(Input.ReturnUrl);
		}
		// since we don't have a valid authorization request, then we just go back to the home page
		return Redirect("~/");
	}

    private async Task<(bool, IActionResult)> LoginUser(AuthorizationRequest authorizationRequest)
    {
		var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberLogin, lockoutOnFailure: true);

        if (result.Succeeded)
		{
			var user = await _userManager.FindByNameAsync(Input.Username);
			await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: authorizationRequest?.Client.ClientId));

			if (authorizationRequest != null)
			{
				if (authorizationRequest.IsNativeClient())
				{
					// The client is native, so this change in how to
					// return the response is for better UX for the end user.
					return (true, this.LoadingPage(Input.ReturnUrl));
				}

                // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                return (true, Redirect(Input.ReturnUrl));
			}

			// request for a local page
			if (Url.IsLocalUrl(Input.ReturnUrl))
			{
				return (true, Redirect(Input.ReturnUrl));
			}
			else if (string.IsNullOrEmpty(Input.ReturnUrl))
			{
				return (true, Redirect("~/"));
			}
			else
			{
				// user might have clicked on a malicious link - should be logged
				throw new Exception("invalid return URL");
			}
		}

		await _events.RaiseAsync(new UserLoginFailureEvent(Input.Username, "invalid credentials", clientId: authorizationRequest?.Client.ClientId));
		ModelState.AddModelError(string.Empty, LoginOptions.InvalidCredentialsErrorMessage);

        return (false, null);
	}

    private async Task BuildModelAsync(string returnUrl)
    {
        Input = new InputModel
        {
            ReturnUrl = returnUrl
        };
            
        View = new ViewModel
        {
            AllowRememberLogin = LoginOptions.AllowRememberLogin
        };
    }
}