using System.Collections.Generic;
using UnityEngine;

public class InitialTree : MonoBehaviour
{

    public GameObject prefab; // Prefab for the cube node visual
    public float horizontalSpacing = 2.0f; // Spacing between nodes horizontally
    public float verticalSpacing = 1.0f; // Spacing between levels vertically

    public GameObject lineRendererPrefab;
    //private Dictionary<NodeTree<GameObject>, Vector3> nodePositions;

    private NodeTree<GameObject> rootNode; // Root node of the tree
    private static int totalNodes = 0;
    private Dictionary<NodeTree<GameObject>, Vector3> nodePositions;

    private void Start()
    {

        // Build the tree structure
        BuildTree();
        totalNodes = CountNodes(rootNode);
        // Visualize the tree
        VisualizeTree(rootNode, Vector3.zero, 0);
        //VisualizeTreeBFS();
    }
    private int CountNodes(NodeTree<GameObject> node)
    {
        if (node == null)
            return 0;

        int count = 1; // Đếm node hiện tại

        foreach (NodeTree<GameObject> childNode in node.Children)
        {
            count += CountNodes(childNode); // Đệ quy đếm số node con
        }

        return count;
    }
    private void BuildTree()
    {
        // Construct the tree structure
        rootNode = new NodeTree<GameObject>(prefab);


        NodeTree<GameObject> nodeB = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeC = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeD = new NodeTree<GameObject>(prefab);

        NodeTree<GameObject> nodeE = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeF = new NodeTree<GameObject>(prefab);

        NodeTree<GameObject> nodeG = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeH = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeJ = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeK = new NodeTree<GameObject>(prefab);


        NodeTree<GameObject> nodeM = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeL = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeN = new NodeTree<GameObject>(prefab);

        NodeTree<GameObject> nodeS = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeT = new NodeTree<GameObject>(prefab);


        NodeTree<GameObject> nodeO = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeP = new NodeTree<GameObject>(prefab);
        NodeTree<GameObject> nodeQ = new NodeTree<GameObject>(prefab);

        rootNode.Children.Add(nodeB);
        rootNode.Children.Add(nodeC);
        rootNode.Children.Add(nodeD);

        nodeB.Children.Add(nodeG);
        nodeB.Children.Add(nodeH);
        nodeB.Children.Add(nodeJ);
        nodeB.Children.Add(nodeK);

        nodeC.Children.Add(nodeE);
        nodeC.Children.Add(nodeF);

        nodeH.Children.Add(nodeM);
        nodeH.Children.Add(nodeL);
        nodeH.Children.Add(nodeN);

        nodeE.Children.Add(nodeT);
        nodeE.Children.Add(nodeS);

        nodeM.Children.Add(nodeO);
        nodeM.Children.Add(nodeP);
        nodeM.Children.Add(nodeQ);
        //Debug.Log(nodeC.CalculateHeight());




    }

    private void CreateNodeConnection(Vector2 parentNode, Vector2 childNode)
    {
        GameObject lineRenderer = Instantiate(lineRendererPrefab, transform);
        lineRenderer.transform.SetParent(transform);
        LineRenderer line = lineRenderer.GetComponent<LineRenderer>();
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.SetPosition(0, parentNode);
        line.SetPosition(1, childNode);
    }
    private void VisualizeTree(NodeTree<GameObject> node, Vector3 position, int level)
    {
        //// Create a cube visual for the current node
        //GameObject cube = Instantiate(prefab, position, Quaternion.identity);
        //cube.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //// Set the name of the cube to the node's data for easy identification
        //cube = node.Data;

        //// Adjust the cube's position based on the level and horizontal spacing
        //cube.transform.position = new Vector3(position.x + (level * horizontalSpacing), position.y - (node.Children.Count * verticalSpacing), position.z);

        ////nodePositions = new Dictionary<NodeTree<GameObject>, Vector3>();

        //// Iterate over the children and recursively visualize them
        //for (int i = 0; i < node.Children.Count; i++)
        //{
        //    Vector3 childPosition = new Vector3(position.x + ((i + 1) * horizontalSpacing), position.y - (node.Children.Count * verticalSpacing), position.z);
        //    CreateNodeConnection(position, childPosition);
        //    VisualizeTree(node.Children[i], childPosition, level + 1);
        //}


        if (node != null)
        {
            nodePositions = new Dictionary<NodeTree<GameObject>, Vector3>();
            CalculateNodePositions(node, Vector3.zero, 1);

            Queue<NodeTree<GameObject>> searchQueue = new Queue<NodeTree<GameObject>>();
            searchQueue.Enqueue(node);

            while (searchQueue.Count > 0)
            {
                NodeTree<GameObject> node1 = searchQueue.Dequeue();
                GameObject cube = Instantiate(prefab, nodePositions[node1], Quaternion.identity);
                List<NodeTree<GameObject>> children = new List<NodeTree<GameObject>>(node1.Children);

                foreach (NodeTree<GameObject> childNode in children)
                {
                    searchQueue.Enqueue(childNode);
                    CreateNodeConnection(node.Data.transform.position, childNode.Data.transform.position);
                }
            }
        }
    }

    private void CalculateNodePositions(NodeTree<GameObject> node, Vector3 position, int level)
    {
        if (node == null)
            return;
        nodePositions[node] = position;

        // Tính toán vị trí ngang của các node con theo từng mức độ
        float childYOffset = verticalSpacing * level;

        // Tính toán vị trí ngang của node cha hiện tại
        float parentXOffset = position.x - CalculateDistance(node, node) / 2f;

        // Duyệt qua các node con và tính toán vị trí của chúng
        foreach (NodeTree<GameObject> childNode in node.Children)
        {
            // Tính toán vị trí của node con
            Vector3 childPosition = new Vector3(parentXOffset, position.y - childYOffset, 0f);
            CalculateNodePositions(childNode, childPosition, level + 1);

            // Cập nhật vị trí ngang của node cha tiếp theo
            parentXOffset += CalculateDistance(childNode, node) + CalculateDistance(childNode, childNode);
        }
    }
    private float CalculateDistance(NodeTree<GameObject> nodeA, NodeTree<GameObject> nodeB)
    {
        int remainingNodeCount = CountRemainingNodes(nodeA, nodeB);
        float distance = remainingNodeCount * horizontalSpacing / (totalNodes / 3);
        return distance;
    }
    private int CountRemainingNodes(NodeTree<GameObject> nodeA, NodeTree<GameObject> nodeB)
    {
        int count = 0;

        // Sử dụng BFS để đếm số lượng node còn lại trong cây chưa được vẽ
        Queue<NodeTree<GameObject>> queue = new Queue<NodeTree<GameObject>>();
        HashSet<NodeTree<GameObject>> visited = new HashSet<NodeTree<GameObject>>();

        queue.Enqueue(nodeA);
        queue.Enqueue(nodeB);
        visited.Add(nodeA);
        visited.Add(nodeB);

        while (queue.Count > 0)
        {
            NodeTree<GameObject> currentNode = queue.Dequeue();
            count++;

            foreach (NodeTree<GameObject> childNode in currentNode.Children)
            {
                if (!visited.Contains(childNode))
                {
                    queue.Enqueue(childNode);
                    visited.Add(childNode);
                }
            }
        }

        return count;
    }
}
