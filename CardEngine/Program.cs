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
            Deck deepcopyDeck = (Deck)deck.DeepCopy();

            deck.shuffle();

            for (int i = 0; i < deck.cards.Count; i++)
            {
                Console.Write(deepcopyDeck.cards.ElementAt(i).String_Value + " of " + deepcopyDeck.cards.ElementAt(i).Suit + "\t|\t");
                Console.WriteLine(deck.cards.ElementAt(i).String_Value + " of " + deck.cards.ElementAt(i).Suit);
            }

            Console.ReadLine();
        }
    }
}
