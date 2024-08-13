using System.Security.Cryptography;

namespace Example;

class  CacheItem:IComparable<CacheItem>
{
    public string Key { get; set; }
    public int Value{ get; set; }
    public int Priority{ get; set; }
    public int Expiry{ get; set; }
    public int LastUsed { get; set; }


    public int CompareTo(CacheItem? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        if(Expiry < other.Expiry)
        {
            return -1;
        }
    
        if (Expiry != other.Expiry) return 1;
        if (Priority < other.Priority)
        {
            return -1;
        }
    
        if (Priority == other.Priority)
        {
            return LastUsed < other.LastUsed ? -1 : 1;
        }
    
        return 1;
    
    
    }
    
}
public class LruCache
{
    private SortedSet<CacheItem> _minHeap;
    private Dictionary<string, CacheItem> _lruCache;
    private int _lastUsed;
    private int _capacity;

    public LruCache(int capacity)
    {
        _capacity = capacity;
        _minHeap = new SortedSet<CacheItem>();
        _lruCache = new Dictionary<string, CacheItem>();
        _lastUsed = 0;
    }

    public int Get(string key)
    {
        //check in dictionary ,
        // if found get value, 
        if (_lruCache.ContainsKey(key))
        {
            CacheItem cacheItem = _lruCache[key];
            //set last recently used 
           
            //Remove existing 
            _minHeap.Remove(cacheItem);
            
            cacheItem.LastUsed = _lastUsed;
            _lastUsed++;
            _minHeap.Add(cacheItem);
            return cacheItem.Value;
        }
        else
        {
            return -1;
        }
        //if not found then return -1. or throw exception
    }

    public void Set(string key, int value, int priority, int expiry)
    {
        if (_lruCache.ContainsKey(key))
        {
            CacheItem cacheItem = _lruCache[key];
            _minHeap.Remove(cacheItem);
            cacheItem.LastUsed = _lastUsed;
            _lastUsed++;
            cacheItem.Expiry = expiry;
            cacheItem.Priority = priority;
            cacheItem.Value = value;
            _minHeap.Add(cacheItem);
            
        }
        else
        {
            //add new . Check for Capacity
            if (_capacity <= _lruCache.Count)
            {
                EvictItemsBasedOnExpiry();
            }
            
            //Add new 
            CacheItem newItemToAdd = new CacheItem();
            newItemToAdd.Expiry = expiry;
            newItemToAdd.LastUsed = _lastUsed;
            _lastUsed++;
            newItemToAdd.Priority = priority;
            newItemToAdd.Value = value;
            newItemToAdd.Key = key;

            _minHeap.Add(newItemToAdd);
            
            _lruCache.Add(key,newItemToAdd);
            
        }
    }

    private void EvictItemsBasedOnExpiry()
    {
        int expiryThreshold = RandomNumberGenerator.GetInt32(0, 100001);

        while (_lruCache.Count >= _capacity)
        {
            CacheItem cacheItem = _minHeap.Min;
            if (cacheItem.Expiry < expiryThreshold)
            {
                _minHeap.Remove(cacheItem);
                _lruCache.Remove(cacheItem.Key);

            }
        }
        
    }
}