using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

public class CultureController : Controller
{
    [HttpPost]
    public IActionResult SetCulture(string culture)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return Redirect(Request.Headers["Referer"].ToString());
    }
}

