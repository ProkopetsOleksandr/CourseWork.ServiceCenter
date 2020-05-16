using System.Threading;
using System.Web.Mvc;

namespace CourseWork.ServiceCenter.Attributes
{
    public class OnlyAllowedAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/Page404.cshtml" };
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}