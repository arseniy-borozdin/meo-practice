using System;

namespace SpaceInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ошибка 1: Непонятное имя переменной и отсутствие проверки на null/пустоту
            string name = Console.ReadLine();

            // Ошибка 2: Нет проверки корректности ввода n
            int n = int.Parse(Console.ReadLine());

            // Ошибка 3: Фиксированный размер массива, не зависящий от n
            int[] resources = new int[10];

            // Ошибка 4: Выход за границы массива при n > 10, отсутствие проверки диапазона значений
            Console.WriteLine("Введите коды ресурсов:");
            for (int i = 0; i < n; i++)
            {
                resources[i] = int.Parse(Console.ReadLine());
            }

            // Ошибка 5: Неправильная логика удаления дубликатов (портит массив)
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (resources[i] == resources[j])
                    {
                        resources[j] = 0; // Ошибка: Замена на 0, а не удаление
                    }
                }
            }

            // Вычисление суммы чётных
            int sumEven = 0;
            for (int i = 0; i < n; i++)
            {
                if (resources[i] % 2 == 0)
                {
                    sumEven += resources[i];
                }
            }

            // Ошибка 6: Неправильная логика статуса (игнорирует дубликаты)
            string status;
            if (resources[0] == 42 && sumEven > 200)
            {
                status = "Полный инвентарь";
            }
            else if (n < 5)
            {
                status = "Минимальный инвентарь";
            }
            else
            {
                status = "Стандартный инвентарь";
            }

            // Вывод
            Console.WriteLine("Исследователь: " + name);
            Console.Write("Коды ресурсов: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(resources[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Сумма чётных кодов: " + sumEven);
            Console.WriteLine("Статус: " + status);
        }
    }
}