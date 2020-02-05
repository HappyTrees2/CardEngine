using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Library
{
    public class Card : IEquatable<Card>
    {
        private string string_value;
        private string suit;

        public string String_Value
        {
            get => string_value;
            set
            {
                if (value.ToLower() == "1" || value.ToLower() == "ace")
                {
                    string_value = "Ace";
                    Integer_Value = 1;
                }
                else if (value.ToLower() == "11" || value.ToLower() == "jack")
                {
                    string_value = "Jack";
                    Integer_Value = 11;
                }
                else if (value.ToLower() == "12" || value.ToLower() == "queen")
                {
                    string_value = "Queen";
                    Integer_Value = 12;
                }
                else if (value.ToLower() == "13" || value.ToLower() == "king")
                {
                    string_value = "King";
                    Integer_Value = 13;
                }
                else
                {
                    try
                    {
                        int checkVal = Convert.ToInt32(value);
                        if (1 < checkVal && checkVal < 11)
                        {
                            string_value = value;
                            Integer_Value = Convert.ToInt32(value);
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }

        public string Suit
        {
            get => suit;
            set
            {
                if (value.ToLower() == "clubs" || 
                    value.ToLower() == "diamonds" ||
                    value.ToLower() == "hearts" ||
                    value.ToLower() == "spades"
                    )
                {
                    //Capitalization reformatting trick: 
                    //https://www.educative.io/edpresso/how-to-capitalize-the-first-letter-of-a-string-in-c-sharp
                    suit = value.ToUpper()[0] + value.ToLower().Substring(1);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int Integer_Value { get; private set; }

        public Card(string val, string suit)
        {
            String_Value = val;
            Suit = suit;
        }

        public bool Equals(Card other)
        {
            if (this.String_Value == other.String_Value && this.Suit == other.Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Deck
    {
        public readonly List<Card> cards;

        public Deck DeepCopy()
        {
            Deck deepcopyDeck = new Deck("empty");
            foreach (Card originalCard in this.cards)
            {
                deepcopyDeck.cards.Add(new Card(originalCard.String_Value, originalCard.Suit));
            }
            return deepcopyDeck;
        }

        public void shuffle()
        {
            Random random = new Random();   //https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
            int alreadyShuffledIndex = 0;
            for (int i = 0; i < this.cards.Count - 1; i++)
            {
                int swapIndex = random.Next(alreadyShuffledIndex + 1, this.cards.Count - 1);
                Card swapCard = this.cards.ElementAt(i);
                this.cards[i] = this.cards.ElementAt(swapIndex);
                this.cards[swapIndex] = swapCard;
                ++alreadyShuffledIndex;
            }
        }

        public Deck(string options)
        {
            cards = new List<Card>();
            string[] suits = new string[4] { "Clubs", "Hearts", "Spades", "Diamonds" };
            switch (options)
            {
                case "standard":
                    foreach (string suit in suits)
                    {
                        for (int val = 1; val <= 13; val++)
                        {
                            cards.Add(new Card(Convert.ToString(val), suit));
                        }
                    }
                    break;
                case "aces":
                    foreach (string suit in suits)
                    {
                        cards.Add(new Card("1", suit));
                    }
                    break;
                default:
                    break;

            }

        }
    }
}
