using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCircle;
    Timer timer;
    Vector3 endpoint;
    public float speed = 5.0f;

    // The target (cylinder) position.
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5;
        timer.Run();
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(
            screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld =
            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld =
            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        float screenLeft = lowerLeftCornerWorld.x;
        float screenRight = upperRightCornerWorld.x;
        float screenTop = upperRightCornerWorld.y;
        float screenBottom = lowerLeftCornerWorld.y;
        timer = gameObject.AddComponent<Timer>();
        endpoint = new Vector3(Random.Range(-17f, 10f), Random.Range(-4f, 4f), -Camera.main.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        // save screen edges in world coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(
            screenWidth, screenHeight, screenZ);
        Vector3 lowerLeftCornerWorld =
            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld =
            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
        float screenLeft = lowerLeftCornerWorld.x;
        float screenRight = upperRightCornerWorld.x;
        float screenTop = upperRightCornerWorld.y;
        float screenBottom = lowerLeftCornerWorld.y;
        timer = gameObject.AddComponent<Timer>();
        transform.position = Vector3.MoveTowards(transform.position, endpoint, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, endpoint) < 0.001f)
        {
            endpoint = new Vector3(Random.Range(-17f, 10f), Random.Range(-4f, 4f), -Camera.main.transform.position.z);
        }
    }
    public int score { set; get; } = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            //score++;
            //Debug.Log(score);
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(1);
            Destroy(gameObject);
        }
    }

}
