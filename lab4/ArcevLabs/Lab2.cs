using System;
using System.IO;

class Program
{
    static void Main()
    {
       
        string input = File.ReadAllText("INPUT.TXT");
        int N = int.Parse(input);

        
        int result = CountWays(N);
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }

    static int CountWays(int N)
    {
        
        int[] ways = new int[N + 1];

        
        ways[0] = 1;

        
        for (int i = 1; i <= N; i++)
        {
            ways[i] = ways[i - 1]; 

            if (i >= 2)
            {
                ways[i] += ways[i - 2]; 
            }
        }

        return ways[N];
    }
}
