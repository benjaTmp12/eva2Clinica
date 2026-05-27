using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace eva2Clinica.Controllers
{
    // Base controller that redirects to Login when there is no session "Usuario"
    public class AuthenticatedController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuario = context.HttpContext.Session.GetString("Usuario");
            var path = context.HttpContext.Request.Path.Value ?? string.Empty;

            // Allow access to the Login controller and static assets
            if (string.IsNullOrEmpty(usuario) && !path.StartsWith("/login", System.StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
