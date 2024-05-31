using System.Collections;

namespace Example.Heap;

public class LruCacheApproach2
{
    private Dictionary<string, CacheItem> _lruCache;
    private MinHeap<CacheItem> _minHeap;

    private int _capacity;
    public LruCacheApproach2(int capacity)
    {
        _capacity = capacity;
        _minHeap = new MinHeap<CacheItem>(new CacheItemCompare());
        _lruCache = new Dictionary<string, CacheItem>();
    }

}

class CacheItem
{
    public int Expiry { get; set; }
    public int Priority { get; set; }
    public int LastUsed { get; set; }
    
    public int Key { get; set; }
    
    public  int Value { get; set; }
}

class CacheItemCompare : IComparer<CacheItem>
{

    public int Compare(CacheItem? a, CacheItem? b)
    {
        if (  ReferenceEquals( a, b))
        {
            return 0;
        }

        if (ReferenceEquals(a, null))
        {
            return 1;
        }
        if (ReferenceEquals(b, null))
        {
            return 0;
        }

        if (a.Expiry > b.Expiry)
        {
            return 1;
        }

        if (a.Priority > b.Priority)
        {
            return 1;
        }

        if (a.LastUsed > b.LastUsed)
        {
            return 1;
        }

        return -1;
    }
}

class MinHeap<T>
{
    private readonly IComparer<T> _comparer;
    private readonly List<T> _minHeap;

    public MinHeap(IComparer<T> comparer)
    {
        _comparer = comparer;
        _minHeap = new List<T>();
    }

    public int Size()
    {
        return _minHeap.Count;
    }

    public T Peek()
    {
        return _minHeap.Count > 0 ? _minHeap[0] : throw new ArgumentNullException();
    }

    public void Enqueue(T cacheItem)
    {
        //insert at last
        //swap first and last
        //start from last and get parents
        
        _minHeap.Add(cacheItem);
        int startIndex = _minHeap.Count -1;
        while (startIndex > 0)
        {
            //get parent

            int parent = (startIndex - 1) / 2;

            if (_comparer.Compare(_minHeap[parent], _minHeap[startIndex]) <= 0)
            {
               break;
            }
            //swap
            Swap(startIndex, parent);
            startIndex = parent;
        }
    }

    public T Dequeue()
    {
        T itemtoRemove = _minHeap[0];
        
        //replace last with first
        int lastIndex = _minHeap.Count - 1;
        
        Swap(0, lastIndex);
        
        //delete from last
        _minHeap.RemoveAt(lastIndex);
        
        //move top to down
        lastIndex--;
        int startIndex = 0;
        int li = startIndex * 2 + 1;
        int ri = startIndex * 2 + 2;
        while (li < lastIndex)
        {
            int min = startIndex;

            if (_comparer.Compare(_minHeap[startIndex], _minHeap[li]) > 0)
            {
                min = li;
            }

            if (ri < lastIndex  && _comparer.Compare(_minHeap[min], _minHeap[ri]) > 0)
            {
                min = ri;
            }

            if (min == startIndex)
            {
                //do nithing 
                break;
            }

            if (min == li)
            {
                Swap(min,li);
                startIndex = li;
            }
            else
            {
                Swap(min, ri);
                startIndex = ri;
            }

            li = startIndex * 2 + 1;
            ri = startIndex * 2 + 2;

        }
        

        return itemtoRemove;
    }

    private void Swap(int i, int j)
    {
        (_minHeap[i], _minHeap[j]) = (_minHeap[j], _minHeap[i]);
    }
    
}