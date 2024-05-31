using Example;
using Example.BinarySearch;
using Example.DynamicProgramming;

namespace TestProject1;

public class ExampleCases
{
    [Theory]
    [ClassData(typeof(UniqueNumberData))]
    public void FindUniqueElementTest(string numbers, int  answer)
    {
        List<int> number = numbers.Split(',').Select(int.Parse).ToList();

        BinarySearch binarySearch = new BinarySearch();
        int output = binarySearch.FindUniqueElement(number);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(FindPeakData))]
    public void FindPeakTest(string numbers, int  answer)
    {
        List<int> number = numbers.Split(',').Select(int.Parse).ToList();

        BinarySearch binarySearch = new BinarySearch();
        int output = binarySearch.FindPeak(number);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(LocalMinimaData))]
    public void LocalMinimaTest(string numbers, int  answer)
    {
        List<int> number = numbers.Split(',').Select(int.Parse).ToList();

        BinarySearch binarySearch = new BinarySearch();
        int output = binarySearch.LocalMinima(number);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(FindInRotatedArray))]
    public void FindInRotatedArrayTest(string numbers,  int target, int  answer)
    {
        List<int> number = numbers.Split(',').Select(int.Parse).ToList();

        BinarySearch binarySearch = new BinarySearch();
        int output = binarySearch.FindInRotatedArray(number, target);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(FindSquareRoot))]
    public void FindSquareRoot( int target, int  answer)
    {

        BinarySearch binarySearch = new BinarySearch();
        int output = binarySearch.FindSquareRoot( target);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(AthMagicalNumber))]
    public void AthMagicalNumber( int A, int  B, int C, int answer)
    {

        BinarySearch binarySearch = new BinarySearch();
        int output = binarySearch.MagicalNumber( A, B,C);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(MindBodyData))]
    public void MidBody( string input, int k, string answer)
    {

        MindBody binarySearch = new MindBody();
        string output = binarySearch.CroppedNotificationMessage( input,k);
        
        Assert.Equal(answer, output);
    }
    
    
    [Theory]
    [ClassData(typeof(LongestEvenNumberData))]
    public void MaxEvenNumber( string input, string answer)
    {

        LongestEvenNumber binarySearch = new LongestEvenNumber();
        string output = binarySearch.LongestEventNumber( input);
        
        Assert.Equal(answer, output);
    }
    
    [Theory]
    [ClassData(typeof(SortArrayBasedOnMagnitudeData))]
    public void SortArrayBasedOnMagnitudeTest( string input, string answer)
    {
        List<int> inputList = input.Split(',').Select(int.Parse).ToList();
        SortArrayBasedOnMagnitude binarySearch = new SortArrayBasedOnMagnitude();
        List<int> answerList = binarySearch.SortMeBasedOnSquare( inputList);
        
        Assert.Equal(answer, String.Join(',', answerList));
    }
    
    [Theory]
    [ClassData(typeof(SquareElementsData))]
    public void SquareArrayElements( string input, string answer)
    {
        List<int> inputList = input.Split(',').Select(int.Parse).ToList();
        SquareArrayElements binarySearch = new SquareArrayElements();
        List<int> answerList = binarySearch.SquareArray( inputList);
        
        Assert.Equal(answer, String.Join(',', answerList));
    }
    
    [Fact]
    public void MaxPathSum( )
    {
        MaximumScorePath binarySearch = new MaximumScorePath();
        int ans;
        int min;
        int max;
        (ans, min, max) = binarySearch.GetMaximumScorePath( );
        
        Assert.Equal( 26, ans);
        Assert.Equal( 4, min);
        Assert.Equal( 6, max);
    }
    
    [Theory]
    [ClassData(typeof(MaxSeaViewData))]
    public void MaxSeaViewCase( string input, string answer)
    {
        List<int> inputList = input.Split(',').Select(int.Parse).ToList();
        
        SeaViewLakeView binarySearch = new SeaViewLakeView();
        List<int> answerList = binarySearch.ClearViewIndices( inputList);

        answerList.Reverse();
        Assert.Equal(answer, String.Join(',', answerList));
    }
    
    [Theory]
    [ClassData(typeof(MaxSeaViewData))]
    public void MaxSeaViewCase2( string input, string answer)
    {
        List<int> inputList = input.Split(',').Select(int.Parse).ToList();
        
        SeaViewLakeView binarySearch = new SeaViewLakeView();
        List<int> answerList = binarySearch.SeaviewUsingLeftToRightTraerse( inputList);

        Assert.Equal(answer, String.Join(',', answerList));
    }
    
    [Theory]
    [ClassData(typeof(MaxSeaAndLAkeViewData))]
    public void MaxSeaLakeViewCase2( string input, string answer)
    {
        List<int> inputList = input.Split(',').Select(int.Parse).ToList();
        
        SeaViewLakeView binarySearch = new SeaViewLakeView();
        List<int> answerList = binarySearch.SeaPlusLakeView( inputList);

        Assert.Equal(answer, String.Join(',', answerList));
    }
    
    [Fact]
    public void LongestINcreasingPathCase( )
    {
        
        LongestIncreasingPath binarySearch = new LongestIncreasingPath();
        int answer = binarySearch.GetLongestIncreasingPath();
        
        Assert.Equal( 5, answer);


    }
    
    [Fact]
    public void OpenShopsTest( )
    {
        
        NumberOfOpenShops binarySearch = new NumberOfOpenShops();
        List<int> answer = binarySearch.NumberOFOpenShopsPriorityQueue();
        
        Assert.Equal("1,2,2,1", String.Join(',', answer));

    }
    
    [Fact]
    public void MinStackTest( )
    {
        
        MinStack binarySearch = new MinStack();
        binarySearch.Push(5);
        binarySearch.Push(3);
        binarySearch.Push(4);
        binarySearch.GetMin();
        binarySearch.Pop();
        binarySearch.Pop();
        binarySearch.Top();
        binarySearch.GetMin();

        
        Assert.Equal("1,2,2,1", String.Join(',', 1));

    }
    
    [Fact]
    public void RearrangeWords( )
    {
        
        SortTheSequence binarySearch = new SortTheSequence();
        string answer =  binarySearch.SortSequence("is2 sentence4 This1 a3");
        Assert.Equal("This is a sentence", answer);
        
        answer =  binarySearch.SortSequence("Myself2 Me1 I4 and3");
        Assert.Equal("Me Myself and I", answer);

    }
    
    [Fact]
    public void PrintDiagonaloFMatrixTest( )
    {
        
        PrintDiagonalOfMatrix binarySearch = new PrintDiagonalOfMatrix();
        string answer =  binarySearch.PrintDiagonal();
        Assert.Equal("1,2,4,7,5,3,6,8,9", answer);
        

    }
    
    [Fact]
    public void ReverseLinkedListInIntervals( )
    {
        
        ReverseLinkedList binarySearch = new ReverseLinkedList();
         string answer =  binarySearch.ReverseLinkedListInInterval(3,6);
         
         Assert.Equal("1,2,60,50,40,30,70", answer);
         
         answer =  binarySearch.ReverseLinkedListInInterval(1,7);
         
         Assert.Equal("70,60,50,40,30,2,1", answer);

        

    }
    
    [Fact]
    public void FileContentReadCase( )
    {
        string file = "abcdefghij";
        FileNReader binarySearch = new FileNReader(file);
        char[] buffer= new char[60];
        int answer =  binarySearch.NFile(buffer,60);
         
         
        Assert.Equal(10, answer);

        

    }
    
    [Fact]
    public void BstIteratorTest( )
    {
        string file = "abcdefghij";

        BstNode treeNode = new BstNode(1)
        {
            Value = 7,
            Left = new BstNode(3),
            Right = new BstNode(15)
            {
                Value = 15,
                Left = new BstNode(9),
                Right = new BstNode(20)
            }
        };
        BstIterator binarySearch = new BstIterator(treeNode);

        string answer = string.Empty;
        while (binarySearch.HasNext()) {
            answer += " " +(binarySearch.Next());
        }

        Assert.Equal("3 7 9 15 20", answer.Trim());

        

    }
    
    
    [Theory]
    [ClassData(typeof(MaximumDistanceData))]
    public void MaximumDistance( string input, double answer ,int k)
    {
        List<int> inputList = input.Split(',').Select(int.Parse).ToList();
        
        MaximumDistance binarySearch = new MaximumDistance();
        var answerList = binarySearch.MaximumDistanceOnAdditionOfNewNodes( inputList, k);

        Assert.Equal(answer, answerList);
    }
    
    [Fact]
    public void MeetingSpaceTest( )
    {
        
        MeetingRoomSpace binarySearch = new MeetingRoomSpace();
        var answerList = binarySearch.FindSpaceWithMaximumMeetings(2);

        Assert.Equal(1, answerList);
    }
    
    
    
}