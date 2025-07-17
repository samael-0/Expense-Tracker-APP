namespace ExpenseTracker.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (session.GetString("UserEmail") == null)
            {
                // Redirect to login page
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "controller", "Account" },
                    { "action", "Login" }
                    });
            }

            base.OnActionExecuting(context);
        }
    }
}
