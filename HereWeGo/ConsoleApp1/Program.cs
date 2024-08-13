using System;
using System.Text;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        Cache cache = new Cache(5);
        cache.Set(key: "A", value: 5, priority: 1, expiry: 1000,0);
// [A]
        cache.Set(key: "B", value: 15, priority: 5, expiry: 500,0);
// [B, A]
        cache.Set(key: "C", value: 0, priority: 5, expiry: 2000,0);
// [C, B, A]
        cache.Set(key: "D", value: 1, priority: 5, expiry: 2000,0);
// [D, C, B, A]
        cache.Set(key: "E", value: 10, priority: 5, expiry: 3000,0);
// [E, D, C, B, A]
        cache.Get("C"); // returns 0
// [C, E, D, B, A]
        cache.Set(key: "F", value: 15, priority: 5,
            expiry: 1000, 600); // since cache is full here expiry threshold applies, ex- if it returned 600, then B gets evicted and F gets inserted
// [F, C, E, D, A]
        cache.Set(key: "G", value: 0, priority: 5,
            expiry: 2000,600); // again assume threshold returned 600 then none of the items expired, so the least priority item i.e. A gets evicted and G inserted
// [G, F, C, E, D]
        cache.Set(key: "H", value: 1, priority: 1,
            expiry: 2000,600); // assuming threshold as 600, here none expired and all items have same priority, so least recently item D gets evicted
// [H, G, F, C, E]
        try
        {
            cache.Get("D"); // throw exception as D is not present in cache
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        cache.Set(key: "I", value: 10, priority: 2,
            expiry: 2000,2000); // assuming threshold is 2000, the oldest expired item is F:1000, it gets evicted and I inserted
// [I, H, G, C, E]
        cache.Set(key: "E", value: 10, priority: 2, expiry: 2000,0); // since E is already there no eviction
// [E, I, H, G, C]
        cache.Set(key: "M", value: 10, priority: 1,
            expiry: 3000,2000); // asuming threshold as 2000, all the items have same expiry so least priority H will get evicted
// [M, E, I, G, C]
    }
}

class Cache
{
    readonly Dictionary<string, CacheItem?> _lruCache;

    readonly SortedSet<CacheItem?> _minHeap;
    int _capacity;
    int _lastUsed;

    public Cache(int capacity)
    {
        _capacity = capacity;
        _lastUsed = 0;
        _lruCache = new Dictionary<string, CacheItem?>();
        _minHeap = new SortedSet<CacheItem?>(new CacheItemComparer1());
    }

    public void Set(string key, int value, int priority, int expiry, int threshold)
    {
        if (_lruCache.ContainsKey(key))
        {
            //update value in cache in MinHeap
            CacheItem? item = _lruCache[key];
            _minHeap.Remove(item);


            item.Value = value;
            item.Priority = priority;
            item.Expiry = expiry;
            item.LastUsed = _lastUsed;
            _lastUsed++;

            _minHeap.Add(item);
        }
        else
        {
            //Create new Entry

            CacheItem? item = new CacheItem();
            item.Key = key;
            item.Value = value;
            item.Expiry = expiry;
            item.Priority = priority;
            item.LastUsed = _lastUsed;
            _lastUsed++;


            //check for capacity
            if (_capacity <= _lruCache.Count)
            {
                //we need to evict
                
                //CHECK WHETHER all elements has same expiry
                
                CacheItem? itemToEvict = _minHeap
                    .FirstOrDefault(item2 => item2 != null && item2.Expiry < threshold);

                if (itemToEvict == null)
                {
                    Console.WriteLine("None of the item expired, check for priority");
                    if (_minHeap.Select(x=> x.Priority).Distinct().Count() == 1)//All priority same
                    {
                        Console.WriteLine("All Priority same so remove heap min"); 
                        itemToEvict = _minHeap.Min;

                    }
                    else
                    {
                        Console.WriteLine("Get least priority item"); 
                        itemToEvict = _minHeap.MinBy(item3 => item3.Priority);
                    }
                   
                }
                else
                {
                    itemToEvict = _minHeap
                        .OrderBy(item14 => item14.Expiry)
                        .ThenBy(item14 => item14.Priority)
                        .FirstOrDefault();
                }

                if (itemToEvict == null)
                {
                    // If no item meets the expiry threshold, evict the least recently used item
                    itemToEvict = _minHeap.Min;
                }

                if (itemToEvict != null)
                {
                    // Remove item from sortedSet and cacheMap
                    _minHeap.Remove(itemToEvict);
                    _lruCache.Remove(itemToEvict.Key);
                }
                
            }

            _minHeap.Add(item);
            _lruCache.Add(key, item);
        }

        PrintHeap();
    }

    private void PrintHeap()
    {
        StringBuilder sb = new StringBuilder();
        foreach (CacheItem? item in _minHeap)
        {
            sb.Insert(0, $"{item.Key} ");
        }

        Console.WriteLine(sb.ToString());
    }

    public int Get(string key)
    {
        if (_lruCache.ContainsKey(key))
        {
            CacheItem? item = _lruCache[key];
            _minHeap.Remove(item);

            //update lastused
            item.LastUsed = _lastUsed;
            _lastUsed++;

            //remove from heap
            _minHeap.Add(item);
            Console.WriteLine(item.Value);
            
            PrintHeap();

            return item.Value;
        }
        else
        {
            Console.WriteLine($"{key} not found");
            throw new Exception($"{key} not found");
        }

    }
}


class CacheItem
{
    public int Expiry { get; set; }

    public int Priority { get; set; }

    public string Key { get; set; }

    public int Value { get; set; }

    public int LastUsed { get; set; }
}

class CacheItemComparer1 : IComparer<CacheItem?>
{
    public int Compare(CacheItem? a, CacheItem? b)
    {
        if (a == null || b == null)
            throw new ArgumentNullException();

        return a.LastUsed.CompareTo(b.LastUsed);
    }
}

