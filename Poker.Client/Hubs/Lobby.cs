using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Poker.Client.Models;
using Poker.Client.Proxies;

namespace Poker.Client.Hubs
{
    public class Lobby : Hub
    {
        private readonly IGameServiceProxy _gameServiceProxy;

        public Lobby(IGameServiceProxy gameServiceProxy)
        {
            _gameServiceProxy = gameServiceProxy;
        }

        public async void CheckAvailableGames()
        {
            var games = await _gameServiceProxy.GetGames();

            Clients.Caller.gamesAvailable(games);
        }

        public async void RequestGameSummary(Guid gameId)
        {
            var gameSummary = await _gameServiceProxy.GetGame(gameId);

            Clients.Caller.onGameSummaryReceived(gameSummary);
        }

        public async Task RequestBuyIn(Guid gameId)
        {
            await Groups.Add(Context.ConnectionId, "game/" + gameId);

            await _gameServiceProxy.BuyIn(gameId);

            //Groups.Add(Context.ConnectionId, "game/")

            //buy in record is created first regardless
            //we then check this record for its status, for longer than the process has timeout

        }
    }
}