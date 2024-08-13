using System.Text;

namespace Example;

public class MindBody
{
    public string CroppedNotificationMessage(string input, int k)
    {
        string[] numberOfWord = input.Split(" ");
        
        int[] lengthOfWords = new int [numberOfWord.Length];
        
        for (int i = 0; i < numberOfWord.Length; i++)
        {
            lengthOfWords[i] = numberOfWord[i].Length;
        }
        
        //get prefix sum

        int[] prefSum = new int[numberOfWord.Length];
        prefSum[0] = lengthOfWords[0];

        for (int i = 1; i < lengthOfWords.Length; i++)
        {
            prefSum[i] = lengthOfWords[i] + prefSum[i - 1];
        }

        int index = -1;

        for (int i = 0; i < prefSum.Length; i++)
        {
            if (i + prefSum[i] + 4 <= k)
            {
                index = i;
                continue;
            }

            break;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i <= index; i++)
        {
            sb.Append(numberOfWord[i]);
            sb.Append(" ");
        }

        if (index != prefSum.Length-1)
        {
            sb.Append("...");
        }

        
        return sb.ToString().Trim();
    }
}