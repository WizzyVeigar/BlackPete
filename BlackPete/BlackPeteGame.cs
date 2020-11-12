using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class BlackPeteGame : CardGame<PlayingCard>
    {
        public BlackPeteGame(List<Player> players, ILogger logger) : base(players, logger)
        {
            Cards = CardFactory.Instance.CreateBlackPeteDeck();
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


            foreach (BlackPetePlayer item in Players)
            {
                Console.WriteLine(item.CardsInHand.Count);
            }
            //for (int i = 0; i < Cards.Count; i++)
            //{
            //    GameLogger.LogMessage(Cards[i].ToString());
            //}
        }

        public override void StartGame()
        {
            do
            {
                //Loops through each players turn
                for (int i = 0; i < Players.Count; i++)
                {
                    //Gets a user input between 1 and the next players hand amount
                    string choice = ((ConsoleLogger)GameLogger).GetUInput(
                        Players[i].Name + ", it is your turn" + "\n" +
                        "Choose a number between 1-" + ((BlackPetePlayer)Players[i == 0 ? Players.Count - 1 : i + 1]).CardsInHand.Count);
                }



            } while (Players.Count != 1);
        }

        public void AddCardsToPlayers()
        {
            do
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Cards.Count != 0)
                    {
                        ((BlackPetePlayer)Players[i]).CardsInHand.Add(Cards.First());
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
                if (Players[i] is BlackPetePlayer)
                {

                }
                else
                {
                    Players.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Shows the hand of <paramref name="player"/>
        /// </summary>
        /// <param name="player"></param>
        public void ShowPlayerHand(BlackPetePlayer player)
        {
            foreach (string item in player.ShowPlayerCards())
            {
                GameLogger.LogMessage(item);
            }
        }
    }
}
