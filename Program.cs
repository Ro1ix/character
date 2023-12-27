using System;
using System.Collections.Generic;

namespace character
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Игровой персонаж";
            Console.SetWindowSize(150, 50);
            List<Player> players = new List<Player>();
            List<Player> deadPlayers = new List<Player>();
            int choice = 0;
            Menu(choice, players, deadPlayers);
        }
        static void Menu(int choice, List<Player> players, List<Player> deadPlayers)
        {
            Console.WriteLine("\n             МЕНЮ            ");
            Console.WriteLine("-----------------------------");
            if (choice == 0)
            {
                Console.WriteLine("|   > Создать персонажа <   |");
            }
            else
            {
                Console.WriteLine("|     Создать персонажа     |");
            }
            Console.WriteLine("-----------------------------");
            if (players.Count > 0)
            {
                if (choice == 1)
                {
                    Console.WriteLine("|  > Управлять персонажем < |");
                }
                else
                {
                    Console.WriteLine("|    Управлять персонажем   |");
                }
                Console.WriteLine("-----------------------------");
                if (choice == 2)
                {
                    Console.WriteLine("|         > Выход <         |");
                }
                else
                {
                    Console.WriteLine("|           Выход           |");
                }
                Console.WriteLine("-----------------------------");
            }
            else
            {
                
                if (choice == 1)
                {
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  > Управлять персонажем < ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");
                }
                else
                {
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("    Управлять персонажем   ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------");
                if (choice == 2)
                {
                    Console.WriteLine("|         > Выход <         |");
                }
                else
                {
                    Console.WriteLine("|           Выход           |");
                }
                Console.WriteLine("-----------------------------");
            }
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    if (choice < 2)
                    {
                        choice++;
                    }
                    Console.Clear();
                    Menu(choice, players, deadPlayers);
                    break;
                case ConsoleKey.UpArrow:
                    if (choice > 0)
                    {
                        choice--;
                    }
                    Console.Clear();
                    Menu(choice, players, deadPlayers);
                    break;
                case ConsoleKey.Enter:
                    break;
                default:
                    Console.Clear();
                    Menu(choice, players, deadPlayers);
                    break;
            }
            switch (choice)
            {
                case 0:
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
                    Menu(choice, players, deadPlayers);
                    break;
                case 1:
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
                        string input = Console.ReadLine();
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
                            goto case 1;
                        }
                        Console.Clear();
                        players[count].Game(players, deadPlayers);
                        Menu(choice, players, deadPlayers);
                    }
                    else
                    {
                        Console.Write("\nОШИБКА!!! Персонажа сначала надо создать\nНажмите Enter и попробуйте ещё раз . . . ");
                        do
                        {
                            //Nothing
                        } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                        Console.Clear();
                        Menu(choice, players, deadPlayers);
                    }
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
