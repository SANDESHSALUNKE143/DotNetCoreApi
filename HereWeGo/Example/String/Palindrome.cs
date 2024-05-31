namespace Example.String;

public class Palindrome
{
    public string LengthOfLongestPalindrome(string input)
    {
        int longestString = Int32.MinValue;
        int startIndex = 0;
        int endIndex = 0;
        for (int i = 0; i < input.Length; i++)
        {
            var (ans1, x, y) = LengthOfPalindrome(i, i, input);
            if (longestString < ans1)
            {
                startIndex = x;
                endIndex = y;
                longestString = ans1;
            }
            var (ans2, u, v) = LengthOfPalindrome(i, i+1, input);

            if (longestString < ans2)
            {
                startIndex = u;
                endIndex = v;
                longestString = ans2;
            }
            
        }
        
        

        return input.Substring(startIndex,endIndex-startIndex+1);
    }

    private (int,int,int) LengthOfPalindrome(int i, int j, string s)
    {
        int answer = 0;
        while (i >= 0  && j < s.Length)
        {
            if (s[i] == s[j])
            {
                answer = j - i + 1;
                i--;
                j++;
            }
            else
            {
                break;
            }
        }

        return (answer,i+1,j-1);
    }
}