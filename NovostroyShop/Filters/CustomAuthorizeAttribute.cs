using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace NovostroyShop.Filters
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Если пользователь не аутентифицирован, перенаправляем его на страницу регистрации
                context.Result = new RedirectToActionResult("Login", "Authenticate", null);
            }
        }
    }
}
