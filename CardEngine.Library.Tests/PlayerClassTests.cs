using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Library.Tests
{
    [TestFixture]
    class PlayerClassTests
    {
        [Test]
        public void PlayerClassTestFrameworkActive()
        {
            Assert.Pass();
        }

        [Test]
        public void CreatePlayer_ReturnsPlayer()
        {
            Assert.IsInstanceOf<Player>(new Player());
        }

        [Test]
        public void Player_AcceptsCards()
        {
            Deck deck = new Deck("standard");
            Card targetCard = deck.cards[0];
            Player player = new Player();
            player.TakeCard(deck.GiveTopCard());
            Assert.IsTrue(player.Cards.Contains(targetCard));
        }
    }
}
