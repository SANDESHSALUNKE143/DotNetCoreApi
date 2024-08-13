// See https://aka.ms/new-console-template for more information

using System.Text;
using HereWeGo;

LinkedListAddition linkedListAddition = new LinkedListAddition();

LinkedListAddition.ListNode  listNode=  linkedListAddition.CreateLinkedListFromArray(new List<int>(){1,2,3,4,5,6,7,8,9,10});

linkedListAddition.ReverseLinkedList(listNode, 4,7);


#region Subset

List<List<int>> Subsets(List<int> A)
{
    A.Sort();
    List<List<int>> outPut = new List<List<int>>();
    List<int> tempList = new List<int>();
    GetSubSetRecursion(A, 0, outPut, tempList, A.Count, "Main");

    return outPut;
}

void GetSubSetRecursion(List<int> A, int index, List<List<int>> outPut, List<int> tempList, int length, string caller)
{
    StringBuilder sb = new StringBuilder();
    foreach (var inner in outPut)
    {
        sb.Append("[");
        sb.Append(string.Join(',', inner));
        sb.Append("], ");
    }

    Console.WriteLine($"caller {caller} index is {index} tempList {string.Join(',', tempList)} output is {sb}");

    if (index == length)
    {
        return;
    }

    tempList.Add(A[index]);

    outPut.Add(new List<int>(tempList));

    GetSubSetRecursion(A, index + 1, outPut, tempList, length, "First");

    tempList.Remove(A[index]);

    GetSubSetRecursion(A, index + 1, outPut, tempList, length, "Second");
}

#endregion


#region Permute

List<List<int>> Permute(List<int> A)
{
    List<List<int>> output = new List<List<int>>();
    SwapMain(0, A, output);
    return output;
}

void SwapMain(int indexToFix, List<int> inputArray, List<List<int>> output)
{
    Console.WriteLine($"Index {indexToFix} inputArray {string.Join(',' , inputArray)}");
    if (indexToFix == inputArray.Count)
    {
        output.Add(new List<int>(inputArray));
        return;
    }

    for (int j = indexToFix; j < inputArray.Count; j++)
    {
        SwapElementInArray(indexToFix, j, inputArray);

        SwapMain(indexToFix + 1, inputArray, output);

        SwapElementInArray(indexToFix, j, inputArray);
    }
}

void SwapElementInArray(int index1, int index2, List<int> arr)
{
    if (index1 == index2)
    {
        return;
    }

    (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
}

#endregion

#region Valid parenthesis

List<string> GenerateParenthesis(int A) {

    List<string>  answer =new List<string>();

    GeneratePattern(new  List<string>(), 0, 0, A, answer);

    return answer;
}


void GeneratePattern(List<string> arr, int openCount, int closeCount, int capacity, List<string>  answer)
{
    Console.WriteLine($"open count {openCount} close count {closeCount} temp arr = {String.Join(',',arr)} answer = {String.Join(",", answer)}");
    if(openCount == capacity && closeCount  == capacity)
    {
        answer.Add( string.Join("", arr));
    }

    if(closeCount > capacity || openCount > capacity)
    {
        return;
    }

    if(openCount < capacity)
    {
        arr.Add("(");
        GeneratePattern(arr, openCount+1, closeCount, capacity, answer);
        Console.WriteLine("Removing (");
        arr.RemoveAt(arr.Count -1);
    }

    if(closeCount < openCount)
    {
        arr.Add(")");
        GeneratePattern(arr, openCount, closeCount+1, capacity, answer);
        Console.WriteLine("Removing )");

        arr.RemoveAt(arr.Count -1);
    }
}

#endregion

#region  Get POwer 

 int PowerOfNumber(int A, int B, int C) {
    // Just write your code below to complete the function. Required input is available to you as the function arguments.
    // Do not print the result or any output. Just return the result via this function.

    long answer = A;

    if(B == 0)
    {
        return 1 % C;
    }

    answer = GetPower(A, B);
        
    if((B & 1) != 1 && answer < 0)
    {
        answer = answer * -1;
    }

    return (int) ((answer % C + C) % C);

}

 long GetPower(int number, int power)
{
    if (power == 0)
    {
        return 1;
    }
        
    long temp = GetPower((number% 1000000007), power / 2) % 1000000007;
    if (power % 2 == 0)
    {
        return temp * temp % 1000000007;
    }
    else
    {
        return (((number% 1000000007) * temp)% 1000000007 * temp) % 1000000007;
    }
        
}

#endregion


#region Comape Sort

void TestIComparer()
{
    List<string> A = new List<string>(new string[]
    {
        "yletsyqo", "deo", "ta", "lrksykjdbk", "rott", "imwjieai", "fpheafpm", "wcpemdhcy", "aiazylfdc", "iyolrthzh",
        "ar", "fikuvfsn", "mudlnlnw", "nbabvrogrs", "prrgsre", "dnye", "heccs", "nyhys", "swplwaounl", "an",
        "ywghhvzoj", "stmnkcne", "oyzs", "xa", "bayi", "thnvixpq", "nsgkqf", "cegxyp", "uurfvqicfy", "gdo", "rqh",
        "jsin", "nsnhag", "ncvvtmgzhy", "ucpi", "q", "mhdten", "h", "rpqavixphk", "gg", "rl", "veylpmul", "xatmlha",
        "pwwbhd", "rkw", "jhnzpysl", "jyvlu", "w", "qfxznnyqr", "ictlvp", "tem", "rldgwsosrq", "rdghttqjqv",
        "ifbueszsak", "v", "fwhcnevx", "ewy", "dlxwsq", "fnkiiadd", "vfa", "tyymrcod", "ojs", "ndnjerj", "clftiakjw",
        "teqk", "xnzm", "cchdot", "ujcdk", "hwabbmut", "bpqkfmlf", "tyuizuokt", "uqvl", "qxypeuu", "if", "v",
        "osgyebpnnz", "lbzhfgoom"
    });

    A.Sort(new CustomComparer());

    Console.WriteLine(string.Join(" ", A));
}

class CustomComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        if (x.Length < y.Length)
        {
            return -1;
        }
        else if (x.Length > y.Length)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
#endregion