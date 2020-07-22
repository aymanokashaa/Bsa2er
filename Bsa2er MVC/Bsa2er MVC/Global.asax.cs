using Bsa2er_MVC.Models;
using Bsa2er_MVC.Repositories;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bsa2er_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest()
        {
            VisitorRepository.AddVisitor(new Visitor() { IpAddress = Request.UserHostAddress, DateTimeOfVisit = DateTime.Now });
        }
    }
}
