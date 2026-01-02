using System;

namespace SpaceSensor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализируем переменные
            string analystName;
            int n;
            int[] radiation;
            long sum;
            int minValue;
            int minIndex;
            string planetStatus = "";
            // Вызываем методы
            InputAnalystName(out analystName);
            InputSizeArray(out n);
            radiation = InputValuesArray(n);
            CalculatingSum(radiation, out sum);
            SearchMinValue(radiation, out minValue, out minIndex);
            CalculationPlanetStatus(sum, minValue, out planetStatus);
            PrintAllInfo(analystName, radiation, sum, minValue, minIndex, planetStatus);
            Console.ReadLine();
        }
        // Записываем в переменную имя аналитика
        static void InputAnalystName(out string analystName)
        {
            Console.Write("Введите имя аналитика: ");
            analystName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(analystName))
            {
                analystName = "Неизвестный аналитик";
            }
        }
        // Записываем в переменную размер массива
        static void InputSizeArray(out int n)
        {
            Console.Write("Введите размер массива(от 3 до 20): ");
            if (!(int.TryParse(Console.ReadLine(), out n) && n >= 3 && n <= 20))
            {
                Console.WriteLine("Ошибка! Введенно неверное значение. Размер массива автоматически определен как 3");
                n = 3;
            }
        }
        // Заполняем массив элементами
        static int[] InputValuesArray(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Введите {i + 1} элемент массива: ");
                    if (int.TryParse(Console.ReadLine(), out array[i]) && array[i] >= 0 && array[i] <= 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверное значение!");
                    }
                }
            }
            return array;
        }
        // Вычисляем сумму
        static void CalculatingSum(int[] radiation, out long sum)
        {
            sum = 0;
            for (int i = 0; i < radiation.Length; i++)
            {
                sum = sum + radiation[i];
            }
        }
        // Ищем минимальный уровень радиации и его индекс в массиве
        static void SearchMinValue(int[] radiation, out int minValue, out int minIndex)
        {
            minValue = radiation[0];
            minIndex = 0;
            for (int i = 1; i < radiation.Length; i++)
            {
                if (radiation[i] < minValue)
                {
                    minValue = radiation[i];
                    minIndex = i;
                }
            }
        }
        // Вычисляем статус планеты
        static void CalculationPlanetStatus(long sum, int minValue, out string planetStatus)
        {
            if (minValue < 200 && sum < 5000)
            {
                planetStatus = "Безопасная зона";
            }
            else if (minValue < 500 && sum < 7000)
            {
                planetStatus = "Нестабильная зона";
            }
            else
            {
                planetStatus = "Опасная зона";
            }
        }
        // Выводим всю информацию
        static void PrintAllInfo(string analystName, int[] radiation, long sum, int minValue, int minIndex, string planetStatus)
        {
            Console.WriteLine($"Имя аналитика: {analystName}");
            Console.WriteLine("Радиация на планете: ");
            foreach (int rad in radiation)
            {
                Console.Write(rad + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сумма всей радиации: {sum}");
            Console.WriteLine($"Минимальное значение радиации на планете: {minValue}, под индексом {minIndex}");
            Console.WriteLine($"Статус планеты: {planetStatus}");
        }
    }
}