using System.Text;

namespace HereWeGo;

public class LongestPattern
{
    public string GetLongestPattern(string input)
    {
        
        //abbaccc

        char maxElement = input[0];
        char currentElement = input[0];
        int maxCounter = 1;
        int currentCounter = 1;
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentElement)
            {
                currentCounter++;
            }
            else
            {
                currentCounter = 1;
                currentElement = input[i];
                
            }
            
            if (currentCounter >= maxCounter)
            {
                maxCounter = currentCounter;
                maxElement = input[i];
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < maxCounter; i++)
        {
            sb.Append(maxElement);
        }
        
        return sb.ToString();
    }
}