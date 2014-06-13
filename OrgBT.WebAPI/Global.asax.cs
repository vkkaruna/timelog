using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OrgBT.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!this.Context.Request.Url.AbsolutePath.StartsWith("/api"))
            {
                this.Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:9000");
                this.Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
                this.Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                this.Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            }
        }
    }
}
