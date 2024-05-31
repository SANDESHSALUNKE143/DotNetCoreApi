namespace Example;

public class PrimeNumber
{
    public List<int> GetPrimeNumbersTill(int N)
    {
        List<int> answer = new List<int>();

        List<int> temp = new List<int>();
        temp.Add(-1);
        temp.Add(-1);
        for (int i = 2; i <= N; i++)
        {
            temp.Add(i); 
        }

        for (int i = 2; i < temp.Count; i++)
        {
            if (temp[i] != i)
            {
                continue;
            }

            for (int j = 2*i; j <= N; j += i)
            {
                temp[j] = -1;
            }
        }

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i] == i)
            {
                answer.Add(i);
            }
        }

        return answer;
    }

    public List<int> SmallestPrimeFactor(int N)
    {
        List<int> temp = new List<int>();
        temp.Add(0);
        temp.Add(1);
        for (int i = 02; i <= N; i++)
        {
            temp.Add(i);
        }

        for (int i = 2; i < temp.Count; i++)
        {
            if (temp[i] == i)
            {
                //update as prime factor

                for (int j = i*i; j < N; j +=i)
                {
                    temp[j] = i;
                }
            }
        }

        return temp;
    }
}