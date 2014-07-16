using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using Poker.Api.Models;
using Poker.Application;
using Poker.Core.Commands;

namespace Poker.Api.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private readonly IDispatchCommands _commandDispatcher;

        public GamesController(IDispatchCommands commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public HttpResponseMessage Get()
        {
            var games = new List<Game>
            {
                new Game { Id = Guid.NewGuid(), Name = "Game One"}
            };

            return Request.CreateResponse(HttpStatusCode.OK, games);
        }

        public HttpResponseMessage Get(Guid id)
        {
            var gameSummary = new Game
            {
                Id = id,
                Name = "summary"
            };

            return Request.CreateResponse(HttpStatusCode.OK, gameSummary);
        }

        [HttpPost, Route("{gameid}/players")]
        public HttpResponseMessage JoinGame(Guid gameId, GamePlayer gamePlayer)
        {
            Guid id = Guid.NewGuid(); //we have id of game and id of player then we gen id of instance of this player in this game


            var joinGame = new JoinGame(gameId, id);

            _commandDispatcher.Dispatch(joinGame);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet, Route("{gameid}/players/{playerid}")]
        public HttpResponseMessage Players(Guid gameId, Guid playerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
