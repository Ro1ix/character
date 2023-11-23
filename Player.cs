using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character
{
    class Player
    {
        private string name;
        private bool lager;
        private int hp, hpMax;
        private int x, y;
        public void Start()
        {
            InfoIn();
        }
        private void InfoIn()
        {
            string input = "";    /*Переменная для ввода*/
            bool error = false;   /*Переменная для прекращения циклов с ошибкой*/
            do
            {
                Console.WriteLine("СОЗДАНИЕ ПЕРСОНАЖА");
                Console.Write("Введите имя персонажа: ");
                name = Console.ReadLine();
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] == ' ' || name == "")
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
                        error = false;
                }
            } while (error == true);    /*Ввод имени персонажа*/
            do
            {
                Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");   /*Синий - false, красный - true*/
                input = Console.ReadLine();
                if (input == "1")
                    lager = false;
                else if (input == "2")
                    lager = true;
                else
                {
                    Console.Write("\nОШИБКА!!! Нажмите Enter и попробуйте ещё раз . . . ");
                    do
                    {
                        //Nothing
                    } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                    Console.Clear();
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
                    Console.WriteLine($"Введите имя персонажа: {name}");
                    Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");
                    if (lager == false)
                        Console.WriteLine(1);
                    else
                        Console.WriteLine(2);
                }
                else
                    hp = hpMax;
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
                        Console.WriteLine($"Введите имя персонажа: {name}");
                        Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");
                        if (lager == false)
                            Console.WriteLine(1);
                        else
                            Console.WriteLine(2);
                        Console.Write($"\nВведите кол-во здоровья (от 20 до 50): {hp}");
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
                    Console.WriteLine($"Введите имя персонажа: {name}");
                    Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");
                    if (lager == false)
                        Console.WriteLine(1);
                    else
                        Console.WriteLine(2);
                    Console.Write($"\nВведите кол-во здоровья (от 20 до 50): {hp}");
                    Console.Write($"Введите координаты (от 0 до 10)\nX: {x}");
                }
            } while (Int32.TryParse(input, out y) == false);    /*Ввод координат*/
        }
        public void InfoOut()
        {
            Console.WriteLine($"Имя: {name}");
            if (lager == false)
                Console.WriteLine("Лагерь: Синий");
            else
                Console.WriteLine("Лагерь: Красный");
            Console.WriteLine($"Жизни: {hp}");
            Console.WriteLine($"Координаты: {x}; {y}");
        }
        public string InfoName()
        {
            return name;
        }
        public void GameStart()
        {
            Game();
        }
        private void Game()
        {
            Console.WriteLine("ИНФОРМАЦИЯ О ПЕРСОНАЖЕ");
            InfoOut();
            Console.WriteLine();
            MapChoise();
        }
        private void MapChoise()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Двигаться по оси X");
            Console.WriteLine("2. Двигаться по оси Y");
            Console.WriteLine("3. Подлечиться");
            Console.WriteLine("4. Вылечиться полностью");
            Console.WriteLine("5. Сменить лагерь");
        }
        private void moveX()
        {
            string input;
            int move = 0;
            Console.WriteLine("\n(Положительное число ― вправо,  отрицательное - влево)\nВведите, какое расстояние хотите пройти: ");
            input = Console.ReadLine();
            if (Int32.TryParse(input, out move) == true)
            {
                if ((x += move) <= 10 || (x += move) >= 0)
                {
                    x += move;
                    Console.WriteLine($"\nГотово! Ваши текущие координаты: {x}; {y}");
                }
                else
                {
                    Console.Write("\nОШИБКА!!! Нельзя выходить за пределы карты\nПопробуйте ещё раз . . . ");
                    moveX();
                }
            }
            else
            {
                Console.Write("\nОШИБКА!!! Попробуйте ещё раз . . . ");
                moveX();
            }
        }
        private void moveY()
        {
            string input;
            int move = 0;
            Console.WriteLine("\n(Положительное число ― вверх,  отрицательное - вниз)\nВведите, какое расстояние хотите пройти: ");
            input = Console.ReadLine();
            if (Int32.TryParse(input, out move) == true)
            {
                if ((y += move) <= 10 || (y += move) >= 0)
                {
                    y += move;
                    Console.WriteLine($"\nГотово! Ваши текущие координаты: {x}; {y}");
                }
                else
                {
                    Console.Write("\nОШИБКА!!! Нельзя выходить за пределы карты\nПопробуйте ещё раз . . . ");
                    moveX();
                }
            }
            else
            {
                Console.Write("\nОШИБКА!!! Попробуйте ещё раз . . . ");
                moveX();
            }
        }
        private void Heal()
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
        public void FullHeal()
        {
            hp = hpMax;
            Console.WriteLine("Вы полностью вылечились!");
        }
        public void ChangeLager()
        {
            string input;
            Console.WriteLine("Вы точно хотите поменять лагерь?\n1. Да      2. Нет");
            input = Console.ReadLine();
            if (input == "1")
            {
                if (lager == false)
                    lager = true;
                else
                    lager = false;
            }
            else if (input == "2")
                Console.WriteLine("Ваш лагерь остался прежним");
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз . . .");
                ChangeLager();
            }
        }
    }
}