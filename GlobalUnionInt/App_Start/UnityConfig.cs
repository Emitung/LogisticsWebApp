using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using GlobalUnionInt.Services.interfaces;
using GlobalUnionInt.Services;

namespace GlobalUnionInt
{
    public sealed class UnityConfig //"sealed" means it can inherit other classes and INSTANTIATE itself, but it cannot be inherited.
    {
        private static readonly UnityConfig _instance = new UnityConfig();

        private UnityConfig() { }

        static UnityConfig() { }

        public static UnityConfig Instance { get { return _instance; } }


        public void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IWebscraper, WebscraperService>();
            container.RegisterType<ITruckingCompaniesService, TruckingCompaniesService>();
            container.RegisterType<IClientCompaniesService, ClientCompaniesService>();
            container.RegisterType<IStateProvinceService, StateProvinceService>();

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container); //Handle all the API calls in Http.
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}