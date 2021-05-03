using FEE.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SessionFilter());
        }
        
    }
    public class SessionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.Session["UserID"] == null)
            {
                FEEDbContext db = new FEEDbContext();
                bool Exist = db.Users.Any(e => e.Username == HttpContext.Current.User.Identity.Name);
                if (Exist)
                {
                    var user = db.Users.Where(e => e.Username == HttpContext.Current.User.Identity.Name).First();
                    HttpContext.Current.Session["UserID"] = user.Id;
                    HttpContext.Current.Session["Name"] = user.Name;
                }
            }
            base.OnActionExecuting(filterContext);
        }

    }
}
