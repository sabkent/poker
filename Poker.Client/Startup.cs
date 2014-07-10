using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin;
using Owin;
using Poker.Client.Controllers.Api;
using Poker.Client.Hubs;

[assembly: OwinStartupAttribute(typeof(Poker.Client.Startup))]
namespace Poker.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterApiControllers(assembly);
            containerBuilder.RegisterControllers(assembly);

            containerBuilder.Register(c => GlobalHost.DependencyResolver.Resolve<IConnectionManager>().GetHubContext<ActiveGame>())
            .Named<IHubContext>("ActiveGame");

            containerBuilder.RegisterType<EventsController>().WithParameter(ResolvedParameter.ForNamed<IHubContext>("ActiveGame"));

            var container = containerBuilder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var httpConfiguration = new HttpConfiguration()
            {
                DependencyResolver = resolver
            };

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);

            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
