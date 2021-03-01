using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork3
{
    class DeckOfCards
    {
        string[] ranks = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        string[] suits = new string[] { "clubs", "diamonds", "hearts", "spades" };
        public string[] deck = new string[52];

        public DeckOfCards()
        {
            int cardNum = 0;

            for (int i = 0; i < ranks.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    deck[cardNum] = ranks[i] + suits[j];
                    cardNum++;
                }
            }

            //var deck2 = ranks.Zip(suits, (x, y) => x + y);
        }

        /// <summary>
        /// Show selected cards
        /// </summary>
        /// <param name="deck"></param>
        public static void ShowCards(string[] deck)
        {
            var cardsList = deck.Select(d => d.Replace("clubs", "♣"))
                                .Select(d => d.Replace("diamonds", "♦"))
                                .Select(d => d.Replace("hearts", "♥"))
                                .Select(d => d.Replace("spades", "♠"))
                                .Aggregate((x, y) => x + ", " + y);

            Console.WriteLine(cardsList);
        }

        public static void ShowCards(string card)
        {
            string[] deck = new string[] { card };

            var selectedCard = deck.Select(d => d.Replace("clubs", "♣"))
                                   .Select(d => d.Replace("diamonds", "♦"))
                                   .Select(d => d.Replace("hearts", "♥"))
                                   .Select(d => d.Replace("spades", "♠"))
                                   .Aggregate((x, y) => x + ", " + y);

            Console.WriteLine(selectedCard);
        }
 
    }
}
