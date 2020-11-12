using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class BlackPetePlayer : Player
    {
        private List<PlayingCard> cardsInHand;
        public List<PlayingCard> CardsInHand
        {
            get { return cardsInHand; }
            set { cardsInHand = value; }
        }

        public BlackPetePlayer(string name) : base(name)
        {
            //Do this somewhere else or inject with constructor
            CardsInHand = new List<PlayingCard>();
        }


        public PlayingCard TakeCard(BlackPetePlayer otherPlayer)
        {
            return null;
        }

        /// <summary>
        /// Method to check for pairs at the start of the game
        /// </summary>
        public void CheckForPair()
        {
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                for (int j = 1; j <= CardsInHand.Count; j++)
                {
                    if (CardsInHand[i].CardValue == CardsInHand[j].CardValue)
                    {
                        Announce(Name + " has a pair of " + CardsInHand[i].Name + "'s");
                        CardsInHand.RemoveAt(i);
                        CardsInHand.RemoveAt(j - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Method to check for new pair, after stealing a card
        /// </summary>
        /// <param name="takenCard">The card you took from your opponent</param>
        public void CheckForPair(PlayingCard takenCard)
        {
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                if (takenCard.CardValue == CardsInHand[i].CardValue)
                {
                    Announce(Name + " has a pair of " + CardsInHand[i].Name + "'s");
                    CardsInHand.RemoveAt(i);
                    i = CardsInHand.Count + 1;
                }
            }
        }

        public IEnumerable<string> ShowPlayerCards()
        {
            string cards = string.Empty;
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                yield return CardsInHand[i].ToString();
            }
        }

        /// <summary>
        /// Method for player to communicate something
        /// </summary>
        /// <param name="message">What the player wants to say</param>
        public void Announce(string message)
        {
            //BlackPete.Instance.Logger.LogMessage(message);
        }
    }
}
