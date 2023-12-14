using System;
using System.Collections.Generic;

namespace character
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Игровой персонаж";
            List<Player> players = new List<Player>();
            List<Player> deadPlayers = new List<Player>();
            Menu(players, deadPlayers);
        }
        static void Menu(List<Player> players, List<Player> deadPlayers)
        {
            Console.WriteLine("МЕНЮ");
            Console.WriteLine("1. Создать персонажа");
            if (players.Count > 0)
            {
                Console.WriteLine("2. Управлять персонажем");
            }
            Console.WriteLine("Enter. Выход");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    players.Add(new Player());
                    players[players.Count - 1].Start();
                    Console.Clear();
                    Console.WriteLine("АКТИВНЫЕ ПЕРСОНАЖИ:");
                    foreach (Player player in players)
                    {
                        player.InfoOut();
                        Console.WriteLine();
                    }
                    Console.Write("Нажмите Enter, чтобы продолжить . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Menu(players, deadPlayers);
                    break;
                case "2":
                    if (players.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("ВЫБОР ПЕРСОНАЖА");
                        foreach (Player player in players)
                        {
                            player.InfoOut();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Введите имя персонажа, которым хотите управлять: ");
                        input = Console.ReadLine();
                        int countError = 0;
                        int count = 0;
                        foreach (Player player in players)
                        {
                            if (input == player.InfoName())
                            {
                                break;
                            }
                            else
                            {
                                countError++;
                            }
                            count++;
                        }
                        if (countError == players.Count)
                        {
                            Console.Write("\nОШИБКА!!! Персонажа с таким именем не существует\nНажмите Enter и попробуйте ещё раз . . . ");
                            do
                            {
                                //Nothing
                            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                            goto case "2";
                        }
                        Console.Clear();
                        players[count].Game(players, deadPlayers);
                        Menu(players, deadPlayers);
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "":
                    break;
                default:
                    Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Menu(players, deadPlayers);
                    break;
            }
        }
    }
}