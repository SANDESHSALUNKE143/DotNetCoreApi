using System.Collections;

namespace TestProject1;

public abstract class TestData
{
    public static IEnumerable<object> Data()
    {
        yield return new object[]{new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 },new List<int> {1, 6, -1, 10}, true };
    }
}

public  class UniqueNumberData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "5,5,5,5,6,6,1,4,4",1 };
        yield return new object[]{ "5,5,5,5,1,6,6,4,4",1 };
        yield return new object[]{ "1,5,5,6,6,4,4",1 };
        yield return new object[]{ "5,5,6,6,4,4,1",1 };
        yield return new object[]{ "5,5,6,6,4,4,1,1",-1 };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class MindBodyData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "And now here is my secret",15,"And now ..." };
        yield return new object[]{ "There is an animal with four legs",15,"There is an ..." };
        yield return new object[]{ "There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal anima",500,"There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal with four legs There is an animal ..." };
        yield return new object[]{ "super dog",4,"..." };
        yield return new object[]{ "ag",3,"..." };
        yield return new object[]{ "a",3,"..." };
        yield return new object[]{ "how are you",20,"how are you" };
        yield return new object[]{ "how are you",3,"..." };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

//LongestEvenNumber

public  class LongestEvenNumberData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "63", "6" };
        yield return new object[]{ "636", "636" };
        yield return new object[]{ "6361", "636" };
        yield return new object[]{ "60361", "6036" };
        yield return new object[]{ "60361323232323232323232323232323211112333333333332", "60361323232323232323232323232323211112333333333332" };
        yield return new object[]{ "6111111111111111111111111111111111111111111111", "6" };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class FindPeakData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "1,2,3,4,5,4,2", 5 };
        yield return new object[]{ "1,2,3,4,5,1", 5 };
        yield return new object[]{ "1,2,3,4,3,1", 4 };
        yield return new object[]{ "1,5,1", 5 };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class SortArrayBasedOnMagnitudeData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "1,2,3,4,5", "1,4,9,16,25" };
        yield return new object[]{ "-5,1,0,3,10", "0,1,9,25,100" };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class SquareElementsData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "-4,2,5", "4,16,25" };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class MaxSeaViewData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "5, 6, 2, 3, 1", "1,3,4" };
        yield return new object[]{ "3, 9, 7, 5, 1, 2", "1,2,3,5" };
        yield return new object[]{ "1,3,4,5", "3" };
        yield return new object[]{ "4,2,3,1", "0,2,3" };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class MaxSeaAndLAkeViewData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "5, 6, 2, 3, 1", "0,1,3,4" };
        yield return new object[]{ "3, 9, 7, 5, 1, 2", "0,1,2,3,5" };
        yield return new object[]{ "1,3,4,5", "0,1,2,3" };
        yield return new object[]{ "4,2,3,1", "0,2,3" };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class MaximumDistanceData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "1, 2, 3, 4, 5, 6, 7, 8, 9, 10", 0.5,9 };
        yield return new object[]{ "23, 24, 36, 39, 46, 56, 57, 65, 74, 84, 98", 14,3 };
        yield return new object[]{ "10, 19, 25, 27, 56, 63, 70, 87, 96, 97", 9.66,3 };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class LocalMinimaData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "1,2,3,4,5,4,2", 1 };
        yield return new object[]{ "5,2,3,4,5,1", 1 };
        yield return new object[]{ "9,8,7,10,6,4,2,5", 2 };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


public  class FindInRotatedArray: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ "10,20,30,1,2,4,5", 5,6 };
        yield return new object[]{ "10,20,30,1,2,4,5", 10,0 };
        yield return new object[]{ "10,20,30,1,2,4,5", 1,3 };
        yield return new object[]{ "10,20,30,1,2,4,5", 30,2 };
        yield return new object[]{ "10,20,30,1,2,4,5", 20,1 };
        yield return new object[]{ "10,20,30,1,2,4,5", 1,3 };
        yield return new object[]{ "10,20,30,1,2,4,5", 2,4 };
        yield return new object[]{ "10,20,30,1,2,4,5", 4,5 };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class FindSquareRoot: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ 25, 5 };
        yield return new object[]{ 49, 7 };
        yield return new object[]{ 121, 11 };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public  class AthMagicalNumber: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ 1,2,3, 2 };
        yield return new object[]{ 4,2,3, 6};
        yield return new object[]{ 3,5,7, 10};
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public abstract class PrimeNumbersTestData
{
    public static IEnumerable<object> Data()
    {
        yield return new object[]{1,false };
        yield return new object[]{4,false };
        yield return new object[]{2,true };
        yield return new object[]{3,true };
        yield return new object[]{5,true };
    }
}