// See https://aka.ms/new-console-template for more information



using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DateTime = System.DateTime;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

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


public class Cache
{
    private int capacity;
    private SortedSet<CacheItem> sortedSet;
    private Dictionary<string, CacheItem> cacheMap;
    private Random random;

    public Cache(int capacity)
    {
        this.capacity = capacity;
        this.sortedSet = new SortedSet<CacheItem>(new CacheItemComparer());
        this.cacheMap = new Dictionary<string, CacheItem>();
        this.random = new Random();
    }

    public void Set(string key, int value, int priority, int expiry, int threshiold)
    {
        // Create or update cache item
        CacheItem newItem = new CacheItem(key, value, priority, expiry);

        if (cacheMap.ContainsKey(key))
        {
            // Update existing item
            CacheItem existingItem = cacheMap[key];
            sortedSet.Remove(existingItem); // Remove existing item from sortedSet

            existingItem.Value = value;
            existingItem.Priority = priority;
            existingItem.Expiry = expiry;
            existingItem.LastAccessTime = DateTime.UtcNow;

            sortedSet.Add(existingItem); // Add updated item back to sortedSet
        }
        else
        {
            // Insert new item
            cacheMap[key] = newItem;
            sortedSet.Add(newItem); // Add new item to sortedSet

            // Check if cache exceeds capacity
            if (sortedSet.Count > capacity)
            {
                Evict(threshiold); // Evict least desirable item
            }
        }
        
        PrintHeap();

    }

    public int Get(string key)
    {
        if (cacheMap.TryGetValue(key, out CacheItem item))
        {
            // Update last access time
            sortedSet.Remove(item); // Remove item from sortedSet
            item.LastAccessTime = DateTime.UtcNow;
            sortedSet.Add(item); // Add item back to sortedSet to update position
            PrintHeap();

            return item.Value;
        }
        else
        {
            throw new KeyNotFoundException("Key not found in cache");
        }
    }

    private void PrintHeap()
    {
        StringBuilder sb = new StringBuilder();
        foreach (CacheItem item in sortedSet)
        {
            sb.Append( $"{item.Key} ");
        }

        Console.WriteLine(sb.ToString());
    }
    private void Evict(int threshiold)
    {
        int threshold = threshiold;//GetExpiryThreshold(); // Get expiry threshold

        
        //check for item who is less than threshold

        CacheItem eviction = null;
        foreach (var  item in sortedSet)
        {
            if (item.Expiry < threshiold)
            {
                eviction = item;
            }
        }

        if (eviction != null)
        {
            // Remove item from sortedSet and cacheMap
            sortedSet.Remove(eviction);
            cacheMap.Remove(eviction.Key);
        }
        
        // Find the least desirable item to evict based on the eviction policy
        CacheItem itemToEvict = sortedSet
            .Where(item => item.Expiry < threshold)
            .OrderByDescending(item => item.Priority)
            .FirstOrDefault();

        if (itemToEvict == null)
        {
            // If no item meets the expiry threshold, evict the least recently used item
            itemToEvict = sortedSet.First();
        }

        if (itemToEvict != null)
        {
            // Remove item from sortedSet and cacheMap
            sortedSet.Remove(itemToEvict);
            cacheMap.Remove(itemToEvict.Key);
        }
    }

    private int GetExpiryThreshold()
    {
        // Simulate API call to get a random expiry threshold
        return random.Next(0, 100001);
    }
}

public class CacheItem
{
    public string Key { get; private set; }
    public int Value { get; set; }
    public int Priority { get; set; }
    public int Expiry { get; set; }
    public DateTime LastAccessTime { get; set; }

    public CacheItem(string key, int value, int priority, int expiry)
    {
        Key = key;
        Value = value;
        Priority = priority;
        Expiry = expiry;
        LastAccessTime = DateTime.UtcNow;
    }
}

public class CacheItemComparer : System.Collections.Generic.IComparer<CacheItem>
{
    public int Compare(CacheItem x, CacheItem y)
    {
        return x.LastAccessTime.CompareTo(y.LastAccessTime); // Compare by last access time (ascending)
    }
}
