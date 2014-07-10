using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poker.Client.Models.Representations
{
    public class PlayerJoinedGame
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
    }
}