using System;
namespace Poker.Core.Commands
{
    public sealed class JoinGame : ICommand
    {
        public JoinGame(Guid gameId, Guid playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }
        public Guid GameId { get; private set; }
        public Guid PlayerId { get; private set; }
    }
}
