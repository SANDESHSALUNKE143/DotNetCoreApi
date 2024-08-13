using System.Reflection.Metadata.Ecma335;

namespace Example;

public class ReverseLinkedList
{
    public string ReverseLinkedListInInterval(int left, int right)
    {
        ListNodeR head = new ListNodeR(1);
        head.Next = new ListNodeR(2);
        head.Next.Next = new ListNodeR(30);
        head.Next.Next.Next = new ListNodeR(40);
        head.Next.Next.Next.Next = new ListNodeR(50);
        head.Next.Next.Next.Next.Next = new ListNodeR(60);
        head.Next.Next.Next.Next.Next.Next = new ListNodeR(70);
        
        ListNodeR dummy = new ListNodeR(-1);
        dummy.Next = head;

        ListNodeR prev = dummy;

        for (int i = 0; i < left-1; i++)
        {
            prev = prev.Next;
        }

        ListNodeR cur = prev.Next;

        for (int i = 0; i < (right-left); i++)
        {
            ListNodeR next = cur.Next;
            cur.Next = next.Next;
            next.Next = prev.Next;
            prev.Next = next;
        }

        dummy = dummy.Next;

        string reverse = string.Empty;

        while (dummy != null)
        {
            reverse += dummy.Val + ",";
            dummy = dummy.Next;
        }

        return reverse.Substring(0, reverse.Length-1);

    }
    
}

public class ListNodeR
{
    public int Val { get; set; }
    public ListNodeR Next { get; set; }

    public ListNodeR(int val, ListNodeR next =null)
    {
        Val = val;
        Next = next;
    }
    
}