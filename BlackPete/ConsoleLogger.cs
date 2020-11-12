using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Gets Input from the user
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Returns the users input</returns>
        public string GetUInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
