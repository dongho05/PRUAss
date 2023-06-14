using System.Collections.Generic;
using UnityEngine;

public class GraphTracker : MonoBehaviour
{
    [SerializeField]
    public GameObject location;
    List<GraphNode<LocationInfo>> visualPath = new List<GraphNode<LocationInfo>>();
    private GameObject mover;
    [SerializeField]
    public GameObject line;
    public static bool isRun = false;
    private float getDistance(LocationInfo a, LocationInfo b)
    {
        return Mathf.Sqrt(((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y)));
    }

    // Start is called before the first frame update
    void Start()
    {
        //string[] names = { "0", "1", "2", "3", "4", "5" };
        //int[] Xs = { -12, -8, -4, 10, 4, -8 };
        //int[] Ys = { 2, 3, 7, -1, -2, -1 };

        //Graph<LocationInfo> graph = new Graph<LocationInfo>();

        //for (int i = 0; i < names.Length; i++)
        //{
        //    LocationInfo infoA = new LocationInfo();
        //    infoA.name = names[i];
        //    infoA.x = Xs[i];
        //    infoA.y = Ys[i];
        //    GameObject bodyA = Instantiate<GameObject>(location);
        //    infoA.body = bodyA;
        //    bodyA.transform.position = new Vector3(infoA.x, infoA.y, 0);
        //    GraphNode<LocationInfo> node = new GraphNode<LocationInfo>();
        //    node.data = infoA;
        //    graph.nodes.Add(node);
        //}

        //GraphEdge<LocationInfo> e0_1 = new GraphEdge<LocationInfo>();
        //e0_1.from = graph.nodes[0];
        //e0_1.to = graph.nodes[1];
        //e0_1.weight = getDistance(e0_1.from.data, e0_1.to.data);
        //graph.edges.Add(e0_1);



        //GraphEdge<LocationInfo> e0_5 = new GraphEdge<LocationInfo>();
        //e0_5.from = graph.nodes[0];
        //e0_5.to = graph.nodes[5];
        //e0_5.weight = getDistance(e0_5.from.data, e0_5.to.data);
        //graph.edges.Add(e0_5);

        //GraphEdge<LocationInfo> e1_2 = new GraphEdge<LocationInfo>();
        //e1_2.from = graph.nodes[1];
        //e1_2.to = graph.nodes[2];
        //e1_2.weight = getDistance(e1_2.from.data, e1_2.to.data);
        //graph.edges.Add(e1_2);

        //GraphEdge<LocationInfo> e1_4 = new GraphEdge<LocationInfo>();
        //e1_4.from = graph.nodes[1];
        //e1_4.to = graph.nodes[4];
        //e1_4.weight = getDistance(e1_4.from.data, e1_4.to.data);
        //graph.edges.Add(e1_4);

        //GraphEdge<LocationInfo> e2_3 = new GraphEdge<LocationInfo>();
        //e2_3.from = graph.nodes[2];
        //e2_3.to = graph.nodes[3];
        //e2_3.weight = getDistance(e2_3.from.data, e2_3.to.data);
        //graph.edges.Add(e2_3);

        //GraphEdge<LocationInfo> e4_3 = new GraphEdge<LocationInfo>();
        //e4_3.from = graph.nodes[4];
        //e4_3.to = graph.nodes[3];
        //e4_3.weight = getDistance(e4_3.from.data, e4_3.to.data);
        //graph.edges.Add(e4_3);

        //GraphEdge<LocationInfo> e5_4 = new GraphEdge<LocationInfo>();
        //e5_4.from = graph.nodes[5];
        //e5_4.to = graph.nodes[4];
        //e5_4.weight = getDistance(e5_4.from.data, e5_4.to.data); ;
        //graph.edges.Add(e5_4);

        //GraphNode<LocationInfo> source = graph.nodes[int.Parse(TrackInputScript.Instance.GetStartPoint().Trim())];
        //GraphNode<LocationInfo> destination = graph.nodes[int.Parse(TrackInputScript.Instance.GetEndPoint().Trim())];

        //List<GraphNode<LocationInfo>> path = graph.getPath(source, destination);
        //foreach (GraphNode<LocationInfo> node in path)
        //{
        //    visualPath.Add(node);
        //    Debug.Log(node.data.name);
        //}

        //mover = GameObject.FindGameObjectWithTag("mover");
        //mover.transform.position = source.data.body.transform.position;


        //foreach (GraphEdge<LocationInfo> edge in graph.edges)
        //{
        //    GameObject newLine = GameObject.Instantiate<GameObject>(line);
        //    LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
        //    List<Vector3> pos = new List<Vector3>();
        //    pos.Add(new Vector3(edge.from.data.x, edge.from.data.y));
        //    pos.Add(new Vector3(edge.to.data.x, edge.to.data.y));
        //    lineRenderer.startWidth = 0.1f;
        //    lineRenderer.endWidth = 0.1f;
        //    lineRenderer.SetPositions(pos.ToArray());
        //    lineRenderer.useWorldSpace = true;

        //    GameObject newTriagle = GameObject.Instantiate<GameObject>(line);
        //    LineRenderer triRenderer = newTriagle.GetComponent<LineRenderer>();
        //    List<Vector3> tripos = new List<Vector3>();
        //    float dAB = getDistance(edge.from.data, edge.to.data);
        //    float triX = edge.to.data.x + (dAB * (edge.from.data.x - edge.to.data.x)) / 50f;
        //    float triY = edge.to.data.y + (dAB * (edge.from.data.y - edge.to.data.y)) / 50f;
        //    tripos.Add(new Vector3(triX, triY));
        //    tripos.Add(new Vector3(edge.to.data.x, edge.to.data.y));
        //    triRenderer.startWidth = 0.5f;
        //    triRenderer.endWidth = 0.1f;
        //    triRenderer.SetPositions(tripos.ToArray());
        //    triRenderer.useWorldSpace = true;

        //}

    }

    // Update is called once per frame
    int numberOfVisitedNodes = 0;
    void Update()
    {
        if (isRun == true)
        {


            isRun = false;
            string[] names = { "0", "1", "2", "3", "4", "5" };
            int[] Xs = { -12, -8, -4, 10, 4, -8 };
            int[] Ys = { 2, 3, 7, -1, -2, -1 };

            Graph<LocationInfo> graph = new Graph<LocationInfo>();

            for (int i = 0; i < names.Length; i++)
            {
                LocationInfo infoA = new LocationInfo();
                infoA.name = names[i];
                infoA.x = Xs[i];
                infoA.y = Ys[i];
                GameObject bodyA = Instantiate<GameObject>(location);
                infoA.body = bodyA;
                bodyA.transform.position = new Vector3(infoA.x, infoA.y, 0);
                GraphNode<LocationInfo> node = new GraphNode<LocationInfo>();
                node.data = infoA;
                graph.nodes.Add(node);
            }

            GraphEdge<LocationInfo> e0_1 = new GraphEdge<LocationInfo>();
            e0_1.from = graph.nodes[0];
            e0_1.to = graph.nodes[1];
            e0_1.weight = getDistance(e0_1.from.data, e0_1.to.data);
            graph.edges.Add(e0_1);



            GraphEdge<LocationInfo> e0_5 = new GraphEdge<LocationInfo>();
            e0_5.from = graph.nodes[0];
            e0_5.to = graph.nodes[5];
            e0_5.weight = getDistance(e0_5.from.data, e0_5.to.data);
            graph.edges.Add(e0_5);

            GraphEdge<LocationInfo> e1_2 = new GraphEdge<LocationInfo>();
            e1_2.from = graph.nodes[1];
            e1_2.to = graph.nodes[2];
            e1_2.weight = getDistance(e1_2.from.data, e1_2.to.data);
            graph.edges.Add(e1_2);

            GraphEdge<LocationInfo> e1_4 = new GraphEdge<LocationInfo>();
            e1_4.from = graph.nodes[1];
            e1_4.to = graph.nodes[4];
            e1_4.weight = getDistance(e1_4.from.data, e1_4.to.data);
            graph.edges.Add(e1_4);

            GraphEdge<LocationInfo> e2_3 = new GraphEdge<LocationInfo>();
            e2_3.from = graph.nodes[2];
            e2_3.to = graph.nodes[3];
            e2_3.weight = getDistance(e2_3.from.data, e2_3.to.data);
            graph.edges.Add(e2_3);

            GraphEdge<LocationInfo> e4_3 = new GraphEdge<LocationInfo>();
            e4_3.from = graph.nodes[4];
            e4_3.to = graph.nodes[3];
            e4_3.weight = getDistance(e4_3.from.data, e4_3.to.data);
            graph.edges.Add(e4_3);

            GraphEdge<LocationInfo> e5_4 = new GraphEdge<LocationInfo>();
            e5_4.from = graph.nodes[5];
            e5_4.to = graph.nodes[4];
            e5_4.weight = getDistance(e5_4.from.data, e5_4.to.data); ;
            graph.edges.Add(e5_4);

            GraphNode<LocationInfo> source = graph.nodes[int.Parse(TrackInputScript.StartPointValue)];
            GraphNode<LocationInfo> destination = graph.nodes[int.Parse(TrackInputScript.EndPointValue)];

            List<GraphNode<LocationInfo>> path = graph.getPath(source, destination);
            foreach (GraphNode<LocationInfo> node in path)
            {
                visualPath.Add(node);
                Debug.Log(node.data.name);
            }

            mover = GameObject.FindGameObjectWithTag("mover");
            mover.transform.position = source.data.body.transform.position;


            foreach (GraphEdge<LocationInfo> edge in graph.edges)
            {
                GameObject newLine = GameObject.Instantiate<GameObject>(line);
                LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
                List<Vector3> pos = new List<Vector3>();
                pos.Add(new Vector3(edge.from.data.x, edge.from.data.y));
                pos.Add(new Vector3(edge.to.data.x, edge.to.data.y));
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                lineRenderer.SetPositions(pos.ToArray());
                lineRenderer.useWorldSpace = true;

                GameObject newTriagle = GameObject.Instantiate<GameObject>(line);
                LineRenderer triRenderer = newTriagle.GetComponent<LineRenderer>();
                List<Vector3> tripos = new List<Vector3>();
                float dAB = getDistance(edge.from.data, edge.to.data);
                float triX = edge.to.data.x + (dAB * (edge.from.data.x - edge.to.data.x)) / 50f;
                float triY = edge.to.data.y + (dAB * (edge.from.data.y - edge.to.data.y)) / 50f;
                tripos.Add(new Vector3(triX, triY));
                tripos.Add(new Vector3(edge.to.data.x, edge.to.data.y));
                triRenderer.startWidth = 0.5f;
                triRenderer.endWidth = 0.1f;
                triRenderer.SetPositions(tripos.ToArray());
                triRenderer.useWorldSpace = true;

            }
        }


        if (visualPath.Count > 0 && numberOfVisitedNodes < visualPath.Count)
        {
            GraphNode<LocationInfo> destination1 = visualPath[numberOfVisitedNodes];

            float step = 1 * Time.deltaTime;
            // move sprite towards the target location
            Vector2 point = new Vector2(destination1.data.x, destination1.data.y);
            mover.transform.position = Vector2.MoveTowards(mover.transform.position, point, step);

            if (mover.transform.position.x == destination1.data.x && mover.transform.position.y == destination1.data.y)
            {
                numberOfVisitedNodes++;
            }
        }
    }
}
