namespace Example;

public class Factors
{
    public int GetFactorsOfNumber(int N)
    {
        int sqrt =(int) Math.Sqrt(N);
        int answer = 0;

        for (int i = 2; i <= sqrt; i++)
        {
            if (N % i == 0)
            {
                answer += 2;
            }
        }

        
        //for perfect square
        if (sqrt * sqrt == N)
        {
            answer--;
        }
        return answer;
    }
}