using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public static class Extensions
    {
        static Random rnd = new Random();


        /// <summary>
        /// Fisher–Yates shuffle
        /// </summary>
        /// <param name="deck"></param>
        public static string[] Shuffle(this string[] deck)
        {
            for (int i = deck.Length - 1; i >= 1; i--)
            {
                int rand = rnd.Next(i + 1);
                var temp = deck[rand];
                deck[rand] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

        public static bool TryParseCard(string card, out string result)
        {
            string[] ranks = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string[] suits = new string[] { "clubs", "diamonds", "hearts", "spades" };
            string rank = string.Empty;
            string suit = string.Empty;

            try
            {
                rank = card.Split(' ')[0];
                suit = card.Split(' ')[1];
            }
            catch
            { }
            
            bool currentRank = ranks.Any(r => r.Contains(rank));
            bool currentSuit = suits.Any(r => r.Contains(suit));

            if (currentRank && currentSuit)
            {
                result = rank + suit;
                return true;
            }

            result = null;
            return false;
        }

        public static void ListCardsToParse(string[] list)
        {
            string output = string.Empty;
            var result = list.Select(x => (TryParseCard(x, out output)))
                             .Select(x => output)
                             .Where(x => !string.IsNullOrEmpty(x))
                             .Distinct()
                             .Aggregate((x, y) => x + ", " + y);

            DeckOfCards.ShowCards(result);
        }
    }
}
