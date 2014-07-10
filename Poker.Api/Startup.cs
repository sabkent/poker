using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using Poker.Api.App_Start;
using Poker.Application;
using System.Reflection;

[assembly: OwinStartup(typeof(Poker.Api.Startup))]
namespace Poker.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyModules(typeof (IHandleCommand<>).Assembly);

            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = containerBuilder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            
            var httpConfiguration = new HttpConfiguration()
            {
                DependencyResolver = resolver
            };

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}