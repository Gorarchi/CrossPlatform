using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        // Входные данные
        string inputFilePath = "INPUT.TXT";
        string outputFilePath = "OUTPUT.TXT";

        // Чтение входных данных
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            string[] inputLines = reader.ReadToEnd().Split('\n');
            int n = int.Parse(inputLines[0]);
            int k1 = int.Parse(inputLines[1]);
            int k2 = int.Parse(inputLines[2]);
            int s = int.Parse(inputLines[3]);
        }

        // Вычисление количества монет, которые должны получить Петя и Вася
        int[] result = Solve(n, k1, k2, s);

        // Запись выходных данных
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.Write(result[0] + " " + result[1]);
        }
    }

    static int[] Solve(int n, int k1, int k2, int s)
    {
        // Если Петя и Вася набрали одинаковое количество очков, то они должны получить все монеты
        if (k1 == k2)
        {
            return new int[] { s };
        }

        // Если сумма очков Пети и Васи равна количеству монет, то они должны получить одинаковое количество монет
        else if (k1 + k2 == s)
        {
            return new int[] { s / 2, s / 2 };
        }

        // В противном случае, один из игроков должен получить все монеты
        else
        {
            // Определяем, кто из игроков должен получить все монеты
            int winner = (k1 > k2) ? 1 : 2;

            // Возвращаем массив из двух элементов, первый элемент которого равен количеству монет, которое получит победитель, а второй элемент равен 0
            return new int[] { s, 0 };
        }
    }
}
