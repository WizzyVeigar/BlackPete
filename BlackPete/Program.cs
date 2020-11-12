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
            List<Player> players = new List<Player>() { new BlackPetePlayer("Lars"), new BlackPetePlayer("Thomas"), new BlackPetePlayer("Why"), new BlackPetePlayer("Nanna") }; 

            BlackPeteGame blackPeteGame = new BlackPeteGame(players, new ConsoleLogger());
            
            blackPeteGame.Setup();
            blackPeteGame.StartGame();
            blackPeteGame.EndGame();

            Console.ReadKey();
        }
    }
}
