using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork3
{
    class Sorting
    {
        /// <summary>
        /// Sorting from Ace to King
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public string[] AceToKingSort(string[] deck)
        {
            var result = deck.OrderByDescending(d => d.Contains("clubs"))
                             .ThenByDescending(d => d.Contains("diamonds"))
                             .ThenByDescending(d => d.Contains("hearts"))
                             .ThenByDescending(d => d.Contains("spades"))
                             .ToArray();
            return result;
        }

        /// <summary>
        /// Select cards in selected range 
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public string[] SelectFromTo(string[] deck, int from, int to)
        {
            var result = deck.Skip(from - 1)
                             .Take((to - from) + 1)
                             .ToArray();
            return result;
        }

        public string[] HeartsSort(string[] deck)
        {
            //var customOrder = new Dictionary<string, int>();
            //customOrder.Add("Ace", 1);
            //customOrder.Add("2", 2);
            //customOrder.Add("3", 3);
            //customOrder.Add("4", 4);
            //customOrder.Add("5", 5);
            //customOrder.Add("6", 6);
            //customOrder.Add("7", 7);
            //customOrder.Add("8", 8);
            //customOrder.Add("9", 9);
            //customOrder.Add("10", 10);
            //customOrder.Add("Jack", 11);
            //customOrder.Add("Queen", 12);
            //customOrder.Add("King", 13);

            //var data = new List<string> { "Ace", "10", "8", "King" };
            //var result = data.OrderBy(card => customOrder[card]);

            var result = deck.Where(card => card.Contains("hearts"))
                             .OrderByDescending(card => card.StartsWith("Ace"))
                             .ThenByDescending(card => card.StartsWith("2"))
                             .ThenByDescending(card => card.StartsWith("3"))
                             .ThenByDescending(card => card.StartsWith("4"))
                             .ThenByDescending(card => card.StartsWith("5"))
                             .ThenByDescending(card => card.StartsWith("6"))
                             .ThenByDescending(card => card.StartsWith("7"))
                             .ThenByDescending(card => card.StartsWith("8"))
                             .ThenByDescending(card => card.StartsWith("9"))
                             .ThenByDescending(card => card.StartsWith("10"))
                             .ThenByDescending(card => card.StartsWith("Jack"))
                             .ThenByDescending(card => card.StartsWith("Queen"))
                             .ThenByDescending(card => card.StartsWith("King"))
                             .ToArray();
            return result;
        }

        public string[] SpadesSort(string[] deck)
        {
            var result = deck.Where(card => card.Contains("spades"))
                             .OrderByDescending(card => card.StartsWith("2"))
                             .ThenByDescending(card => card.StartsWith("3"))
                             .ThenByDescending(card => card.StartsWith("4"))
                             .ThenByDescending(card => card.StartsWith("5"))
                             .ThenByDescending(card => card.StartsWith("6"))
                             .ThenByDescending(card => card.StartsWith("7"))
                             .ThenByDescending(card => card.StartsWith("8"))
                             .ThenByDescending(card => card.StartsWith("9"))
                             .ThenByDescending(card => card.StartsWith("10"))
                             .ThenByDescending(card => card.StartsWith("Jack"))
                             .ThenByDescending(card => card.StartsWith("Queen"))
                             .ThenByDescending(card => card.StartsWith("King"))
                             .ThenByDescending(card => card.StartsWith("Ace"))
                             .ToArray();
            return result;
        }

        public void MaxMinRank(string[] deck)
        {

        }
    }
}
