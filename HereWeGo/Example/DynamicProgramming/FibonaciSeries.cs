namespace Example.DynamicProgramming;

public class FibonaciSeries
{
    public int GetFinbonacciIterative(int n)
    {

        int[] set = new int[n];

        set[0] = 0;
        set[1] = 1;

        for (int i = 2; i < n; i++)
        {
            set[i] = set[i - 1] + set[i - 2];
        }

        return set[n-1];

    }
}