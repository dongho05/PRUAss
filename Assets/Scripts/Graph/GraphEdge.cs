using UnityEngine;

public class GraphEdge<T> where T : MonoBehaviour
{
    public GraphNode<T> from { get; set; }
    public GraphNode<T> to { get; set; }

    public float weight { get; set; }
}
