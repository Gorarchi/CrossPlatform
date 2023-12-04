using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string[] lines = File.ReadAllLines("input.txt");
            int n = int.Parse(lines[0]);

            int[,] graph = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] rowValues = lines[i + 1].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    graph[i, j] = int.Parse(rowValues[j]);
                }
            }

            bool hasNegativeCycle = HasNegativeCycle(graph, n);
            string result = hasNegativeCycle ? "YES" : "NO";

            File.WriteAllText("output.txt", result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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
                        return true; // Negative cycle detected
                    }
                }
            }
        }

        return false;
    }
}
