// See https://aka.ms/new-console-template for more information

using Example;
using Example.BinarySearch;
using Example.DynamicProgramming;
using Example.SortingAlgo;
using Example.String;

Console.WriteLine("Hello, World!");


 string LargestPalindrome(string input)
{
    string answer = string.Empty;

    for (int startIndex = 0; startIndex < input.Length; startIndex++) //N
    {
        for (int endIndex = input.Length -1 ; endIndex >= startIndex; endIndex--) //N
        {
            int leftCounter = startIndex;
            int rigthCounter = endIndex;
            bool isSubstringPalindrome = true;
            while (leftCounter < rigthCounter)
            {
                if (input[leftCounter] == input[rigthCounter])
                {
                    leftCounter++;
                    rigthCounter--;
                }
                else
                {
                    isSubstringPalindrome = false;
                    break;
                }
            }

            if (isSubstringPalindrome)
            {
                string currentAnswer = input.Substring(startIndex, (endIndex- startIndex +1));

                answer = currentAnswer.Length > answer.Length ? currentAnswer : answer;
            }

        }
        
    }

    return answer;
}

BinarySearch binarySearch = new BinarySearch();
Console.WriteLine("BinarySearch "+ binarySearch.FindElementInArray(new List<int>() {1,2,3,4,6,7,8,9,10}, 5));

Console.WriteLine("FindFirstOccurrence "+ binarySearch.FindFirstOccurrence(new List<int>() {1,2,3,4,6,6,6,6,6,6,6,7,8,9,10}, 6));
Console.WriteLine("FindFirstOccurrence "+ binarySearch.FindUniqueElement(new List<int>() {2 ,2 ,3, 3 ,5 ,3,3}));

SortBasedOnFactors sortBasedOnFactors = new SortBasedOnFactors();
Console.WriteLine("sortBasedOnFactors " + String.Join(',', sortBasedOnFactors.SortMe(new List<int>(){9,3,10,6,4})));

Factors factors = new Factors();
Console.WriteLine("Factors " + factors.GetFactorsOfNumber(33));



PairSum pairSum = new PairSum();
Console.WriteLine("PairSum " +   pairSum.NumberOfPair(new List<int>(){2,5,2,5,8,5,2,8},10));


PrimeNumber number = new PrimeNumber();
Console.WriteLine("PrimeNumber " + String.Join( ',', number.GetPrimeNumbersTill(100) ));
Console.WriteLine("PrimeNumberFactor " + String.Join( ',', number.SmallestPrimeFactor(100) ));

CountOfUniquePath countOfUniquePath = new CountOfUniquePath();
Console.WriteLine("countOfUniquePath " + countOfUniquePath.Answer(3,3));

MaximumSubSequenseSum maximumSubSequenseSum = new MaximumSubSequenseSum();
Console.WriteLine(maximumSubSequenseSum.GetSum(new List<int>(){10,20,30}));
//String
Palindrome palindrome = new Palindrome();
Console.WriteLine(palindrome.LengthOfLongestPalindrome("Java"));


FibonaciSeries fibonaciSeries = new FibonaciSeries();
Console.WriteLine(fibonaciSeries.GetFinbonacciIterative(8));


MinimumPerfectSquare minimumPerfectSquare = new MinimumPerfectSquare();
Console.WriteLine(minimumPerfectSquare.GiveMinimumPerfectSquare(4));


MinimumNotesRequired minimumNotesRequired = new MinimumNotesRequired();
Console.WriteLine(minimumNotesRequired.MinNotesRequired(50));



