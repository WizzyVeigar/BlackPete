using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public abstract class CardGame<T>
    {
        private ILogger gameLogger;

        public ILogger GameLogger
        {
            get { return gameLogger; }
            set { gameLogger = value; }
        }

        private IList<T> cards;

        public IList<T> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        private IList<Player> players;

        public IList<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public abstract void Setup();
        public abstract void StartGame();
        public abstract void EndGame();

        public CardGame(IList<Player> players, ILogger logger)
        {
            Players = players;
            GameLogger = logger;
        }

        public void ShuffleCards(IList<T> cards)
        {
            cards.Shuffle();
        }
    }
}
