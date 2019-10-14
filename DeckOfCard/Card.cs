// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Card.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.DeckOfCard
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Card is class for suffling and ditributing b/w users
    /// </summary>
    class Card
    {
        private string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        private string[] rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        private string[] cards = new string[52];
        private string[,] playersandcards = new string[4,9];
        private QueueLinkedList<string> player;
        private QueueLinkedList<QueueLinkedList<string>> allplayer = new QueueLinkedList<QueueLinkedList<string>>();
        int pos = 0;
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        public Card()
        {
            for (int i = 0; i < rank.Length; i++)
            {
                for (int j = 0; j < suit.Length; j++)
                {
                    cards[pos++] = suit[j] + "-" + rank[i];
                }
            }
        }
        /// <summary>
        /// Shuffles the cards.
        /// </summary>
        public void shuffleCards()
        {
            Random rnd = new Random();
            for (int i = cards.Length - 1; i > 0; i--)
            {
                int index = rnd.Next(i+1);
                // Simple swap
                string a = cards[index];
                cards[index] = cards[i];
                cards[i] = a;
            }
        }
        /// <summary>
        /// Distributes the cards.
        /// </summary>
        public void distributeCards()
        {
            int row = 0;
            int col = 0;
            //   int i = 0;
            foreach (string card in cards)
            {
                if (col < 9)
                {
                    ////Putting the value in @D array
                    playersandcards[row++, col] = card;
                    if (row == 4)
                    {
                        row = 0;
                        col++;
                    }
                }
                else
                {
                    break;
                }
            }
            sortByRank();
            createPlayerObject();
            displayCards();
        }
        /// <summary>
        /// Sorts the by rank.
        /// </summary>
        public void sortByRank()
        {
            for (int i = 0; i < playersandcards.GetLength(0); i++)
            {
                int k = 0;
                string[] ar = new string[9];
                ////Storing one roww element and sort by the rank
               for (int j = 0; j < 9; j++)
                { 
                        ar[k++] = playersandcards[i, j];
                }
               
                Utility.mergeSort(ar, 0, 8, rank);
            }
        }
        /// <summary>
        /// Creates the player object.
        /// </summary>
        public void createPlayerObject()
        {
            for (int i = 0; i < playersandcards.GetLength(0); i++)
            {
                int k = 0;
                string[] ar = new string[9];
                for (int j = 0; j < 9; j++)
                {
                    ar[k++] = playersandcards[i, j];
                }
                player = new QueueLinkedList<string>();
                foreach(var card in ar)
                {
                    player.enQueue(card);
                }
                allplayer.enQueue(player);
            }
        }
        /// <summary>
        /// Displays the cards.
        /// </summary>
        private void displayCards()
        {
            int index = 1;
            while (!allplayer.isEmpty())
            {
                player = allplayer.deQueue();
                Console.WriteLine("player-" + index + " cards : ");
                while (!player.isEmpty())
                {
                    Console.WriteLine(player.deQueue() + ", ");
                }
                index++;
                Console.WriteLine();
            }
        }

    }
}