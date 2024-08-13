using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        
      Cache  cache = new Cache(5);
cache.Set(key:"A", value:5, priority:1, expiry: 1000);
// [A]
cache.Set(key:"B", value:15, priority:5, expiry: 500);
// [B, A]
cache.Set(key:"C", value:0, priority:5, expiry: 2000);
// [C, B, A]
cache.Set(key:"D", value:1, priority:5, expiry: 2000);
// [D, C, B, A]
cache.Set(key:"E", value:10, priority:5, expiry: 3000);
// [E, D, C, B, A]
cache.Get("C") ;// returns 0
// [C, E, D, B, A]
cache.Set(key:"F", value:15, priority:5, expiry: 1000); // since cache is full here expiry threshold applies, ex- if it returned 600, then B gets evicted and F gets inserted
// [F, C, E, D, A]
cache.Set(key:"G", value:0, priority:5, expiry: 2000) ;// again assume threshold returned 600 then none of the items expired, so the least priority item i.e. A gets evicted and G inserted
// [G, F, C, E, D]
cache.Set(key:"H", value:1, priority:1, expiry: 2000) ;// assuming threshold as 600, here none expired and all items have same priority, so least recently item D gets evicted
// [H, G, F, C, E]
cache.Get("D") ;// throw exception as D is not present in cache
cache.Set(key:"I", value:10, priority:2, expiry: 2000); // assuming threshold is 2000, the oldest expired item is F:1000, it gets evicted and I inserted
// [I, H, G, C, E]
cache.Set(key:"E", value:10, priority:2, expiry: 2000); // since E is already there no eviction
// [E, I, H, G, C]
cache.Set(key:"M", value:10, priority:1, expiry: 3000);// asuming threshold as 2000, all the items have same expiry so least priority H will get evicted
// [M, E, I, G, C]


    }
}

class Cache
{
    private readonly int _capacity;
    private readonly SortedSet<CacheItem> _minHeap;
    private readonly SortedSet<CacheItem> _minHeapForExpiry;
    private readonly Dictionary<string, CacheItem> _lruCache;
    private int _lastUsed;
    public Cache(int capacity)
    {
        _capacity = capacity;
        _lastUsed = 0;
        _minHeap = new SortedSet<CacheItem>(new CacheComparerWithLastUsed());
        _minHeapForExpiry = new SortedSet<CacheItem>(new CacheComparerWithExpiry());
        _lruCache = new Dictionary<string, CacheItem>();
    }

    public int Get(string key)
    {
        if(_lruCache.ContainsKey(key))
        {
            CacheItem returnVal = _lruCache[key];
            _minHeap.Remove(returnVal);
            _minHeapForExpiry.Remove(returnVal);

            returnVal.LastUsed = _lastUsed;
            _lastUsed++;

            _minHeap.Add(returnVal);
            _minHeapForExpiry.Add(returnVal);


            PrintAllInMinHeap();
            return returnVal.Value;
        }
        else
        {
            Console.WriteLine($"Given key {key} not present");
        }
        return 0;
    }

    public void Set(string key, int value, int expiry, int priority)
    {
        if(_lruCache.ContainsKey(key))
        {
            //remove from _minHeap

            CacheItem item = _lruCache[key];
            _minHeap.Remove(item);
            _minHeapForExpiry.Remove(item);

            item.Value=value;
            item.Expiry = expiry;
            item.Priority = priority;
            item.LastUsed = _lastUsed;
            _lastUsed++;

            _minHeap.Add(item);
            _minHeapForExpiry.Add(item);


        }

        else
        {
            CacheItem newItem = new CacheItem();
            newItem.Key = key;
            newItem.Value = value;
            newItem.Priority = priority;
            newItem.Expiry = expiry;
            newItem.LastUsed = _lastUsed;
            _lastUsed++;

            //check for eviction
            if(_capacity == _lruCache.Count)
            {
                int thresholdExpiry = GetExpiryThreshold();
                CacheItem evictCandidate = null;
                
                //  evictCandidate = _minHeap.Where(x=> x.Expiry < thresholdExpiry).
                //     OrderBy(x=> x.Expiry).FirstOrDefault();
                //
                // if(evictCandidate == null) //no expired item found
                // {
                //     //check by priority
                //     if(_minHeap.Select(x=> x.Priority).Distinct().Count() == 1)
                //     {
                //         //All element has same ppriority so laeast item should get evicted
                //         evictCandidate = _minHeap.Min;
                //     }
                //     else
                //     {
                //         evictCandidate = _minHeap.OrderBy(x=> x.Priority).FirstOrDefault();
                //     }
                // } 
                // else
                // {
                //     //check all items found has same expiry
                //
                //     int matchedItems  = _minHeap.Where(x=> x.Expiry < thresholdExpiry).Select(x=> x.Expiry).Count();
                //
                //     int distinctCount = _minHeap.Where(x=> x.Expiry < thresholdExpiry).Select(x=> x.Expiry).Distinct().Count();
                //
                //     if(matchedItems == distinctCount && matchedItems!= 1 )
                //     {
                //         //then we have to check for priority
                //         int matchedItemsPriority  = _minHeap.Where(x=> x.Expiry < thresholdExpiry).Select(x=> x.Priority).Count();
                //
                //         int distinctCountPriority = _minHeap.Where(x=> x.Expiry < thresholdExpiry).Select(x=> x.Priority).Distinct().Count();
                //
                //         if(matchedItemsPriority == distinctCountPriority)
                //         {
                //             //All element has same ppriority so laeast item should get evicted
                //             evictCandidate = _minHeap.Min;
                //         }
                //         else
                //         {
                //             evictCandidate = _minHeap.OrderBy(x=> x.Priority).FirstOrDefault();
                //         }
                //
                //     }
                //     else
                //     {
                //         evictCandidate = _minHeap.OrderBy(x=> x.Expiry).FirstOrDefault();
                //     }
                //
                // }

                if(evictCandidate == null)
                {
                    evictCandidate = _minHeap.Min;
                }
                if(evictCandidate != null)
                {
                    _lruCache.Remove(evictCandidate.Key);
                    _minHeap.Remove(evictCandidate);
                    _minHeapForExpiry.Remove(evictCandidate);
                }


            }
            
            

            _lruCache.Add(key, newItem);
            _minHeap.Add(newItem);
            _minHeapForExpiry.Add(newItem);
        }
        PrintAllInMinHeap();
    }

    int mockExpiry = 0;
    public int GetExpiryThreshold()
    {
        if(mockExpiry <3)
        {
            mockExpiry++;
            return 600;
        }
        else if(mockExpiry >=3 && mockExpiry <8)
        {
            mockExpiry++;
            return 2000;
        }
        else
        {
            mockExpiry++;
            return new Random().Next(0, 100001);
        }
    }

    string PrintAllInMinHeap()
    {
        StringBuilder sb = new StringBuilder();
        foreach(CacheItem item in _minHeap)
        {
            sb.Insert(0, $"{item.Key} ");
        }

        Console.WriteLine(sb.ToString());

        return sb.ToString();
    }


}

public class CacheItem
{
    public string Key{get;set;}
    public int Value {get; set;}
    public int Expiry {get; set;}
    public int Priority {get; set;}
    public int LastUsed {get; set;}
}

public class CacheComparerWithLastUsed :IComparer<CacheItem>
{
    public int Compare(CacheItem a, CacheItem b)
    {
        return a.LastUsed.CompareTo(b.LastUsed);
    }
}

public class CacheComparerWithExpiry:IComparer<CacheItem>
{
    public int Compare(CacheItem a, CacheItem b)
    {
        int comparison = a.Expiry.CompareTo(b.Expiry);
        if (comparison == 0)
        {
            return a.Priority.CompareTo(b.Priority);
        }

        return comparison;

    }
}



