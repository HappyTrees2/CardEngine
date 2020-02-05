using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Library.Tests
{
    [TestFixture]
    class DeckClassTests
    {
        [Test]
        public void DeckClassTestFrameworkActive()
        {
            Assert.Pass();
        }

        [Test]
        public void DeckConstructorStandard_ReturnsDeck()
        {
            Deck deck = new Deck("standard");
            Assert.IsInstanceOf<Deck>(deck);
            Assert.IsTrue(deck.cards.Count == 52);

            string[] suits = new string[4] { "Clubs", "Hearts", "Spades", "Diamonds" };
            foreach (string suit in suits)
            {
                for (int val = 1; val <= 13; val++)
                {
                    //Documentation for how to use the Contains() method:
                    //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=netframework-4.8
                    Assert.IsTrue(deck.cards.Contains(new Card(Convert.ToString(val), suit)));
                }
            }
        }

        [Test]
        public void DeckDeepCopy_ReturnsCopy()
        {
            Deck deck = new Deck("standard");
            Deck deepcopyDeck = (Deck)deck.DeepCopy();  //https://www.geeksforgeeks.org/shallow-copy-and-deep-copy-in-c-sharp/
            for (int i = 0; i < deck.cards.Count; i++)
            {
                Assert.IsTrue(deepcopyDeck.cards.ElementAt(i).Equals(deck.cards.ElementAt(i)));
            }
        }

        [Test]
        public void DeckShuffle_ShufflesDeck()
        {
            Deck deck = new Deck("standard");
            Deck deepcopyDeck = (Deck)deck.DeepCopy();
            deck.shuffle();
            for (int i = 0; i < deck.cards.Count; i++)
            {
                Assert.IsTrue(deepcopyDeck.cards.Contains(deck.cards.ElementAt(i)));
                Assert.IsFalse(deepcopyDeck.cards[i].Equals(deck.cards[i]));
            }
        }
    }
}
