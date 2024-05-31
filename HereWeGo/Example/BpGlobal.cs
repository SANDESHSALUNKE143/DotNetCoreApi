namespace Example;

public class BpGlobal
{
    public IEnumerable<string> InterSectionOfTwoLinkedList(string[] lines)
    {
        List<string> answer = new List<string>();
        SinglyLinkedList singlyLinkedList = new SinglyLinkedList();

        foreach (var links in lines)
        {
            if (!links.Contains(','))
            {
                // address all edges
                string[] nodes = links.Split("->");
                singlyLinkedList.AddEdge(nodes[0], nodes[1]);
            }
            else
            {
                //check for intersection
                string[] startNodes = links.Split(',');
                try
                {
                    bool status = singlyLinkedList.DoesIntersect(startNodes);
                    answer.Add(status.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    answer.Add("Error Thrown!");
                }
               
            }
        }
        

        return answer;
    }
}

public class SinglyLinkedList
{
    private Dictionary<string, string> _nextNode;
    public SinglyLinkedList()
    {
        _nextNode = new Dictionary<string, string>();
    }

    public void AddEdge(string from, string to)
    {
        if (!_nextNode.ContainsKey(from))
        {
            _nextNode.Add(from, null);
        }
        
        _nextNode[from] = to;
    }

    public bool DoesIntersect(string[] startNodes)
    {
        var visitedNodes = new HashSet< string>();
        
        foreach (var startNode in startNodes)
        {
            //check for cycle
            if (DetectCycle(startNode.Trim()))
            {
                throw new InvalidOperationException("Cycle detected");
            }
            if (!_nextNode.ContainsKey(startNode.Trim()))
            {
                if (visitedNodes.Contains(startNode.Trim()))
                {
                    return true;//Intersection found
                }
                visitedNodes.Add(startNode.Trim());
                continue;
            }
            string slow = startNode.Trim();
            
            while ( true)
            {
                if (!_nextNode.ContainsKey(slow))
                {
                    visitedNodes.Add(slow);
                    break;
                }
                visitedNodes.Add(slow);
                slow = _nextNode[slow];
                
                if (visitedNodes.Contains(slow))
                {
                    return true;//Intersection found
                }

            }
        }

        return false;
    }

    private bool DetectCycle(string startNode)
    {
        string slow = startNode;
        string fast = startNode;
        while (!string.IsNullOrEmpty(fast) && _nextNode.TryGetValue(fast, out string nextFast))
        {
            if (_nextNode.ContainsKey(slow))
            {
                slow = _nextNode[slow];
            }
            else
            {
                break;
            }

            if (_nextNode.ContainsKey(nextFast))
            {
                fast = _nextNode[nextFast];
            }
            else
            {
                break;
            }

            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}

public class ListNode
{
    public readonly string Value;
    public  ListNode Next;

    public ListNode(string value)
    {
        Value = value;
    }
}