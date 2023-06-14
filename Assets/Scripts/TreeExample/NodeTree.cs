using System.Collections.Generic;

public class NodeTree<T>
{
    public T Data { get; set; }
    public List<NodeTree<T>> Children { get; set; }

    public NodeTree(T data)
    {
        Data = data;
        Children = new List<NodeTree<T>>();
    }
}
