using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poker.Client.Models.Representations
{
    public sealed class PlayerJoinedGame
    {
        public PlayerJoinedGame(Guid gameId, Guid playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }

        public Guid GameId { get; private set; }
        public Guid PlayerId { get; private set; }
    }
}