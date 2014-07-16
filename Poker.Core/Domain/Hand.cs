using System;
using System.Collections.Generic;

namespace Poker.Core.Domain
{
    public class Hand
    {
        private List<Card> _cards;

        public Hand(List<Card> cards)
        {
            _cards = cards;
        }

        public int Score()
        {
            return new HandEvaluator().Score(_cards);
        }

    }
}
