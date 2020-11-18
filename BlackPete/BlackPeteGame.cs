using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class BlackPeteGame<T> : CardGame
    {
        public BlackPeteGame(List<Player> players, ILogger logger) : base(players, logger)
        {
            Cards = CardFactory.Instance.CreateBlackPeteDeck<T>();
        }

        public override void EndGame()
        {
            GameLogger.LogMessage("The winner is: " + Players.First().Name + "!");
        }

        public override void Setup()
        {
            ShuffleCards(Cards);
            RemoveNonPetePlayers();
            AddCardsToPlayers();
            //for (int i = 0; i < Cards.Count; i++)
            //{
            //    GameLogger.LogMessage(Cards[i].ToString());
            //}
        }

        public override void StartGame()
        {
            PairCheckAllPlayers();

            do
            {
                //Loops through each players turn
                for (int i = 0; i < Players.Count; i++)
                {
                    BlackPetePlayer<T> otherPlayer = (BlackPetePlayer<T>)Players[i == 0 ? Players.Count - 1 : i - 1];
                    
                    //!Gets a user input between 1 and the next players hand amount
                    string choice = ((ConsoleLogger)GameLogger).GetUInput(
                        Players[i].Name + ", it is your turn" + "\n" +
                        "Choose a number between 1-" + otherPlayer.CardsInHand.Count);

                    try
                    {
                        Card stolenCard = ((BlackPetePlayer<T>)Players[i]).TakeCard(otherPlayer);
                        //Steal a card from your opponent, then check whether or not it makes a pair
                        if (!((BlackPetePlayer<T>)Players[i]).CheckForNewPair(stolenCard))
                        {
                            GameLogger.LogMessage("You Stole " + ((BlackPetePlayer<T>)Players[i]).TakeCard(otherPlayer).ToString() + " from " + otherPlayer.Name);
                        }
                        else
                        {
                            GameLogger.LogMessage("You got a pair of " + stolenCard.Name + "'s");
                        }
                    }
                    catch (Exception)
                    {
                        GameLogger.LogMessage("Something went wrong with your input, better luck next turn");
                    }

                    CheckIfPlayerDone((BlackPetePlayer<T>)Players[i]);
                    CheckIfPlayerDone(otherPlayer);
                }
            } while (Players.Count != 1);
        }

        private BlackPetePlayer<T> CheckIfPlayerDone(BlackPetePlayer<T> player)
        {
            if (player.CardsInHand.Count == 0)
            {
                return player;
            }
            return null;
        }

        /// <summary>
        /// Checks all players at the start of the game, to see if they have pairs
        /// </summary>
        private void PairCheckAllPlayers()
        {
            foreach (BlackPetePlayer<T> player in Players)
            {
                foreach (string pair in player.CheckForPair())
                {
                    GameLogger.LogMessage(pair);
                }
            }
        }

        /// <summary>
        /// Adds cards to all players in the game
        /// </summary>
        public void AddCardsToPlayers()
        {
            do
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Cards.Count != 0)
                    {
                        ((BlackPetePlayer<T>)Players[i]).CardsInHand.Add(Cards.First());
                        Cards.Remove(Cards.First());
                    }
                }

            } while (Cards.Count != 0);
        }

        /// <summary>
        /// Removes all non BlackPete objects from <paramref name="players"/>
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Returns a sorted list with only BlackPetePlayer objects</returns>
        public void RemoveNonPetePlayers()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (!Players[i].Equals(typeof(BlackPetePlayer<T>)))
                {
                    Players.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Shows the hand of <paramref name="player"/>
        /// </summary>
        /// <param name="player"></param>
        public void ShowPlayerHand(BlackPetePlayer<T> player)
        {
            foreach (string item in player.ShowPlayerCards())
            {
                GameLogger.LogMessage(item);
            }
        }
    }
}
