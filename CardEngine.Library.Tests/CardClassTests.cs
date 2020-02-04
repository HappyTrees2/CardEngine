using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Library.Tests
{
    [TestFixture]
    public class CardClassTests
    {
        [Test]
        public void CardClassTestFrameworkActive()
        {
            Assert.Pass();
        }

        [Test]
        public void CardEngine_CreateCard_ReturnsCard()
        {
            string val = "Ace";
            string suit = "Clubs";
            Card card = new Card(val, suit);
            Assert.IsInstanceOf<Card>(card);
            Assert.AreEqual(val, card.String_Value);
            Assert.AreEqual(suit, card.Suit);
        }

        [Test]
        public void CardEngine_ClassCardGet_ReturnsValueOrFace(
            [Values("Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King")] string val
            )
        {
            string suit = "Clubs";
            Card card = new Card(val, suit);
            Assert.AreEqual(val, card.String_Value);
        }

        [TestCase("1", "Ace")]
        [TestCase("11", "Jack")]
        [TestCase("12", "Queen")]
        [TestCase("13", "King")]
        public void CardEngine_ClassCardConstructor_ConvertsToFace(string val, string expected)
        {
            string suit = "Clubs";
            Card card = new Card(val, suit);
            Assert.AreEqual(expected, card.String_Value);
        }

        [Test]
        public void CardEngine_ClassCardConstructor_DoesNotAcceptInvalidValues(
            [Values("-1", "14", "foo")] string val
            )
        {
            string suit = "Clubs";
            Assert.Throws<ArgumentException>(delegate { new Card(val, suit); } );
        }

        [Test]
        public void CardEngine_ClassCardConstructor_DoesNotAcceptInvalidSuits(
            [Values("-1", "14", "foo")] string suit
            )
        {
            string val = "1";
            Assert.Throws<ArgumentException>(delegate { new Card(val, suit); });
        }

        [TestCase("Ace", 1)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        [TestCase("5", 5)]
        [TestCase("6", 6)]
        [TestCase("7", 7)]
        [TestCase("8", 8)]
        [TestCase("9", 9)]
        [TestCase("10", 10)]
        [TestCase("Jack", 11)]
        [TestCase("11", 11)]
        [TestCase("Queen", 12)]
        [TestCase("12", 12)]
        [TestCase("King", 13)]
        [TestCase("13", 13)]
        public void CardEngine_ClassCardGetIntVal_ReturnsIntegerValueOfCard(string val, int expected)
        {
            string suit = "Clubs";
            Card card = new Card(val, suit);
            Assert.AreEqual(expected, card.Integer_Value);
        }
    }
}
