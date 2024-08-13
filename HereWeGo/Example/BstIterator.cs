namespace Example;

public class BstIterator
{
    private Stack<BstNode> _allNodes;
    public BstIterator(BstNode treeNode)
    {
        _allNodes = new Stack<BstNode>();
        FillAllLeftNodes(treeNode);

    }

    private void FillAllLeftNodes(BstNode node)
    {
        while (node!= null)
        {
            _allNodes.Push(node);
            node = node.Left;

        }
    }

    public bool HasNext()
    {
        return _allNodes.Count > 0;
    }

    public int Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No lele ");
        }

        BstNode nodeTop = _allNodes.Pop();

        if (nodeTop.Right != null)
        {
            FillAllLeftNodes(nodeTop.Right);
        }

        return nodeTop.Value;

    }
    
}

public class BstNode
{
    public  int Value { get; set; }
    public  BstNode Left { get; set; }
    public  BstNode Right { get; set; }

    public BstNode(int val)
    {
        Value = val;
    }
}