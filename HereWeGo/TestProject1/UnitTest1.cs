using HereWeGo;

namespace TestProject1;

public class UnitTest1
{
    // [Theory]
    // [MemberData( nameof(TestData) )]
    public void ValidateSequenceTest(List<int> array1, List<int> sequence, bool outPut)
    {
        ValidateSubSequence validateSubSequence = new ValidateSubSequence();

        bool result =validateSubSequence.ValidateSequense(array1, sequence);
        
        Assert.Equal(outPut, result);
    }
    
    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(5, true)]
    [InlineData(25, false)]
    [InlineData(4, false)]
    [InlineData(100, false)]
    public void PrimeNumberCheckTest(int number, bool eresult)
    {

        MyAllProgramms primeNumberCheck = new MyAllProgramms();
        bool result =primeNumberCheck.NumberIsPrime(number);
        
        Assert.Equal(result, eresult);
    }
    
    [Theory]
    [InlineData("abc","c")]
    [InlineData("abbbcc","bbb")]
    [InlineData("abbaccc","ccc")]
    [InlineData("abbacc","cc")]
    [InlineData("aabbbbaaccdabcaaaaaaaab","aaaaaaaa")]
    public void LongestPatternTest(string number, string expectedResult)
    {

        LongestPattern  longestPattern = new LongestPattern();
        string result =longestPattern.GetLongestPattern(number);
        
        Assert.Equal(result, expectedResult);
    }
    
    [Theory]
    [MemberData( nameof(UniqueNumberData) )]
    public void UniqueNumberTest(string numbers, int answer)
    {
        List<int> number = numbers.Split(',').Select(int.Parse).ToList();

        Simple simple = new Simple();
        int ans  = simple.FindUniqueNumber(number);
        
        Assert.Equal(answer, ans);
    }
    
    
    
    
   
    
    
    
}



