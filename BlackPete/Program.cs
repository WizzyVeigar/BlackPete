using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>() { 
                new BlackPetePlayer<PlayingCard>("Lars", false), new BlackPetePlayer<PlayingCard>("Thomas", true), 
                new BlackPetePlayer<PlayingCard>("Nej", true), new BlackPetePlayer<PlayingCard>("Nanna", true) 
            }; 

            CardGame blackPeteGame = new BlackPeteGame<PlayingCard>(players, new ConsoleLogger());
            
            blackPeteGame.Setup();
            blackPeteGame.StartGame();
            blackPeteGame.EndGame();

            Console.ReadKey();
        }
    }
}
