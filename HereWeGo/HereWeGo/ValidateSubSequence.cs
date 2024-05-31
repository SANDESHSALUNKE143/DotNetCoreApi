namespace HereWeGo;

public class ValidateSubSequence
{
    public bool ValidateSequense(List<int> array, List<int> sequence)
    {
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i]==sequence[0])
            {
                sequence.RemoveAt(0);
                if (sequence.Count==0)
                {
                    return true;
                }
            }
        }

        return false;
    }
}