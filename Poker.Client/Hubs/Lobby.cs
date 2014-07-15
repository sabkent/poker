using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Poker.Client.Models;

namespace Poker.Client.Hubs
{
    public class Lobby : Hub
    {
        public void CheckAvailableGames()
        {
            Clients.All.gamesAvailable(new List<GameListItem>
            {
                new GameListItem {Id = Guid.NewGuid(), Name = "No holes barred"}
            });
        }

        public void RequestGameSummary(Guid gameId)
        {
            Clients.All.onGameSummaryReceived(new GameSummary{Id = Guid.NewGuid(), Name = "Summary"});
        }
    }
}