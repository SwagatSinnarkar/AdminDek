using AdminDek.Controllers;
using Services.Implementation;
using Services.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace AdminDek
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IAccount, AccountService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}