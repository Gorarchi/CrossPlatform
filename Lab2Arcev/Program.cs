using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение входных данных из файла INPUT.TXT
        string input = File.ReadAllText("INPUT.TXT");
        int N = int.Parse(input);

        // Вычисление количества способов и запись результата в файл OUTPUT.TXT
        int result = CountWays(N);
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }

    static int CountWays(int N)
    {
        // Используем массив для хранения количества способов для каждого размера шоколадки
        int[] ways = new int[N + 1];

        // Изначально у нас есть один способ для N = 0 (пустая шоколадка)
        ways[0] = 1;

        // Динамическое программирование: вычисляем количество способов для каждого размера шоколадки
        for (int i = 1; i <= N; i++)
        {
            ways[i] = ways[i - 1]; // Добавляем способы, полученные из предыдущего размера

            if (i >= 2)
            {
                ways[i] += ways[i - 2]; // Добавляем способы, полученные из размера на 2 плитки меньше
            }
        }

        return ways[N];
    }
}
