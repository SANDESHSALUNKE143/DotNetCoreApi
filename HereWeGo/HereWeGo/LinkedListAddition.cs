using System.Data.Common;
using System.Globalization;

namespace HereWeGo;

public class LinkedListAddition
{
    public class ListNode
    {
        public int ValueOfNode { get; }
        public ListNode? NextNode { get; set; }

        public ListNode(int val = 0)
        {
            this.ValueOfNode = val;
            NextNode = null;
        }
    }


    public ListNode ReverseLinkedList(ListNode listNode, int B, int C)
    {

        int length = GetLengthOfLinkedList(listNode);
        
        ListNode part1 = null;
        ListNode part2 = null;
        ListNode part3 = null;
        
        ListNode temp = listNode;
        ListNode first = null;
        for (int i = 1; i < B; i++)
        {
            part1 = InsertNode(part1, temp.ValueOfNode);
            temp = temp.NextNode;

            if (i == B - 1)
            {
                
            }
        }

        Console.WriteLine("PART1");
        
        PrintList(part1);
        ListNode prevoius = null;
        ListNode tail = null;
        for (int i = B; i <= C; i++)
        {
            ListNode next = temp.NextNode;
            temp.NextNode = prevoius;

            prevoius = temp;
            temp = next;
        }

        Console.WriteLine("prevoius");
        PrintList(prevoius);




        //merge two list

        ListNode mergedList = InsertNode(part1, prevoius);
        Console.WriteLine("mergedList");
        PrintList(mergedList);

        if (part1!= null)
        {
            part1.NextNode = prevoius;
            Console.WriteLine("part1");
            PrintList(part1);
        }
        else
        {
            part1 = prevoius;
        }

        part1.NextNode = temp;
        // for (int i = C+1; i <= length ; i++)
        // {
        //     InsertNode(mergedList, temp.ValueOfNode);
        //     temp = temp.NextNode;
        // } 
        
        Console.WriteLine("Result");
        PrintList(mergedList);
        return mergedList;

    }

    private void PrintList(ListNode input)
    {
        ListNode crr = input;
        while (crr != null)
        {
            Console.Write($"{crr.ValueOfNode}-->");
            crr = crr.NextNode;
        }

        Console.WriteLine("");
    }
    private int GetLengthOfLinkedList(ListNode? input)
    {
        int count = 0;
        if (input == null)
            return 0;

        ListNode? cur = input;
        while (cur != null)
        {
            count++;
            cur = cur.NextNode;
        }

        return count;

    }

    private ListNode InsertNode(ListNode input, int data)
    {
        if (input == null)
        {
            return new ListNode(data);
        }

        ListNode lasNode = input;
        
        while (lasNode.NextNode != null)
        {
            lasNode = lasNode.NextNode;
        }

        lasNode.NextNode = new ListNode(data);
        return input;
    }
    
    private ListNode InsertNode(ListNode input, ListNode nodeToInsert)
    {
        if (input == null)
        {
            return nodeToInsert;
        }

        ListNode lasNode = input;
        
        while (lasNode.NextNode != null)
        {
            lasNode = lasNode.NextNode;
        }

        lasNode.NextNode = nodeToInsert;
        return input;
    }

    public ListNode CreateLinkedListFromArray(List<int> input)
    {
        ListNode? linkedList = null;
        for (int i = 0; i < input.Count; i++)
        {
            linkedList = AddNewNode(linkedList, input[i]);
        }

        return linkedList;

    }

    private ListNode AddNewNode(ListNode? input, int data)
    {
        if (input == null)
        {
            return  new ListNode(data);
        }

        ListNode newNode = new ListNode(data);
        ListNode lastNode = input;
        while (lastNode.NextNode !=null)
        {
            lastNode = lastNode.NextNode;
        }

        lastNode.NextNode = newNode;

        return input;

    }
}