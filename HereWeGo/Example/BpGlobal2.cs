using System.Runtime.InteropServices;

namespace Example;

public class BpGlobal2
{
    public IEnumerable<string> MainProblem(string[] list)
    {
        List<string> answer = new List<string>();
        SinglyLinkedList1 singlyLinkedList1 = new SinglyLinkedList1();
        foreach (var input in list)
        {
            //check for cycle
            
            if (input.Contains('>'))//its edge
            {
                string[] nodes = input.Split("->");
                singlyLinkedList1.AddEdge(nodes[0], nodes[1]);
            }
            else
            {
                //check for intersection
                try
                {
                    string[] nodeList = input.Split(',');
                    bool result = singlyLinkedList1.IsIntersect(nodeList);
                    answer.Add(result.ToString());
                }
                catch (Exception e)
                {
                    answer.Add("Error Thrown!");
                }
            }
        }

        return answer;
    }
}

class SinglyLinkedList1
{
    private Dictionary<string, string> _adjacencyList;
    private Dictionary<string, bool> _cyclicNode = new Dictionary<string, bool>();
    public SinglyLinkedList1()
    {
        _adjacencyList= new Dictionary<string, string>();
    }

    public void AddEdge(string from, string to)
    {
        if (!_adjacencyList.ContainsKey(from))
        {
            _adjacencyList.Add(from, string.Empty);
        }

        _adjacencyList[from] = to;
    }

    public bool IsIntersect(string[] startingNodes)
    {
        HashSet<string> visitedNode = new HashSet<string>();
        foreach (var startNode in startingNodes)
        {
            if (!_cyclicNode.ContainsKey(startNode.Trim()) )
            {
                bool isCycleFound = IsCycleExists(startNode.Trim());

                if (isCycleFound)
                {
                    _cyclicNode.Add(startNode.Trim(), true);
                    throw new InvalidOperationException("Cycle found");
                }

                _cyclicNode.Add(startNode.Trim(), false);
            }
            else
            {
                if (_cyclicNode[startNode.Trim()])
                {
                    throw new InvalidOperationException("Cycle found");
                }
            }
            
            
            if (visitedNode.Contains(startNode.Trim()))
            {
                return true;
            }
            if (!_adjacencyList.ContainsKey(startNode.Trim()))
            {
                visitedNode.Add(startNode.Trim());
                continue;
            }

            string node = startNode.Trim();
            while (!string.IsNullOrEmpty(node))
            {
                //check whether node in visited
                if (visitedNode.Contains(node))
                {
                    return true;
                }

                visitedNode.Add(node);
                if (_adjacencyList.ContainsKey(node))
                {
                    // 
                    node = _adjacencyList[node];
                }
                else
                {
                    break;
                }
            }

        }

        return false;
    }

    public bool IsCycleExists(string node)
    {
        string fast = node;
        string slow = node;

        
        while (!string.IsNullOrWhiteSpace(fast))
        {
            if (!_adjacencyList.ContainsKey(slow))
            {
                return false;
            }
            slow = _adjacencyList[slow];
            _adjacencyList.TryGetValue(fast, out string nextFast);
            if (string.IsNullOrWhiteSpace(nextFast) || !_adjacencyList.ContainsKey(nextFast))
            {
                return false;
            }

            fast = _adjacencyList[nextFast];

            if (slow == fast)
            {
                return true;
            }
        }

        return false;

    }
}

class ListNode1
{
    public string Value;
    public ListNode1 Next;
    public ListNode1(string value)
    {
        Value = value;

    }
}