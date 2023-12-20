using System;
using System.Collections.Generic;

namespace character
{
    class Player
    {
        private string name;
        private bool lager;
        private double hp;
        private int hpMax;
        private int atk;
        private int x, y;
        public void Start()
        {
            InfoIn();
        }   /*Публичный метод для вызова приватного метода*/
        private void InfoIn()
        {
            string input;    /*Переменная для ввода*/
            bool error = false;   /*Переменная для прекращения циклов с ошибкой*/
            do
            {
                Console.WriteLine("СОЗДАНИЕ ПЕРСОНАЖА");
                Console.Write("Введите имя персонажа: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    error = true;
                    Console.Write("\nОШИБКА!!! Имя не должно содержать пробелов или пустоту\nНажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                }
                else
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[i] == ' ')
                        {
                            error = true;
                            Console.Write("\nОШИБКА!!! Имя не должно содержать пробелов или пустоту\nНажмите Enter и попробуйте ещё раз . . . ");
                            do
                            {
                                //Nothing
                            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            error = false;
                        }
                    }
                }
            } while (error == true);    /*Ввод имени персонажа*/
            do
            {
                Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");   /*Синий - false, красный - true*/
                input = Console.ReadLine();
                if (input == "1")
                {
                    lager = false;
                }
                else if (input == "2")
                {
                    lager = true;
                }
                else
                {
                    Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Console.WriteLine("СОЗДАНИЕ ПЕРСОНАЖА");
                    Console.WriteLine($"Введите имя персонажа: {name}");
                }
            } while (input != "1" && input != "2");    /*Выбор лагеря*/
            do
            {
                Console.Write("\nВведите кол-во здоровья (от 20 до 50): ");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out hpMax) == false)
                {
                    Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Console.WriteLine("СОЗДАНИЕ ПЕРСОНАЖА");
                    Console.WriteLine($"Введите имя персонажа: {name}");
                    Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");
                    if (lager == false)
                    {
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
                else
                {
                    hp = hpMax;
                }
            } while (Int32.TryParse(input, out hpMax) == false);    /*Ввод HP персонажа*/
            do
            {
                do
                {
                    Console.Write("Введите координаты (от 0 до 10)\nX: ");
                    input = Console.ReadLine();
                    if (Int32.TryParse(input, out x) == false)
                    {
                        Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                        do
                        {
                            //Nothing
                        } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                        Console.Clear();
                        Console.WriteLine("СОЗДАНИЕ ПЕРСОНАЖА");
                        Console.WriteLine($"Введите имя персонажа: {name}");
                        Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");
                        if (lager == false)
                        {
                            Console.WriteLine(1);
                        }
                        else
                        {
                            Console.WriteLine(2);
                        }
                        Console.WriteLine($"\nВведите кол-во здоровья (от 20 до 50): {hp}");
                    }
                } while (Int32.TryParse(input, out x) == false);
                Console.Write("Y: ");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out y) == false)
                {
                    Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Console.WriteLine("СОЗДАНИЕ ПЕРСОНАЖА");
                    Console.WriteLine($"Введите имя персонажа: {name}");
                    Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");
                    if (lager == false)
                    {
                        Console.WriteLine(1);
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                    Console.WriteLine($"\nВведите кол-во здоровья (от 20 до 50): {hp}");
                }
            } while (Int32.TryParse(input, out y) == false);    /*Ввод координат*/
        }
        public void InfoOut()
        {
            Console.WriteLine($"Имя: {name}");
            if (lager == false)
            {
                Console.WriteLine("Лагерь: Синий");
            }
            else
            {
                Console.WriteLine("Лагерь: Красный");
            }
            Console.WriteLine($"Жизни: {hp}/{hpMax}");
            Console.WriteLine($"Координаты: {x}; {y}");
        }
  
        public string InfoName()
        {
            return name;
        }
        public void Game(List<Player> players, List<Player> deadPlayers)
        {
            Console.WriteLine("ИНФОРМАЦИЯ О ПЕРСОНАЖЕ");
            InfoOut();
            Console.WriteLine();
            LocationCheck(players, deadPlayers);
            if (hp > 0)
            {
                MapChoice(players, deadPlayers);
            }
            players.RemoveAll(player => player.hp <= 0);
        }
        private void MapChoice(List<Player> players, List<Player> deadPlayers)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Двигаться по оси X");
            Console.WriteLine("2. Двигаться по оси Y");
            Console.WriteLine("3. Подлечиться");
            Console.WriteLine("4. Вылечиться полностью");
            Console.WriteLine("5. Сменить лагерь");
            Console.WriteLine("Enter. Меню");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    MoveX();
                    Console.Write("\nНажмите Enter, чтобы продолжить . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Game(players, deadPlayers);
                    break;
                case "2":
                    MoveY();
                    Console.Write("\nНажмите Enter, чтобы продолжить . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Game(players, deadPlayers);
                    break;
                case "3":
                    Heal();
                    Console.Write("\nНажмите Enter, чтобы продолжить . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Game(players, deadPlayers);
                    break;
                case "4":
                    FullHeal();
                    Console.Write("\nНажмите Enter, чтобы продолжить . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Game(players, deadPlayers);
                    break;
                case "5":
                    ChangeLager();
                    Console.Write("\nНажмите Enter, чтобы продолжить . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Game(players, deadPlayers);
                    break;
                case "":
                    Console.Clear();
                    break;
                default:
                    Console.Write("ОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
                    Game(players, deadPlayers);
                    break;
            }
        }
        private void MoveX()
        {
            string input;
            Console.WriteLine("(Положительное число - вправо,  отрицательное - влево)\nВведите, какое расстояние хотите пройти: ");
            input = Console.ReadLine();
            if (Int32.TryParse(input, out int move) == true)
            {
                if (x + move <= 10 || x + move >= 0)
                {
                    x += move;
                    Console.WriteLine($"\nГотово! Ваши текущие координаты: {x}; {y}");
                }
                else
                {
                    Console.Write("\nОШИБКА!!! Нельзя выходить за пределы карты\nПопробуйте ещё раз . . . ");
                    MoveX();
                }
            }
            else
            {
                Console.Write("\nОШИБКА!!! Попробуйте ещё раз . . . ");
                MoveX();
            }
        }
        private void MoveY()
        {
            string input;
            Console.WriteLine("(Положительное число - вверх,  отрицательное - вниз)\nВведите, какое расстояние хотите пройти: ");
            input = Console.ReadLine();
            if (Int32.TryParse(input, out int move) == true)
            {
                if (y + move <= 10 || y + move >= 0)
                {
                    y += move;
                    Console.WriteLine($"\nГотово! Ваши текущие координаты: {x}; {y}");
                }
                else
                {
                    Console.Write("\nОШИБКА!!! Нельзя выходить за пределы карты\nПопробуйте ещё раз . . . ");
                    MoveX();
                }
            }
            else
            {
                Console.Write("\nОШИБКА!!! Попробуйте ещё раз . . . ");
                MoveX();
            }
        }
        private void Heal()
        {
            if (hp == hpMax)
            {
                Console.WriteLine("Ваше здоровье уже на максимуме :)");
            }
            else
            {
                hp += 4;
                if (hp < hpMax)
                    Console.WriteLine("Вы вылечились на 4 HP");
                else
                {
                    Console.WriteLine("Вы полностью вылечились!");
                    hp = hpMax;
                }
            }
        }
        private void FullHeal()
        {
            if (hp == hpMax)
            {
                Console.WriteLine("Ваше здоровье уже на максимуме :)");
            }
            else
            {
                hp = hpMax;
                Console.WriteLine("Вы полностью вылечились!");
            }
        }
        private void ChangeLager()
        {
            string input;
            Console.WriteLine("Вы точно хотите поменять лагерь?\n1. Да      2. Нет");
            input = Console.ReadLine();
            if (input == "1")
            {
                if (lager == false)
                {
                    lager = true;
                }
                else
                {
                    lager = false;
                }
                Console.WriteLine("Вы успешно сменили лагерь");
            }
            else if (input == "2")
            {
                Console.WriteLine("Ваш лагерь остался прежним");
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз . . .");
                ChangeLager();
            }
        }
        private void LocationCheck(List<Player> players, List<Player> deadPlayers)
        {
            int enemies = 0;
            int friends = 1;
            foreach (Player player in players)
            {
                if (name != player.name && x == player.x && y == player.y)
                {
                    Console.WriteLine("Вы встретили персонажа:");
                    player.InfoOut();
                    Console.WriteLine();
                    if (lager != player.lager)
                    {
                        enemies++;
                    }
                    else
                    {
                        friends++;
                    }
                }
            }
            if (enemies > 0)
            {
                Console.Write("ВЫ ВСТРЕТИЛИ ВРАГА! Чтобы начать битву, нажмите Enter . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                Console.Clear();
                Battle(players, enemies, friends, deadPlayers);
            }
        }
        private void Battle(List<Player> players, int enemies, int friends, List<Player> deadPlayers)
        {
            Console.WriteLine("БИТВА\n");
            Random random = new Random();
            double hpEnemy = 0;
            foreach (Player player in players)
            {
                if (x == player.x && y == player.y)
                {
                    player.atk = random.Next(3, 7);
                }
            }
            do
            {
                foreach (Player player in players)
                {
                    if (x == player.x && y == player.y && player.lager != lager)
                    {
                        hpEnemy += player.hp;
                    }
                }
                InfoBattle(players);
                hpEnemy = BattleChoice(players, enemies, friends, hpEnemy);
                EnemyAttack(players, friends);
            } while (hp > 0 && hpEnemy > 0);
            foreach (Player player in players)
            {
                if (player.hp <= 0)
                {
                    deadPlayers.Add(player);
                }
            }
            if (hp > 0)
            {
                Console.WriteLine("ВЫ ПОБЕДИЛИ!!!\n");
            }
            else
            {
                Console.WriteLine("ВЫ ПРОИГРАЛИ\n");
                Console.WriteLine("Вы будете возвращены в меню для выбора другого персонажа");
                Console.Write("Чтобы продолжить, нажмите Enter . . . ");
                do
                {
                    //Nothing
                } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                Console.Clear();
            }
        }
        private void InfoBattle(List<Player> players)
        {
            Console.WriteLine("ВАША КОМАНДА");
            Console.WriteLine($"Вы\nHP: {hp}/{hpMax}\nАТК: {atk}");
            foreach (Player player in players)
            {
                if (player.hp < 0)
                {
                    player.hp = 0;
                }
                if (name != player.name && x == player.x && y == player.y && player.lager == lager)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{player.name}\nHP: {player.hp}/{player.hpMax}\nАТК: {player.atk}");
                }
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("ВРАГИ");
            foreach (Player player in players)
            {
                if (name != player.name && x == player.x && y == player.y && player.lager != lager)
                {
                    Console.WriteLine($"{player.name}\nHP: {player.hp}/{player.hpMax}\nАТК: {player.atk}");
                    Console.WriteLine();
                }
            }
        }
        private double BattleChoice(List<Player> players, int enemies, int friends, double hpEnemy)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Ударить    2. Подлечиться");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input == "1")
            {
                hpEnemy = Attack(players, enemies, hpEnemy);
            }
            else if (input == "2")
            {
                Heal();
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз . . .\n");
                BattleChoice(players, enemies, friends, hpEnemy);
            }
            return hpEnemy;
        }
        private double Attack(List<Player> players, int enemies, double hpEnemy)
        {
            double atkAll = 0;
            foreach (Player player in players)
            {
                if (x == player.x && y == player.y && lager == player.lager && player.hp > 0)
                {
                    atkAll += player.atk;
                }
            }
            Console.WriteLine($"Вы нанесли {atkAll} урона");
            atkAll = Math.Round(atkAll / enemies, 2);
            foreach (Player player in players)
            {
                if (x == player.x && y == player.y && lager != player.lager && player.hp > 0)
                {
                    player.hp -= atkAll;
                    hpEnemy -= atkAll;
                }
            }
            return hpEnemy;
        }
        private void EnemyAttack(List<Player> players, int friends)
        {
            double atkAll = 0;
            foreach (Player player in players)
            {
                if (x == player.x && y == player.y && lager != player.lager && player.hp > 0)
                {
                    atkAll += player.atk;
                }
            }
            Console.WriteLine($"Вашей команде нанесли {atkAll} урона\n");
            atkAll = Math.Round(atkAll / friends, 2);
            foreach (Player player in players)
            {
                if (x == player.x && y == player.y && lager == player.lager && player.hp > 0)
                {
                    player.hp -= atkAll;
                }
            }
        }
    }
}