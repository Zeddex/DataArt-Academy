using System;
using System.Linq;
using System.Collections.Generic;

namespace HomeWork3
{

    #region HomeWork3

    // Все упражнения, перечисленные ниже, связаны с обработкой коллекций состоящих из игральных карт.
    // 
    // За исключением отдельно оговоренных случаев, в решении запрещается использование конструкций 
    // циклов (foreach, while, do) и их аналогов (метод .ForEach(...) и рекурсивные методы). 
    // Операции над списками должны производиться при помощи LINQ, допускается использование 
    // как синтаксиса LINQ, так и методов-расширений.
    //
    // Часть 1. Сгенерировать список содержащий все карты в следующем порядке: 
    // сначала все карты начиная с туза, двойки и так до короля одной масти, 
    // затем карты следующей масти в том же порядке рангов и т.д. Вывести на экран полученный список.
    // Перетасовать (shuffle) полученную колоду карт в случайном порядке. 
    // Реализовать для этого отдельный метод-расширение. В этом методе разрешается использование циклов. 
    // На отдельных строках вывести первые и вторые шесть карт из перетасованной колоды.
    //
    // Часть 2. Реализуйте метод TryParse для преобразования строки в карту, предоставляющий интерфейс, 
    // аналогичный методам int.TryParse() и DateTime.TryParse(), а именно:
    // Метод принимает на вход строку первым параметром;
    // Если строка является обозначением карты в формате<обозначение ранга><обозначение масти> (см.примеры выше), 
    // то метод возвращает true и помещает соответствующий экземпляр карты в out-параметр;
    // В противном случае метод возвращает false, а значение out-параметра считается неопределенным.
    // Создайте список строк, часть из которых является обозначением карт.Преобразуйте те строки, 
    // которые являются корректными обозначениями карт, в экземпляры карт (а остальные строки проигнорируйте).
    // Выведите на экран получившийся список карт, исключая повторения.
    //
    // Часть 3. Дан непустой список карт. Выведите на экран:
    // Карты с мастью червы, в порядке возрастания ранга, считая туз наименьшим рангом
    // (т.е.ранги от низшего к высшему: туз, 2, 3, ..., валет, дама, король);
    // Карты с мастью пики, в порядке возрастания ранга, считая туз наивысшим рангом
    // (т.е.ранги от низшего к высшему: 2, 3, ..., валет, дама, король, туз).
    //
    // Часть 4. Во многих пасьянсах серией карт называется такой набор карт, 
    // в котором карты расположены по возрастанию ранга на 1 и с чередованием красных и черных мастей. 
    // Например, последовательность 10♥, J♠, Q♦ является серией. Пусть имеются две, возможно пустые, серии карт. 
    // Реализуйте метод, возвращающий объединенную коллекцию карт, если карты первой серии, 
    // с добавленными к ним картами второй серии, вместе также образуют серию. 
    // Т.е. (9♣, 10♥), (J♠, Q♦) --> (9♣, 10♥, J♠, Q♦).
    // Продемонстрируйте корректность работы метода на нескольких примерах.
    // В рамках этой задачи, будем считать, что туз -- это самый низкий ранг.
    //
    // Часть 5*. Реализуйте метод, который по заданному набору карт, определяет является ли этот набор серией. 
    //
    // Часть 6. Имеется коллекция карт. 
    // Для каждой масти, из представленных в списке, выведите наименьший и наибольший ранг карт соответствующей масти. 
    // (В этой задаче, туз -- это самый низкий ранг.). 
    // Допускается вывод финального результата с использованием цикла foreach.
    //
    // Часть 7*. Минимальный и максимальный ранг в рамках одной масти 
    // должны быть найдены за один просмотр коллекции, вместо двух.

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeckOfCards cardDeck = new DeckOfCards();
            Sorting sorting = new Sorting();
            string[] deck = cardDeck.deck;

            Console.WriteLine("New deck:");
            DeckOfCards.ShowCards(deck);

            // Part 1
            Console.WriteLine("\nAce to King sorted by suit deck:");
            string[] deckAceToKing = sorting.AceToKingSort(deck);
            DeckOfCards.ShowCards(deckAceToKing);

            Console.WriteLine("\nDeck after shuffle:");
            DeckOfCards.ShowCards(deckAceToKing.Shuffle());

            Console.WriteLine("\nFirst 6 cards after shuffle:");
            string[] first6Cards = sorting.SelectFromTo(deckAceToKing, 1, 6);
            DeckOfCards.ShowCards(first6Cards);

            Console.WriteLine("\nSecond 6 cards after shuffle:");
            string[] second6Cards = sorting.SelectFromTo(deckAceToKing, 7, 12);
            DeckOfCards.ShowCards(second6Cards);

            // Part 2
            string[] parseCards = new string[] { "Ace spades", "2 diamonds", "123 abc", "Queen hearts", "bitcoin", "Ace spades" };
            string parseCard = "Ace spades";
            string cardResult = string.Empty;
            Extensions.TryParseCard(parseCard, out cardResult);

            Console.WriteLine("\nParsed card:");
            DeckOfCards.ShowCards(cardResult);

            Console.WriteLine("\nParsed cards:");
            Extensions.ListCardsToParse(parseCards);

            // Part 3
            string[] shuffDeck = cardDeck.deck.Shuffle();
            Console.WriteLine("\nNew shuffled deck:");
            DeckOfCards.ShowCards(shuffDeck);

            Console.WriteLine("\nHearts sorted deck:");
            DeckOfCards.ShowCards(sorting.HeartsSort(shuffDeck));

            Console.WriteLine("\nSpades sorted deck:");
            DeckOfCards.ShowCards(sorting.SpadesSort(shuffDeck));

            // Part 4


            Console.ReadKey();

        }
    }
}
