namespace Example.DynamicProgramming;

public class MaximumSubSequenseSum
{
    int[] dpR;
    public int GetSum(List<int> input)
    {
        dpR = new int[input.Count];
        return MaxSum(input, input.Count-1);
    }

    private int MaxSum( List<int> A, int n)
    {
        if (n < 0)
        {
            return 0;
        }

        if (dpR[n] != 0)
        {
            return dpR[n];
        }
        
        int max1 = A[n] + MaxSum(A,n - 2);
        int max2 = 0;
        if (n >=1)
        { 
            max2 = A[n-1] + MaxSum(A, n - 3);
        }
        dpR[n]= Math.Max(max1, max2);

        return dpR[n];
    }

    private int BottomUp(List<int> A)
    {   
        int[] dp = new int[A.Count ];
        dp[0] = A[0];
        dp[1] = A[1];

        for (int i = 2; i < A.Count; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + A[i]);
        }
        return dp[A.Count-1];
    }
}