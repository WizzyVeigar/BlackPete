using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public class CardFactory
    {
        private static CardFactory instance;
        public static CardFactory Instace
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardFactory();
                }
                return instance;
            }
        }
    }
}
