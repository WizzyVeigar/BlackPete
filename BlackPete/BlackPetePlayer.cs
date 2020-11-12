﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class BlackPetePlayer<T> : Player
    {
        //This is not good
        private static Random rng = new Random();

        private List<Card> cardsInHand;
        public List<Card> CardsInHand
        {
            get { return cardsInHand; }
            set { cardsInHand = value; }
        }

        public BlackPetePlayer(string name) : base(name)
        {
            //Do this somewhere else or inject with constructor
            CardsInHand = new List<Card>();
        }

        /// <summary>
        /// Steals a card from <paramref name="otherPlayer"/>
        /// </summary>
        /// <param name="otherPlayer"></param>
        /// <returns></returns>
        public Card TakeCard(BlackPetePlayer<T> otherPlayer)
        {
            Card stolenCard = otherPlayer.CardsInHand[rng.Next(otherPlayer.CardsInHand.Count)];
            CardsInHand.Add(stolenCard);
            otherPlayer.CardsInHand.Remove(stolenCard);
            return stolenCard;
        }

        /// <summary>
        /// Method to check for pairs at the start of the game
        /// </summary>
        public IEnumerable<string> CheckForPair()
        {
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                for (int j = i + 1; j < CardsInHand.Count; j++)
                {
                    if (typeof(T).Equals(typeof(PlayingCard)))
                    {
                        if (CardsInHand[i].CardValue == CardsInHand[j].CardValue)
                        {
                            string temp = CardsInHand[i].Name;
                            CardsInHand.RemoveAt(i);
                            CardsInHand.RemoveAt(j - 1);
                            yield return Name + " has a pair of " + temp + "'s";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to check for new pair, after stealing a card
        /// </summary>
        /// <param name="takenCard">The card you took from your opponent</param>
        public bool CheckForNewPair(Card takenCard)
        {
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                if (takenCard.CardValue == CardsInHand[i].CardValue)
                {
                    CardsInHand.RemoveAt(i);
                    i = CardsInHand.Count + 1;
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<string> ShowPlayerCards()
        {
            string cards = string.Empty;
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                yield return CardsInHand[i].ToString();
            }
        }
    }
}
