using Microsoft.AspNet.SignalR.Infrastructure;
using Poker.Client.Hubs;
using Poker.Client.Models.Representations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Poker.Client.Controllers.Api
{
    [RoutePrefix("api/lobby-events")]
    public class LobbyEventsController : ApiController
    {
        private readonly IConnectionManager _connectionManager;

        public LobbyEventsController(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        [Route("players")]
        public HttpResponseMessage Player(PlayerJoinedGame playerJoinedGame)
        {
            var hubContext = _connectionManager.GetHubContext<Lobby>();
            hubContext.Clients.Group("game/" + playerJoinedGame.GameId).playerJoinedGame(playerJoinedGame);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
