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
            Player player1 = new Player();
            Player player2 = new Player();

            deck.shuffle();
            player1.TakeCard(deck.GiveTopCard());
            player2.TakeCard(deck.GiveTopCard());

            Console.WriteLine("Player 1: " + player1.Cards[0].String_Value + " of " + player1.Cards[0].Suit);
            Console.WriteLine("Player 2: " + player2.Cards[0].String_Value + " of " + player2.Cards[0].Suit);

            if (player1.Cards[0].Integer_Value > player2.Cards[0].Integer_Value)
            {
                Console.WriteLine("Player 1 Wins!");
            }
            else if (player1.Cards[0].Integer_Value < player2.Cards[0].Integer_Value)
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else
            {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }
    }
}
