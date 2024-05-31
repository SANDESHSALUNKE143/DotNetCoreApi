namespace Example;

public class NumberOfOpenShops
{
    public List<int> NumberOFOpenShopsPriorityQueue()
    {
        List<List<int>> input = new List<List<int>>()
        {
            new List<int>() { 2, 5 },
            new List<int>() { 1, 8 },
            new List<int>() { 5, 8 },
            new List<int>() { 9, 13 }
        };

        List<int> query = new List<int>();
        query.Add(1);
        query.Add(3);
        query.Add(6);
        query.Add(12);
        
        List<ShopTimings> allShops = new List<ShopTimings>();
        SortedSet<ShopTimings> minHeapForShops = new SortedSet<ShopTimings>(new ShopTimingsComparerByCloseTime());
        foreach (var item in input)
        {
            ShopTimings shopTimings = new ShopTimings() { OpenTime = item[0], CloseTime = item[1] };
            allShops.Add(shopTimings);
        }
        
        //sort shops by open time
        allShops.Sort(new ShopTimingsComparerByOpenTime());

        List<int> answer = new List<int>();
        int shopCounter = 0;
        for (int i = 0; i < query.Count; i++)
        {
            int visitTime = query[i];

            for (int shop = shopCounter; shop < allShops.Count;shop++)
            {
                if (allShops[shop].OpenTime <= visitTime)
                {
                    minHeapForShops.Add(new ShopTimings()
                        { OpenTime = allShops[shop].OpenTime, CloseTime = allShops[shop].CloseTime, TimeStamp = shop});
                }
                else
                {
                    shopCounter = shop;

                    break;
                }
                
            }
            

            while (minHeapForShops.Count > 0 && visitTime > minHeapForShops.Min.CloseTime)
            {
                minHeapForShops.Remove(minHeapForShops.Min);
            }

            answer.Add(minHeapForShops.Count);
        }

        return answer;
    }
    
    
}

public class ShopTimings
{
    public int OpenTime { get; set; }
    
    public int CloseTime { get; set; }
    public int TimeStamp { get; set; }
}

public class ShopTimingsComparerByOpenTime : IComparer<ShopTimings>
{
    public int Compare(ShopTimings a, ShopTimings b)
    {
        return a.OpenTime.CompareTo(b.OpenTime);
    }
}

public class ShopTimingsComparerByCloseTime : IComparer<ShopTimings>
{
    public int Compare(ShopTimings a, ShopTimings b)
    {
        int comparison =  a.CloseTime.CompareTo(b.CloseTime);

        if (comparison == 0)
        {
            return  a.TimeStamp.CompareTo(b.TimeStamp);
            
        }

        return comparison;
    }
}
