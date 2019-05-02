namespace _03._Number_Wars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstPlayerCards = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var secondPlayerCards = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            var playerOneDeck = new Queue<string>();
            var playerTwoDeck = new Queue<string>();

            for (int firstDeckCount = 0; firstDeckCount < firstPlayerCards.Length; firstDeckCount++)
            {
                playerOneDeck.Enqueue(firstPlayerCards[firstDeckCount]);
            }

            for (int secondDeckCount = 0; secondDeckCount < secondPlayerCards.Length; secondDeckCount++)
            {
                playerTwoDeck.Enqueue(secondPlayerCards[secondDeckCount]);
            }

            var alphabet = "abcdefghijklmnopqrstuvwxyz";

            long count = 0L;
            var endMessage = string.Empty;

            while (playerOneDeck.Any() && playerTwoDeck.Any() && count <= 1000000)
            {
                var playerOneCard = playerOneDeck.Dequeue();
                var playerTwoCard = playerTwoDeck.Dequeue();

                var firstPlayerCardStrength = long.Parse(playerOneCard.Substring(0, playerOneCard.Length - 1));
                var secondPlayerCardStrength = long.Parse(playerTwoCard.Substring(0, playerTwoCard.Length - 1));

                if (firstPlayerCardStrength > secondPlayerCardStrength)
                {
                    playerOneDeck.Enqueue(playerOneCard);
                    playerOneDeck.Enqueue(playerTwoCard);
                }
                else if (firstPlayerCardStrength < secondPlayerCardStrength)
                {
                    playerTwoDeck.Enqueue(playerTwoCard);
                    playerTwoDeck.Enqueue(playerOneCard);
                }
                else
                {
                    var playerOneSum = 0L;
                    var playerTwoSum = 0L;
                    var playedCards = new List<Card>();
                    var isGameOver = false;

                    while (isGameOver)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!playerOneDeck.Any())
                            {
                                endMessage = "";
                                isGameOver = true;
                            }
                            var currentCardPlayerOne = playerOneDeck.Dequeue();
                            playerOneSum += alphabet.IndexOf(currentCardPlayerOne.Substring(currentCardPlayerOne.Length - 1)) + 1;

                            if (!playerTwoDeck.Any())
                            {
                                endMessage = "";
                                isGameOver = true;
                            }
                            var currentCardPlayerTwo = playerTwoDeck.Dequeue();
                            playerTwoSum += alphabet.IndexOf(currentCardPlayerOne.Substring(currentCardPlayerOne.Length - 1)) + 1;

                            var cardOne = new Card(
                                long.Parse(currentCardPlayerOne.Substring(0, currentCardPlayerOne.Length - 1)),
                                char.Parse(currentCardPlayerOne.Substring(currentCardPlayerOne.Length - 1)));

                            playedCards.Add(cardOne);

                            var cardTwo = new Card(
                                long.Parse(currentCardPlayerTwo.Substring(0, currentCardPlayerOne.Length - 1)),
                                char.Parse(currentCardPlayerTwo.Substring(currentCardPlayerOne.Length - 1)));

                            playedCards.Add(cardTwo);
                        }

                        if (playerOneSum > playerTwoSum)
                        {
                            isGameOver = true;
                        }
                        else if (playerOneSum < playerTwoSum)
                        {

                        }
                    }
                }
            }
        }

        public class Card
        {
            private long cardNumber;
            private char cardLetter;
            
            public Card() { }

            public Card(long cardNumber, char cardLetter)
            {
                this.CardLetter = cardLetter;
                this.CardNumber = cardNumber;
            }

            public long CardNumber
            {
                get
                {
                    return this.cardNumber;
                }
                set
                {
                    this.cardNumber = value;
                }
            }

            public char CardLetter
            {
                get
                {
                    return this.cardLetter;
                }
                set
                {
                    this.cardLetter = value;
                }
            }
        }
    }
}
