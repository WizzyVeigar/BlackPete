using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }
    public class PlayingCard : Card
    {
        private Suit cardSuit;

        public Suit CardSuit
        {
            get { return cardSuit; }
            set { cardSuit = value; }
        }

        public PlayingCard(Suit cSuit,string name) : base(name)
        {
            CardSuit = cSuit;
        }
    }
}
