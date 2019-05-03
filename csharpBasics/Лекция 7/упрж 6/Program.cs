using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace упрж_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1points = 0;
            int player2points = 0;

            //Докато има карти 
            while(true)
            {                    //Използване на Break
                if (player1points >= 48 || player2points >= 48)
                {
                    break;
                }

                player1points += 12;
                player2points += 3;
            }

        }
    }
}
