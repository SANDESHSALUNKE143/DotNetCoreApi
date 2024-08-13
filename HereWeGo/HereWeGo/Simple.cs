namespace HereWeGo;

public class Simple
{
    public int FindUniqueNumber(List<int> numberList)
    {
        int answer = 0;
        for (int i = 0; i < numberList.Count; i++)
        {
            answer ^= numberList[i];
        }

        return answer;
    }
}