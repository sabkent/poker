using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin;
using Owin;
using Poker.Client.Controllers.Api;
using Poker.Client.Hubs;
using Poker.Client.Proxies;

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
            containerBuilder.RegisterHubs(assembly);

            containerBuilder.Register(c => GlobalHost.DependencyResolver.Resolve<IConnectionManager>().GetHubContext<ActiveGame>())
            .Named<IHubContext>("ActiveGame");
            containerBuilder.Register(c=> GlobalHost.DependencyResolver.Resolve<IConnectionManager>().GetHubContext<Lobby>()).Named<IHubContext>("Lobby");

            containerBuilder.RegisterType<LobbyEventsController>()
                .WithParameter(ResolvedParameter.ForNamed<IHubContext>("Lobby"));

            containerBuilder.RegisterType<GameServiceProxy>().As<IGameServiceProxy>();

            //containerBuilder.Register(c => GlobalHost.DependencyResolver.Resolve<IConnectionManager>())
            //    .As<IConnectionManager>();

            var container = containerBuilder.Build();

            var webApiDependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));

            var signalrResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);
            app.MapSignalR(new HubConfiguration()
            {
                Resolver = signalrResolver
            });

            var conn = signalrResolver.Resolve<IConnectionManager>();

            var cb2 = new ContainerBuilder();
            cb2.Register(c => conn).As<IConnectionManager>();
            cb2.Update(container);

            var httpConfiguration = new HttpConfiguration()
            {
                DependencyResolver = webApiDependencyResolver
            };

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);

            ConfigureAuth(app);


        }
    }
}
