using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace character
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Игровой персонаж";
            List<Player> players = new List<Player>();
            players[0].Start();
        }
    }
}