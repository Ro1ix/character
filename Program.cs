using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Игровой персонаж";
            int xMax = 5;
            int yMax = 5;
            Player[] players = new Player[10];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player();
            }
            players[0].Info(xMax, yMax);
            Console.WriteLine();
            players[0].Output();
        }
    }
}
