namespace Example;

public class SquareArrayElements
{
    public List<int> SquareArray(List<int> input)
    {
        List<int> answer = new List<int>();
        int i = 0;
        int j = input.Count - 1;

        // -4 2 5
        while (i <= j)
        {
            if (Math.Abs(input[i]) <= Math.Abs(input[j]))
            {
                answer.Add(input[j] * input[j]);
                j--;
            }
            else if (Math.Abs(input[i]) > Math.Abs(input[j]))
            {
                answer.Add(input[i] * input[i]);
                i++;
            }
            
        }
         answer.Reverse();
         return answer;
    }
}