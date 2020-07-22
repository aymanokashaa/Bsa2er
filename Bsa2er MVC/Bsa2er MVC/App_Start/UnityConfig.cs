using Bsa2er_MVC.Controllers;
using Bsa2er_MVC.Models;
using Bsa2er_MVC.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Bsa2er_MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<IRepository<news>, NewsRepository>();
           // container.RegisterType<IUserStore<ApplicationUser> , UserStore<ApplicationUser>>();
           // container.RegisterType<DbConnection, SqlConnection>(new InjectionFactory(c => new SqlConnection("DefaultConnection")));
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}