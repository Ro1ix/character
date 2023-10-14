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
        private int x;
        private int y;
        private bool lager;
        private int hp;
        public void Info(int xMax, int yMax)
        {
            Console.WriteLine("Введите имя персонажа:");
            name = Console.ReadLine();
            //Рандомятся координаты
            Random rand = new Random();
            x = rand.Next(1, xMax + 1);
            y = rand.Next(1, yMax + 1);
            //Цикл для того, чтобы при неправильном вводе лагеря программа не прекращалась ошибкой
            string input;
            do
            {
                Console.WriteLine("\nВыберите лагерь:\n1. Синий      2. Красный");   //Синий - false, красный - true
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        lager = false;
                        break;
                    case "2":
                        lager = true;
                        break;
                    default:
                        Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                        break;
                }
            } while (input != "1" && input != "2");
            //
            hp = 20;
        }
        public void Output()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Координаты: {x}, {y}");
            if (lager == false)
                Console.WriteLine("Лагерь: Синий");
            else
                Console.WriteLine("Имя: Красный");
            Console.WriteLine($"Жизни: {hp}");
        }
        public void Heal()
        {
            hp += 4;
            if (hp < 20)
                Console.WriteLine("Вы вылечились на 4 HP");
            else
            {
                Console.WriteLine("Вы полностью вылечились!");
                hp = 20;
            }
        }
        public void FullHeal()
        {
            hp = 20;
            Console.WriteLine("Вы полностью вылечились!");
        }
        public void ChangeLager()
        {
            string input;
            do
            {
                Console.WriteLine("Вы точно хотите поменять лагерь?\n1. Да      2. Нет");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (lager == false)
                            lager = true;
                        else
                            lager = false;
                        break;
                    case "2":
                        Console.WriteLine("Ваш лагерь остался прежним");
                        break;
                    default:
                        Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                        break;
                }
            } while (input != "1" && input != "2");
        }
    }
}
