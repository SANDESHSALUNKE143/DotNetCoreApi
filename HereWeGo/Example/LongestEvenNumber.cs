namespace Example;

public class LongestEvenNumber
{
    public string LongestEventNumber(string s)
    {
        int max = Int32.MinValue;

        for (int i = s.Length-1; i  >= 0; i--)
        {
            if ((s[i] - '0') % 2 == 0)
            {
                return s.Substring(0, i+1);
            }
        }

        return max.ToString();
    }
}