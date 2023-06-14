using UnityEngine;
using UnityEngine.UI;

public class TrackInputScript : MonoBehaviour
{
    public static string StartPointValue;
    public static string EndPointValue;
    [SerializeField]
    private InputField StartPoint;
    [SerializeField]
    private InputField EndPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetStartPoint()
    {
        Debug.Log(StartPoint.text);
        StartPointValue = StartPoint.text;
    }
    public void GetEndPoint()
    {
        Debug.Log(EndPoint.text);
        EndPointValue = EndPoint.text;
    }
    public void EnableTrack()
    {
        GraphTracker.isRun = true;
    }
}
