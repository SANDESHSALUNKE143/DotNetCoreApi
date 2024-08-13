namespace Example;

public class SortArrayBasedOnMagnitude
{
    public List<int> SortMeBasedOnSquare(List<int> input)
    {
        input.Sort(new Comparer());

        for (int i = 0; i < input.Count; i++)
        {
            input[i] *= input[i];
        }

        return input;
    }
}

class Comparer : IComparer<int>
{
    public int Compare(int a, int b)
    {
        if (Math.Abs(a) > Math.Abs(b))
        {
            return 1;
        }

        if (Math.Abs(a) < Math.Abs(b))
        {
           return -1;
        }

        return 0;
    }
}