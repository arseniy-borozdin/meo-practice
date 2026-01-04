using System;
using System.Collections.Generic;

namespace SpaceInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Исправление 1: Переделал наименование переменной с name на researchersName, добавил проверку на значение null
            Console.Write("Напишите имя исследователя: ");
            string researchersName = Console.ReadLine();
            if (string.IsNullOrEmpty(researchersName))
            {
                researchersName = "Неизвестный исследователь";
            }
            // Исправление 2: Добавил проверку на правильность ввода и диапазон от 3 до 15
            int n = 3;
            Console.Write("Напишите количество ресурсов(от 3 до 15): ");
            if (!(int.TryParse(Console.ReadLine(), out n) && n >= 3 && n <= 15))
            {
                Console.WriteLine("Ошибка! Введено неверное значение. Количество ресурсов автоматически определено как 3");
                n = 3;
            }

            // Исправление 3: Исправил фиксированный массив на динамичный список
            List<int> resources = new List<int>();

            // Исправление 4: Исправил выход за границы списка, добавил проверку диапазона
            Console.WriteLine("Введите коды ресурсов:");
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Введите {i + 1} код(от 1 до 100): ");
                    if (int.TryParse(Console.ReadLine(), out int tempResources) && tempResources >= 1 && tempResources <= 100)
                    {
                        resources.Add(tempResources);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неправильное значение! Введите еще раз");
                    }
                }
            }

            // Исправление 5: Поменял логику алгоритма на правильную, с resources.Count, j-- и RemoveAt(j) вместо установки значения на 0
            for (int i = 0; i < resources.Count; i++)
            {
                for (int j = i + 1; j < resources.Count; j++)
                {
                    if (resources[i] == resources[j])
                    {
                        resources.RemoveAt(j);
                        j--;
                    }
                }
            }

            // Вычисление суммы чётных
            // Поменял n на resources.Count
            int sumEven = 0;
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i] % 2 == 0)
                {
                    sumEven += resources[i];
                }
            }

            // Исправление 6: Поменял n на resources.Count, вместо проверки первого элемента добавил Contains
            string status;
            if (resources.Contains(42) && sumEven > 200)
            {
                status = "Полный инвентарь";
            }
            else if (resources.Count < 5)
            {
                status = "Минимальный инвентарь";
            }
            else
            {
                status = "Стандартный инвентарь";
            }

            // Вывод
            Console.WriteLine("Исследователь: " + researchersName);
            Console.Write("Коды ресурсов: ");
            for (int i = 0; i < resources.Count; i++)
            {
                Console.Write(resources[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Сумма чётных кодов: " + sumEven);
            Console.WriteLine("Статус: " + status);
            Console.ReadKey();
        }
    }
}