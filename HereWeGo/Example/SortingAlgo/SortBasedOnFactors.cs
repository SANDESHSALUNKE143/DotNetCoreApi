namespace Example.SortingAlgo;

public class SortBasedOnFactors
{
    public List<int> SortMe(List<int> input)
    {
        input.Sort(new CustomSort());

        return input;
    }
}

class CustomSort : IComparer<int>
{
    public int Compare(int x, int y)
    {
        int factorA = new Factors().GetFactorsOfNumber(x);
        int factorB = new Factors().GetFactorsOfNumber(y);

        if (factorA < factorB)
        {
            return 1;
        }

        if (factorA > factorB)
        {
            return -1;
        }

        if (factorA == factorB)
        {
            //check magnitude
            if (x < y)
            {
                return 1;
            }

            if (x > y)
            {
                return -1;
            }

            return 0;
        }

        return 0;
    }
}