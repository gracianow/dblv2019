using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SiteDblv
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //force https on server, ignore it on local machine
        //protected void Application_BeginRequest()
        //{
        //    if (!Context.Request.IsSecureConnection)
        //    {
        //        if (HttpContext.Current.Request.IsLocal)
        //        {
        //            Response.Redirect(Context.Request.Url.ToString().Replace("http://localhost:4356/", "https://localhost:4356/"));
        //        }
        //        else
        //        {
        //            Response.Redirect(Context.Request.Url.ToString().Replace("http://", "https://"));
        //        }
        //    }
        //}
    }
}
