namespace Example.DynamicProgramming;

public class MinimumNotesRequired
{

    public int MinNotesRequired(int currency)
    {
        int[] dp = new int[currency + 1];
        
        //5 30 50 

        dp[0] = 0;
        for (int i = 1; i <= currency; i++)
        {
            int answer = int.MaxValue;
            if (i < 5)
            {
                dp[i] = 0;
                continue;
            }
            answer = Math.Min(answer, dp[i - 5]);

            if (i >= 30)
            {
                answer = Math.Min(answer, dp[i - 30]);
            }
            
            if (i >= 50)
            {
                answer = Math.Min(answer, dp[i - 50]);
            }

            dp[i] = answer + 1;
        }
        return dp[currency];
    }
}