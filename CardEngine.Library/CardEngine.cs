using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Library
{
    public class Card
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
                else if (value.ToLower() == "10" || value.ToLower() == "jack")
                {
                    string_value = "Jack";
                    Integer_Value = 10;
                }
                else if (value.ToLower() == "11" || value.ToLower() == "queen")
                {
                    string_value = "Queen";
                    Integer_Value = 11;
                }
                else if (value.ToLower() == "12" || value.ToLower() == "king")
                {
                    string_value = "King";
                    Integer_Value = 12;
                }
                else
                {
                    try
                    {
                        int checkVal = Convert.ToInt32(value);
                        if (1 < checkVal && checkVal < 10)
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
                    suit = value;
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
    }

    public class CardEngine
    {
        public static Card CreateCard(string val, string suit)
        {
            return new Card(val, suit);
        }
    }
}
