namespace Example.DynamicProgramming;

public class MinimumPerfectSquare
{
    public int GiveMinimumPerfectSquare(int number)
    {
        int answer = 0;
        int[] dp = new int[number+1];
        dp[0] = 0;
        for (int i = 1; i <= number; i++)
        {
            int minAnswer = int.MaxValue;
            
            for (int j = 01; j*j <= i; j++)
            {
                minAnswer = Math.Min(minAnswer, dp[i - (j * j)]);
            }

            dp[i] = minAnswer + 1;
        }

        return dp[number];
    }
    
}