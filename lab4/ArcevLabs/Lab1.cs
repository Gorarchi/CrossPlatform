using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        
        string inputFilePath = "INPUT.TXT";
        string outputFilePath = "OUTPUT.TXT";

        
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            string[] inputLines = reader.ReadToEnd().Split('\n');
            int n = int.Parse(inputLines[0]);
            int k1 = int.Parse(inputLines[1]);
            int k2 = int.Parse(inputLines[2]);
            int s = int.Parse(inputLines[3]);
        }

        
        int[] result = Solve(n, k1, k2, s);

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.Write(result[0] + " " + result[1]);
        }
    }

    static int[] Solve(int n, int k1, int k2, int s)
    {
        
        if (k1 == k2)
        {
            return new int[] { s };
        }

       
        else if (k1 + k2 == s)
        {
            return new int[] { s / 2, s / 2 };
        }

        
        else
        {
            
            int winner = (k1 > k2) ? 1 : 2;

            return new int[] { s, 0 };
        }
    }
}
