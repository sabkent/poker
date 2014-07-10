using System;

namespace Poker.Core.Events
{
    public sealed class PlayerJoinedGame : IEvent
    {
        private readonly Guid _gameId;
        private readonly Guid _playerId;

        public PlayerJoinedGame(Guid gameId, Guid playerId)
        {
            _gameId = gameId;
            _playerId = playerId;
        }

        public Guid GameId { get { return _gameId; } }
        public Guid PlayerId { get { return _playerId; } }
    }
}
