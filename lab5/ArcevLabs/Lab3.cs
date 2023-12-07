using System;
using System.IO;
using System.Text;

namespace ArcevLabs
{
    public class Lab3
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
                string[] inputLines = File.ReadAllLines(inputFile);

                int n = int.Parse(inputLines[0]);

                int[,] graph = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] rowValues = inputLines[i + 1].Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        graph[i, j] = int.Parse(rowValues[j]);
                    }
                }

                bool hasNegativeCycle = HasNegativeCycle(graph, n);

                // Виводимо результат у консоль з красивим форматуванням
                result.AppendLine($"Граф має від'ємний цикл: {(hasNegativeCycle ? "YES" : "NO")}");

                // Записуємо результат у файл
                File.WriteAllText(outputFile, hasNegativeCycle ? "YES" : "NO");
            }
            catch (Exception ex)
            {
                result.AppendLine($"Сталася помилка: {ex.Message}");
            }

            return result.ToString();
        }

        static bool HasNegativeCycle(int[,] graph, int n)
        {
            int[] distances = new int[n];
            Array.Fill(distances, int.MaxValue);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, j] != 100000)
                    {
                        if (distances[i] == int.MaxValue)
                            distances[i] = 0;

                        if (distances[i] + graph[i, j] < distances[j])
                        {
                            distances[j] = distances[i] + graph[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, j] != 100000)
                    {
                        if (distances[i] + graph[i, j] < distances[j])
                        {
                            return true; // Виявлено від'ємний цикл
                        }
                    }
                }
            }

            return false;
        }
    }
}

