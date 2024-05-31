namespace HereWeGo;

public class MyAllProgramms
{
    public  bool NumberIsPrime(int number)
    {
        if (number == 2)
        {
            return true;
        }
        if (number == 1)
        {
            return false;
        }

        //get factors count
        var factorsCount = 0;
        for (int i = 1; i <= Math.Sqrt(number); i++)
        {
            if (number % i != 0) continue;
            
            if (i ==number / i )
            {
                factorsCount ++;
            }
            else
            {
                factorsCount += 2;
            }
        }

        return factorsCount <= 2;
    }

    public int FindPerfectNumber(int A)
    {
        //find factors till number by 2
        //get sum of all factors
        int sum=0;
        for(int i=1; i <= A/2; i++)
        {
            if(A % i == 0)
            {
                sum += i;
            }
        }

        if(sum == A)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}