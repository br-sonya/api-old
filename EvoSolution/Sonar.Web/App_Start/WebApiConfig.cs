using Microsoft.Practices.Unity;
using Sonar.BLL;
using Sonar.BLL.Infra;
using Sonar.DAL;
using Sonar.DAL.Infra;
using Sonar.Web.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sonar.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            config.EnableCors();
            // DBCONTEXT
            container.RegisterType<IDbContext, SonarFrameworkDbContext>(new HierarchicalLifetimeManager());

            // DAL
            container.RegisterType<IStateRepository, StateRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IUserAccountRepository, UserAccountRepository>();


            // BLL
            container.RegisterType<IStateBLL, StateBLL>();
            container.RegisterType<IAddressBLL, AddressBLL>();
            container.RegisterType<IUserAccountBLL, UserAccountBLL>();


            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
        }
    }
}
