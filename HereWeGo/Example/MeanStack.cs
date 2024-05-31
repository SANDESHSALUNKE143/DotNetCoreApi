namespace Example;

public class MinStack {

    Node head;
    Node minStack;
    private int time = 0;
    SortedSet<MinHEapItem> _minHeap = new SortedSet<MinHEapItem>();
   
    
    public void Push(int val) {
        Node newNode =  new Node(val);
        newNode.Next = head;
        head = newNode;
        
        _minHeap.Add(new MinHEapItem(val,time));
        time++;


    }
    
    public void Pop() {
        if(head == null)
        {
            return;
        }

        MinHEapItem x = _minHeap.Where(x => x.Value == head.Value).FirstOrDefault();
        _minHeap.Remove(x);

        head = head.Next;
    }
    
    public int Top() {
        if(head == null)
        {
            return -1;
        }

        return head.Value;
    }
    
    public int GetMin() {
        if(_minHeap.Count > 0)
        {
            return _minHeap.Min.Value;
        }

        return -1;
    }
}

class Node
{
    public int Value {get; set;}
    public Node Next {get;set;}

    public Node(int val)
    {
        Value = val;
    }
}

class MinHEapItem:IComparable<MinHEapItem>
{
    public int Value { get; set; }
    public int Time { get; set; }

    public MinHEapItem(int value, int time)
    {
        Value = value;
        Time = time;
    }

    public int CompareTo(MinHEapItem other)
    {
        int comparison = Value.CompareTo(other.Value);
        if (comparison == 0)
        {
            return Time.CompareTo(other.Time);
        }

        return comparison;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */