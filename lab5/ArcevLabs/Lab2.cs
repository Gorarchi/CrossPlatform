using System;
using System.IO;
using System.Text;

namespace ArcevLabs
{
    public class Lab2
    {
        public static string Execute(string inputFile, string outputFile)
        {
            StringBuilder result = new StringBuilder();

            try
            {
                if (!File.Exists(inputFile))
                {
                    result.AppendLine($"Файл '{inputFile}' не знайдено");
                    return result.ToString();
                }

                // Читаємо вхідні дані з файлу
                string input = File.ReadAllText(inputFile).Trim();
                int N = int.Parse(input);

                // Викликаємо функцію для обрахунку шляхів
                int resultValue = CountWays(N);

                // Виводимо результат у консоль з текстом
                result.AppendLine($"Кількість можливих способів поділу шоколадки розміром 3×{N} плиток: {resultValue}");

                // Записуємо лише число у файл
                File.WriteAllText(outputFile, resultValue.ToString());
            }
            catch (Exception ex)
            {
                result.AppendLine($"Сталася помилка: {ex.Message}");
            }

            return result.ToString();
        }

        static int CountWays(int N)
        {
            // Масив для зберігання кількості шляхів
            int[] count = new int[1 + N];
            int[] countPlus = new int[1 + N];

            // Початкова умова
            count[0] = 1;
            countPlus[0] = 1;

            // Обчислення кількості шляхів
            for (int i = 2; i <= N; i += 2)
            {
                count[i] = count[i - 2] + 2 * countPlus[i - 2];
                countPlus[i] = count[i] + countPlus[i - 2];
            }

            return count[N];
        }
    }
}
