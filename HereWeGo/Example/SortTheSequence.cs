namespace Example;

public class SortTheSequence
{
    public string SortSequence(string input)
    {
        string[] allWords = input.Split(" ");

        string[] answer = new string[allWords.Length];

        foreach (string word in allWords)
        {
            //get index 
            int index = word[word.Length - 1] - '0';
            answer[index - 1] = word.Substring(0, word.Length - 1);
        }

        return string.Join( " ",answer);
    }
}