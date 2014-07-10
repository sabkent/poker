using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Poker.Client.Models.Representations;

namespace Poker.Client.Controllers.Api
{
    [RoutePrefix("api/events")]
    public class EventsController : ApiController
    {
        private readonly IHubContext _hubContext;

        public EventsController(IHubContext hubContext)
        {
            _hubContext = hubContext;
        }


        [Route("players")]
        public HttpResponseMessage Player(PlayerJoinedGame playerJoinedGame)
        {
            _hubContext.Clients.All.playerJoined();
   
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
