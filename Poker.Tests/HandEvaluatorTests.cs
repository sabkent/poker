using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Poker.Core.Domain;

namespace Poker.Tests
{
    [TestFixture]
    public class HandEvaluatorTests
    {
        [Test]
        public void OrderHands()
        {
            Hand royalFlush = CreateRoyalFlush();
            Hand straighFlush = CreateStraightFlush();

            var score1 = royalFlush.Score();
            var score2 = straighFlush.Score();

            Assert.IsTrue(score1 > score2);
        }

        [Test]
        public void StraighFlush_HighSequenceWins()
        {
            var winningHand = new Hand(new List<Card> { new Card(Suits.Clubs, Ranks.Three), new Card(Suits.Clubs, Ranks.Four), new Card(Suits.Clubs, Ranks.Five), new Card(Suits.Clubs, Ranks.Six), new Card(Suits.Clubs, Ranks.Seven) });
            var losingHand = new Hand(new List<Card> { new Card(Suits.Clubs, Ranks.Two), new Card(Suits.Clubs, Ranks.Three), new Card(Suits.Clubs, Ranks.Four), new Card(Suits.Clubs, Ranks.Five), new Card(Suits.Clubs, Ranks.Six) });

            var winningScore = winningHand.Score();
            var losingScore = losingHand.Score();

            Assert.IsTrue(winningScore>losingScore);
        }


        private Hand CreateRoyalFlush()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.Ace),
                new Card(Suits.Clubs, Ranks.Ten),
                new Card(Suits.Clubs, Ranks.Jack),
                new Card(Suits.Clubs, Ranks.Queen),
                new Card(Suits.Clubs, Ranks.King)
            });
        }

        private Hand CreateStraightFlush()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.Two),
                new Card(Suits.Clubs, Ranks.Three),
                new Card(Suits.Clubs, Ranks.Four),
                new Card(Suits.Clubs, Ranks.Five),
                new Card(Suits.Clubs, Ranks.Six)
            });
        }

        private Hand CreateFourOfAKind()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.King),
                new Card(Suits.Hearts, Ranks.King),
                new Card(Suits.Diamonds, Ranks.King),
                new Card(Suits.Spades, Ranks.King),
                new Card(Suits.Hearts, Ranks.Four)
            });
        }

        private Hand CreateFullHouse()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.King),
                new Card(Suits.Hearts, Ranks.King),
                new Card(Suits.Diamonds, Ranks.King),
                new Card(Suits.Clubs, Ranks.Four),
                new Card(Suits.Hearts, Ranks.Four)
            });
        }

        private Hand CreateFlush()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.King),
                new Card(Suits.Clubs, Ranks.Two),
                new Card(Suits.Clubs, Ranks.Five),
                new Card(Suits.Clubs, Ranks.Seven),
                new Card(Suits.Clubs, Ranks.Ten)
            });
        }

        private Hand CreateStraight()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.Two),
                new Card(Suits.Clubs, Ranks.Three),
                new Card(Suits.Clubs, Ranks.Four),
                new Card(Suits.Clubs, Ranks.Five),
                new Card(Suits.Clubs, Ranks.Six)
            });
        }

        private Hand CreateThreeOfAKind()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.Ace),
                new Card(Suits.Hearts, Ranks.Two),
                new Card(Suits.Diamonds, Ranks.Two),
                new Card(Suits.Spades, Ranks.Two),
                new Card(Suits.Clubs, Ranks.Five)
            });
        }

        private Hand CreateTwoPair()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.Ace),
                new Card(Suits.Hearts, Ranks.Two),
                new Card(Suits.Diamonds, Ranks.Two),
                new Card(Suits.Spades, Ranks.Five),
                new Card(Suits.Clubs, Ranks.Five)
            });
        }

        private Hand CreateTwoOfAKind()
        {
            return new Hand(new List<Card>
            {
                new Card(Suits.Clubs, Ranks.Ace),
                new Card(Suits.Hearts, Ranks.Two),
                new Card(Suits.Diamonds, Ranks.Two),
                new Card(Suits.Spades, Ranks.Six),
                new Card(Suits.Clubs, Ranks.Nine)
            });
        }
    }
}
