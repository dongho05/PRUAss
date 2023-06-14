using UnityEngine;

public class Bullet2Controller : MonoBehaviour
{
    Timer bullet_timer;
    public float Impulse = 10f;
    // Start is called before the first frame update
    void Start()
    {
        bullet_timer = gameObject.AddComponent<Timer>();
        bullet_timer.Duration = 6;
        bullet_timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5 || transform.position.y < -5
            || transform.position.x > 15 || transform.position.x < -12)
        {
            gameObject.SetActive(false);
            ShootUsingPool.instance.ReturnBullet(gameObject);

        }
    }
    public void ApplyForce(Vector2 forceDirection)
    {
        const float forceMagnitude = 10f;
        GetComponent<Rigidbody2D>().AddForce(
            forceMagnitude * forceDirection,
            ForceMode2D.Impulse);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("enemy"))
    //    {

    //        Destroy(gameObject);
    //    }
    //}
}
