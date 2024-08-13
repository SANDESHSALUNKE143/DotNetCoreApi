namespace Example.DynamicProgramming;

public class CountOfUniquePath
{
    private int[,] dp;

    public int Answer(int n, int m)
    {
        dp = new int[n,m];
        return CountOfPath(n-1,m-1);
    }
    private int CountOfPath(int n, int m)
    {
        if (n-1 < 0)
        {
            return 0;
        }

        if (m-1 < 0)
        {
            return 0;
        }

        if (dp[n, m - 1] != 0)
        {
            return dp[n, m - 1];
        }
        
        if (dp[n - 1, m] != 0)
        {
            return dp[n - 1, m];
        }
        dp[n, m - 1] = CountOfPath(n, m - 1) ;
        dp[n - 1, m] =CountOfPath(n - 1, m);
        return dp[n, m - 1] + dp[n - 1, m];

    }
    
    

    public int BottomUp(int n, int m)
    {
        int [,] dpB =new int[n,m];
        return 0;
    }


}