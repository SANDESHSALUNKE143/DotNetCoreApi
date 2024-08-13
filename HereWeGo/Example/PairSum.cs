namespace Example;

public class PairSum
{
    public int NumberOfPair(List<int> input, int sum)
    {

        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        int answer = 0;
        for (int i = 0; i < input.Count; i++)
        {
            int ele = input[i];
            int compare = sum - input[i];

            if (dictionary.ContainsKey(compare))
            {
                answer += dictionary[compare];
            }
            
            //update frequency

            if (dictionary.ContainsKey(ele))
            {
                dictionary[ele]++;
            }
            else
            {
                dictionary.Add(ele,1);
            }
        }

        return answer;
    }
    
}