using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComptaIdentityProvider.Pages.ChangePassword;

[SecurityHeaders]
public class Index : PageModel
{
    private readonly IRefreshTokenStore _refreshTokenStore;

    public ViewModel View { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public Index(IRefreshTokenStore refreshTokenStore)
    {
        _refreshTokenStore = refreshTokenStore;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var subject = User.Claims.First(c => c.Type == "sub").Value;
        await _refreshTokenStore.RemoveRefreshTokensAsync(subject, "web");

        return Page();
    }
}