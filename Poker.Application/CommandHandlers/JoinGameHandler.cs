using Poker.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.Events;

namespace Poker.Application.CommandHandlers
{
    public class JoinGameHandler : IHandleCommand<JoinGame>
    {
        private readonly IPublishEvents _eventsPublisher;

        public JoinGameHandler(IPublishEvents eventsPublisher)
        {
            _eventsPublisher = eventsPublisher;
        }

        public void Handle(JoinGame joinGame)
        {
            _eventsPublisher.Publish(new PlayerJoinedGame(joinGame.GameId, joinGame.PlayerId));
        }
    }
}
