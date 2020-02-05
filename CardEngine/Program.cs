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

            Console.WriteLine("1) Start Game");
            Console.WriteLine("q) Quit");

            if (Console.ReadLine() == "1")
            {
                do
                {
                    gameLoop(deck, player1, player2);
                    if (deck.cards.Count < 2)
                    {
                        Console.WriteLine("The deck is out of cards! Press enter to end game.");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Write("Again? (y/n): ");
                    }
                } while (Console.ReadLine().ToLower() == "y");
            }
        }

        static void gameLoop(Deck deck, Player player1, Player player2)
        {
            deck.shuffle();
            player1.TakeCard(deck.GiveTopCard());
            player2.TakeCard(deck.GiveTopCard());

            Console.WriteLine("Player 1: " + player1.Cards[0].String_Value + " of " + player1.Cards[0].Suit);
            Console.WriteLine("Player 2: " + player2.Cards[0].String_Value + " of " + player2.Cards[0].Suit);

            if (player1.Cards[0].Integer_Value > player2.Cards[0].Integer_Value)
            {
                Console.WriteLine("PLAYER 1 WINS!");
            }
            else if (player1.Cards[0].Integer_Value < player2.Cards[0].Integer_Value)
            {
                Console.WriteLine("PLAYER 2 WINS!");
            }
            else
            {
                Console.WriteLine("DRAW");
            }
            player1.TrashHand();
            player2.TrashHand();
            Console.WriteLine();
        }
    }
}
