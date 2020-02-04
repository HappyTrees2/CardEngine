using CardEngine.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck("standard");

            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(deck.cards.ElementAt(i).String_Value + " of " + deck.cards.ElementAt(i).Suit);
            }
        }
    }
}
