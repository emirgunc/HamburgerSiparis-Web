using System.Web.Mvc;

namespace HamburgerSiparis.Web.Filters
{
    
    public class KimlikAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
           
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                
                filterContext.Result = new RedirectResult("/Yonetim/Login/Index");
            }
        }
    }
}