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

        public Deck(string options)
        {
            switch (options)
            {
                case "standard":
                    cards = new List<Card>();
                    string[] suits = new string[4] { "Clubs", "Hearts", "Spades", "Diamonds" };
                    foreach (string suit in suits)
                    {
                        for (int val = 1; val <= 13; val++)
                        {
                            cards.Add(new Card(Convert.ToString(val), suit));
                        }
                    }
                    break;
            }

        }
    }
}
