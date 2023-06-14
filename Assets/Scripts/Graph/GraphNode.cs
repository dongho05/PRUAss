using UnityEngine;

public class GraphNode<T> where T : MonoBehaviour
{
    public T data { get; set; }
}
