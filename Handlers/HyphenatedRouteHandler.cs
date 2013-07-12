using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

<<<<<<< HEAD
namespace MAXX.Utils.Handlers
=======
namespace SharpUtils.Handlers
>>>>>>> f361537f27e6b6f61d375995c8601980250ac55a
{
    public class HyphenatedRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.RouteData.Values["controller"] = requestContext.RouteData.Values["controller"].ToString().Replace("-", "_");
            requestContext.RouteData.Values["action"] = requestContext.RouteData.Values["action"].ToString().Replace("-", "_");
            return base.GetHttpHandler(requestContext);
        }
    }
}
