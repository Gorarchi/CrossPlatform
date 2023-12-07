using System;
using System.IO;
using System.Text;

namespace ArcevLabs
{
    public class Lab1
    {
        public static string Execute(string inputFile, string outputFile)
        {
            StringBuilder result = new StringBuilder();

            try
            {
                if (!File.Exists(inputFile))
                {
                    result.AppendLine($"���� '{inputFile}' �� ��������");
                    return result.ToString();
                }

                // ������ ����� ��� � �����
                string[] inputLines = File.ReadAllLines(inputFile);

                string[] inputValues = inputLines[0].Split(' ');
                int N = int.Parse(inputValues[0]);
                int K1 = int.Parse(inputValues[1]);
                int K2 = int.Parse(inputValues[2]);
                int S = int.Parse(inputValues[3]);

                // ���������� ����� ���
                if (N < 1 || N > 50 || K1 <= 0 || K1 >= N || K2 <= 0 || K2 >= N || S <= 1 || S > 100)
                {
                    result.AppendLine("��������� ����� ���");
                    return result.ToString();
                }

                // �������� ����� ��� � �������
                result.AppendLine("����� ���:");
                result.AppendLine($"N = {N}");
                result.AppendLine($"K1 = {K1}");
                result.AppendLine($"K2 = {K2}");
                result.AppendLine($"S = {S}");

                result.Append("\n-----------------------------------\n");

                // ���������� �������� �����
                int coinsForPetya = CalculateCoins(N, K1, K2, S, result);
                int coinsForVasya = S - coinsForPetya;

                // ������ ��������� � ����
                result.AppendLine($"\n���������: {coinsForPetya} {coinsForVasya}");
                File.WriteAllText(outputFile, $"{coinsForPetya} {coinsForVasya}");
            }
            catch (Exception ex)
            {
                result.AppendLine($"������� �������: {ex.Message}");
            }

            return result.ToString();
        }

        static int CalculateCoins(int N, int K1, int K2, int S, StringBuilder result)
        {
            int[][] a = new int[N + 1][];
            for (int i = 0; i <= N; i++)
            {
                a[i] = new int[N + 1];
            }

            a[K1][K2] = 1 << 100;

            for (int i1 = K1; i1 < N; i1++)
            {
                for (int i2 = K2; i2 < N; i2++)
                {
                    a[i1 + 1][i2] += a[i1][i2] / 2;
                    a[i1][i2 + 1] += a[i1][i2] / 2;
                }
            }

            int sum1 = 0;
            for (int i2 = K2; i2 < N; i2++)
            {
                sum1 += a[N][i2];
            }

            int res1 = (sum1 * S) >> 100;

            result.AppendLine($"ʳ������ ����� ��� ���: {res1}");

            return res1;
        }

    }
}