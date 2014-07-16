using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.Domain
{
    public class HandEvaluator
    {
        public int Score(IEnumerable<Card> hand)
        {
            if (hand.Any() == false)
                return 0;

            var handTotal = hand.Sum(card => (int)card.Rank);  // 69 AAAAK   so each category increment by 100
            var orderedHand = hand.OrderBy(card => card.Rank).ToList();
            
            if (IsRoyalFlush(orderedHand))
                return 900; //no breaker
            if (IsStraightFlush(orderedHand))
                return 800 + handTotal;
            if (IsFourOfAKind(orderedHand))
                return 700 + handTotal;
            if (IsFullHouse(orderedHand))
                return 600 + handTotal;
            if (IsFlush(orderedHand))
                return 500 + handTotal;
            if (IsStraight(orderedHand))
                return 400 + handTotal;
            if (IsThreeOfAKind(orderedHand))
                return 300 + handTotal;
            if (IsTwoPair(orderedHand))
                return 200 + handTotal;
            if (IsTwoOfAKind(orderedHand))
                return 100 + handTotal;

            return 0;
        }

        private bool IsRoyalFlush(List<Card> hand)
        {
            if (hand.Any(card => card.Rank < Ranks.Ten))
                return false;

            var firstCard = hand.First();
            var lastCard = hand.Last();

            if (hand.Any(card => card.Suit != firstCard.Suit))
                return false;

            if (firstCard.Rank != Ranks.Ten || lastCard.Rank != Ranks.Ace)
                return false;

            return true;
        }

        private bool IsStraightFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        private bool IsFourOfAKind(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank, card => card, (key, g) => new {Count = g.Count()}).Any(g => g.Count == 4);
        }

        private bool IsFullHouse(List<Card> hand)
        {
            var groupedByRank = hand.GroupBy(card => card.Rank, card => card, (key, g) => new {Rank = key, Count = g.Count()});

            return groupedByRank.Count() == 2;
        }

        private bool IsFlush(List<Card> hand)
        {
            var first = hand.First();
            return hand.Any(card => card.Suit != first.Suit) == false;
        }

        private bool IsStraight(List<Card> hand)
        {
            for (int i = 0; i < 4; i++)
            {
                var d = hand[i + 1].Rank - hand[i].Rank;
                if (d == 0)
                    return false;
                if (d > 1)
                {
                    if (hand[i + 1].Rank != Ranks.Ace)
                        return false;
                }
            }

            var diff = hand.Last().Rank - hand.First().Rank;
            if (hand.Last().Rank == Ranks.Ace)
                return diff == 12;

            return diff == 4;
        }

        private bool IsThreeOfAKind(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Count = g.Count() }).Any(g => g.Count == 3);
        }

        private bool IsTwoPair(List<Card> hand)
        {
            var groups = hand.GroupBy(card => card.Rank, card => card, (key, g) => new {Count = g.Count()});
            return groups.Count() == 3;
        }

        private bool IsTwoOfAKind(List<Card> hand)
        {
            return hand.GroupBy(card => card.Rank, card => card, (key, g) => new { Count = g.Count() }).Any(g => g.Count == 2);
        }
    }
}
