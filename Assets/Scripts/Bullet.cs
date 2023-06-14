using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Timer bullet_timer;
    public float Impulse = 10f;
    void Start()
    {
        bullet_timer = gameObject.AddComponent<Timer>();
        bullet_timer.Duration = 6;
        bullet_timer.Run();
    }
    private void Update()
    {
        if (transform.position.y > 5 || transform.position.y < -5
            || transform.position.x > 15 || transform.position.x < -12)
        {
            gameObject.SetActive(false);
            ShootUsingPool.instance.ReturnBullet(gameObject);

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("enemy"))
    //    {

    //        Destroy(gameObject);
    //    }
    //}
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
    public void ApplyForce(Vector2 forceDirection)
    {
        const float forceMagnitude = 10f;
        GetComponent<Rigidbody2D>().AddForce(
            forceMagnitude * forceDirection,
            ForceMode2D.Impulse);
    }
}
