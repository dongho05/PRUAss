using System.Collections.Generic;
using Trees;
using UnityEngine;

public class BuildTreeController : MonoBehaviour
{
    public GameObject prefab; // Prefab for the cube node visual
    public float horizontalSpacing = 2.0f; // Spacing between nodes horizontally
    public float verticalSpacing = 1.0f; // Spacing between levels vertically
    private Dictionary<TreeNode<char>, Vector3> nodePositions;
    //private TreeNode<char> rootNode; // Root node of the tree
    public GameObject lineRendererPrefab;
    private static int totalNodes = 0;

    private void Start()
    {

        // Build the tree structure
        //BuildTree();

        //// Visualize the tree
        //VisualizeTree(rootNode, Vector3.zero, 0);
        //VisualizeTreeBFS();
        CreateTree();
    }
    private void CreateTree()
    {
        TreeNode<char> rootNode = new TreeNode<char>('A', null);
        TreeNode<char> nodeB = new TreeNode<char>('B', rootNode);
        TreeNode<char> nodeC = new TreeNode<char>('C', rootNode);
        TreeNode<char> nodeD = new TreeNode<char>('D', nodeB);
        TreeNode<char> nodeE = new TreeNode<char>('E', nodeB);
        TreeNode<char> nodeF = new TreeNode<char>('F', nodeC);
        TreeNode<char> nodeG = new TreeNode<char>('G', nodeC);
        TreeNode<char> nodeH = new TreeNode<char>('H', nodeD);
        TreeNode<char> nodeI = new TreeNode<char>('I', nodeD);
        TreeNode<char> nodeJ = new TreeNode<char>('J', nodeF);

        rootNode.AddChild(nodeB);
        rootNode.AddChild(nodeC);
        nodeB.AddChild(nodeD);
        nodeB.AddChild(nodeE);
        nodeC.AddChild(nodeF);
        nodeC.AddChild(nodeG);
        nodeD.AddChild(nodeH);
        nodeD.AddChild(nodeI);
        nodeF.AddChild(nodeJ);

        totalNodes = CountNodes(rootNode);
        VisualizeTree(rootNode);
    }
    private void CreateNodeConnection(TreeNode<char> parentNode, TreeNode<char> childNode)
    {
        GameObject lineRenderer = Instantiate(lineRendererPrefab, transform);
        LineRenderer line = lineRenderer.GetComponent<LineRenderer>();
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.SetPosition(0, nodePositions[parentNode]);
        line.SetPosition(1, nodePositions[childNode]);
    }

    public void VisualizeTree(TreeNode<char> tree)
    {
        if (tree != null)
        {
            nodePositions = new Dictionary<TreeNode<char>, Vector3>();
            CalculateNodePositions(tree, Vector3.zero, 1);

            Queue<TreeNode<char>> searchQueue = new Queue<TreeNode<char>>();
            searchQueue.Enqueue(tree);

            while (searchQueue.Count > 0)
            {
                TreeNode<char> node = searchQueue.Dequeue();
                CreateNodeGameObject(node);

                List<TreeNode<char>> children = new List<TreeNode<char>>(node.Children);

                foreach (TreeNode<char> childNode in children)
                {
                    searchQueue.Enqueue(childNode);
                    CreateNodeConnection(node, childNode);
                }
            }
        }
    }
    private void CreateNodeGameObject(TreeNode<char> node)
    {
        GameObject newNode = Instantiate(prefab, nodePositions[node], Quaternion.identity, transform);
        //newNode.GetComponentInChildren<TextMesh>().text = node.Value.ToString();
    }
    private int CountNodes(TreeNode<char> node)
    {
        if (node == null)
            return 0;

        int count = 1; // Đếm node hiện tại

        foreach (TreeNode<char> childNode in node.Children)
        {
            count += CountNodes(childNode); // Đệ quy đếm số node con
        }

        return count;
    }
    private float CalculateDistance(TreeNode<char> nodeA, TreeNode<char> nodeB)
    {
        int remainingNodeCount = CountRemainingNodes(nodeA, nodeB);
        float distance = remainingNodeCount * horizontalSpacing / (totalNodes / 3);
        return distance;
    }

    private int CountRemainingNodes(TreeNode<char> nodeA, TreeNode<char> nodeB)
    {
        int count = 0;

        // Sử dụng BFS để đếm số lượng node còn lại trong cây chưa được vẽ
        Queue<TreeNode<char>> queue = new Queue<TreeNode<char>>();
        HashSet<TreeNode<char>> visited = new HashSet<TreeNode<char>>();

        queue.Enqueue(nodeA);
        queue.Enqueue(nodeB);
        visited.Add(nodeA);
        visited.Add(nodeB);

        while (queue.Count > 0)
        {
            TreeNode<char> currentNode = queue.Dequeue();
            count++;

            foreach (TreeNode<char> childNode in currentNode.Children)
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

    private void CalculateNodePositions(TreeNode<char> node, Vector3 position, int level)
    {
        if (node == null)
            return;

        nodePositions[node] = position;

        // Tính toán vị trí ngang của các node con theo từng mức độ
        float childYOffset = verticalSpacing * level;

        // Tính toán vị trí ngang của node cha hiện tại
        float parentXOffset = position.x - CalculateDistance(node, node) / 2f;

        // Duyệt qua các node con và tính toán vị trí của chúng
        foreach (TreeNode<char> childNode in node.Children)
        {
            // Tính toán vị trí của node con
            Vector3 childPosition = new Vector3(parentXOffset, position.y - childYOffset, 0f);
            CalculateNodePositions(childNode, childPosition, level + 1);

            // Cập nhật vị trí ngang của node cha tiếp theo
            parentXOffset += CalculateDistance(childNode, node) + CalculateDistance(childNode, childNode);
        }
    }
}
