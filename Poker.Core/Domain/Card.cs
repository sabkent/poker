using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.Domain
{
    public class Card
    {
        public Card(Suits suit, Ranks rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        public string Id
        {
            get
            {
                return Suit + "-" + Rank;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", Rank, Suit);
        }
    }
}
